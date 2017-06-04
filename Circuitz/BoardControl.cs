using Circuitz.Nodes;
using Elementary;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Circuitz
{
    public class BoardControl : Control
    {
        public Board Board { get; } = new Board();

        public Color OffColor { get; set; } = Color.IndianRed;
        public Color OnColor { get; set; } = Color.ForestGreen;
        public Color GridColor { get; set; } = Color.FromArgb(32, 0, 0, 0);
        public Color BigGridColor { get; set; } = Color.FromArgb(64, 0, 0, 0);
        public Color SelectedNodeColor { get; set; } = Color.LightBlue;
        public int GridSize { get; set; } = 16;
        public int GridBigSize => GridSize * 10;
        public Point ViewPoint { get; set; }

        public bool GridSnapping => LinkedGridSnapCheckBox.Checked;

        public CheckBox LinkedGridSnapCheckBox { get; set; }
        public ListView LinkedListView { get; set; }
        public PropertyGrid LinkedPropertyGrid { get; set; }

        public Node SelectedNode { get; private set; }
        private Point SelectedNodeOffset;

        private Point PreviousMouseLocation;
        private Point MouseDelta;

        private bool Wiring;
        private Node WiringCurrentNode;
        private Node WiringTargetNode;
        private int? WiringCurrentNodeOutput;
        private int? WiringTargetNodeInput;
        private Point WiringCurrentPoint;

        public BoardControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        #region Pen & Brushes Properties & Stuff

        private StringFormat TextFormat => new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

        private SolidBrush _textBrush;
        private SolidBrush TextBrush
        {
            get
            {
                if (_textBrush == null || _textBrush.Color != ForeColor)
                    _textBrush = new SolidBrush(ForeColor);
                return _textBrush;
            }
        }

        private SolidBrush _nodeBrush;
        private SolidBrush NodeBrush
        {
            get
            {
                if (_nodeBrush == null || _nodeBrush.Color != BackColor)
                    _nodeBrush = new SolidBrush(BackColor);
                return _nodeBrush;
            }
        }
        private SolidBrush _nodeSelectedBrush;
        private SolidBrush NodeSelectedBrush
        {
            get
            {
                if (_nodeSelectedBrush == null || _nodeSelectedBrush.Color != SelectedNodeColor)
                    _nodeSelectedBrush = new SolidBrush(SelectedNodeColor);
                return _nodeSelectedBrush;
            }
        }

        private Pen _nodePen;
        private Pen NodePen
        {
            get
            {
                if (_nodePen == null || _nodePen.Color != ForeColor)
                    _nodePen = new Pen(ForeColor);
                return _nodePen;
            }
        }

        private Pen _outlinePen;
        private Pen OutlinePen
        {
            get
            {
                if (_outlinePen == null || _outlinePen.Color != ForeColor)
                    _outlinePen = new Pen(ForeColor);
                return _outlinePen;
            }
        }

        private Pen _gridPen;
        private Pen GridPen
        {
            get
            {
                if (_gridPen == null || _gridPen.Color != GridColor)
                    _gridPen = new Pen(GridColor);
                return _gridPen;
            }
        }

        private Pen _gridBigPen;
        private Pen GridBigPen
        {
            get
            {
                if (_gridBigPen == null || _gridBigPen.Color != GridColor)
                    _gridBigPen = new Pen(BigGridColor);
                return _gridBigPen;
            }
        }

        private Pen _wireOffPen;
        private Pen WireOffPen
        {
            get
            {
                if (_wireOffPen == null || _wireOffPen.Color != OffColor)
                    _wireOffPen = new Pen(OffColor, 1.6f);
                return _wireOffPen;
            }
        }

        private Pen _wireOnPen;
        private Pen WireOnPen
        {
            get
            {
                if (_wireOnPen == null || _wireOnPen.Color != OnColor)
                    _wireOnPen = new Pen(OnColor, 1.6f);
                return _wireOnPen;
            }
        }

        private Pen _branchOnPen;
        private Pen BranchOnPen
        {
            get
            {
                if (_branchOnPen == null || _branchOnPen.Color != OnColor)
                    _branchOnPen = new Pen(OnColor, 3);
                return _branchOnPen;
            }
        }

        private Pen _branchOffPen;
        private Pen BranchOffPen
        {
            get
            {
                if (_branchOffPen == null || _branchOffPen.Color != OffColor)
                    _branchOffPen = new Pen(OffColor, 3);
                return _branchOffPen;
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw grid
            for (int y = 0; y <= ((float)Size.Width / GridSize).CeilingToInt(); y++)
            {
                Point p1 = new Point(GridSize * y, -GridSize).Subtract(ViewPoint.Modulo(GridSize));
                Point p2 = new Point(GridSize * y, Size.Height + GridSize).Subtract(ViewPoint.Modulo(GridSize));
                g.DrawLine(GridPen, p1, p2);
            }
            for (int x = 0; x <= ((float)Size.Height / GridSize).CeilingToInt(); x++)
            {
                Point p1 = new Point(-GridSize, GridSize * x).Subtract(ViewPoint.Modulo(GridSize));
                Point p2 = new Point(Size.Width + GridSize, GridSize * x).Subtract(ViewPoint.Modulo(GridSize));
                g.DrawLine(GridPen, p1, p2);
            }

            // Draw bigger grid
            for (int y = 0; y <= ((float)Size.Width / GridBigSize).CeilingToInt(); y++)
            {
                Point p1 = new Point(GridBigSize * y, -GridBigSize).Subtract(ViewPoint.Modulo(GridBigSize));
                Point p2 = new Point(GridBigSize * y, Size.Height + GridBigSize).Subtract(ViewPoint.Modulo(GridBigSize));
                g.DrawLine(GridBigPen, p1, p2);
            }
            for (int x = 0; x <= ((float)Size.Height / GridBigSize).CeilingToInt(); x++)
            {
                Point p1 = new Point(-GridBigSize, GridBigSize * x).Subtract(ViewPoint.Modulo(GridBigSize));
                Point p2 = new Point(Size.Width + GridBigSize, GridBigSize * x).Subtract(ViewPoint.Modulo(GridBigSize));
                g.DrawLine(GridBigPen, p1, p2);
            }

            // Draw nodes
            foreach (Node node in Board.Nodes)
            {
                // Draw rectangle
                Rectangle nodeRectangle = new Rectangle(node.Position.Subtract(ViewPoint), node.Size);
                g.DrawRectangle(NodePen, nodeRectangle);
                g.FillRectangle(SelectedNode == node ? NodeSelectedBrush : NodeBrush, nodeRectangle);

                // Draw inputs & outputs
                for (int i = 0; i < node.InputCount; i++)
                {
                    Pen currentPen = node.Inputs[i] ? BranchOnPen : BranchOffPen;

                    Point location = node.GetInputPoint(i).Subtract(ViewPoint);
                    location.Offset(-2, -2);
                    g.DrawEllipse(currentPen, new Rectangle(location, new Size(4, 4)));
                }
                for (int i = 0; i < node.OutputCount; i++)
                {
                    Pen currentPen = node.Outputs[i] ? BranchOnPen : BranchOffPen;

                    Point location = node.GetOutputPoint(i).Subtract(ViewPoint);
                    location.Offset(-2, -2);
                    g.DrawEllipse(currentPen, new Rectangle(location, new Size(4, 4)));
                }

                // Draw icon, if any
                if (node.Icon != null)
                {
                    Point iconPos = node.Position.Subtract(ViewPoint);
                    iconPos.Offset(node.Size.Width / 2 - node.Icon.Width / 2, node.Size.Height / 2 - node.Icon.Height / 2);
                    g.DrawImageUnscaled(node.Icon, new Rectangle(iconPos, node.Size));
                }

                // Draw text, if any
                if (!string.IsNullOrEmpty(node.Text))
                {
                    g.DrawString(node.Text, Font, TextBrush, new RectangleF(node.Position.Subtract(ViewPoint), node.Size), TextFormat);
                }
            }

            // Draw wires
            foreach (Wire wire in Board.Wires)
            {
                Pen currentPen = wire.Value ? WireOnPen : WireOffPen;

                Point p1 = wire.Input.GetOutputPoint(wire.InputIndex).Subtract(ViewPoint);
                Point p2 = p1;
                Point p3 = p2;
                Point p6 = wire.Output.GetInputPoint(wire.OutputIndex).Subtract(ViewPoint);
                Point p4 = p6;
                Point p5 = p4;

                int offsetX = ((p1.X - p6.X).Abs() / 2f).CeilingToInt();
                int offsetY = ((p1.Y - p6.Y).Abs() / 2f).CeilingToInt();

                if (p1.Y > p6.Y)
                    offsetY = -offsetY;

                if (p1.X > p6.X)
                    offsetX = offsetX.ClampMax(32);

                p2.Offset(offsetX, 0);
                p3.Offset(offsetX, offsetY);
                p4.Offset(-offsetX, -offsetY);
                p5.Offset(-offsetX, 0);

                g.DrawLines(currentPen, new PointF[] { p1, p2, p3, p4, p5, p6 });
            }
            // Live-link wire
            if (Wiring && WiringCurrentNode != null && WiringCurrentNodeOutput != null)
            {
                Pen currentPen = WireOffPen;

                Point p1 = WiringCurrentNode.GetOutputPoint((int)WiringCurrentNodeOutput).Subtract(ViewPoint);
                Point p2 = p1;
                Point p3 = p2;
                Point p6 = WiringCurrentPoint.Subtract(ViewPoint);
                Point p4 = p6;
                Point p5 = p4;

                int offsetX = ((p1.X - p6.X).Abs() / 2f).CeilingToInt();
                int offsetY = ((p1.Y - p6.Y).Abs() / 2f).CeilingToInt();

                if (p1.Y > p6.Y)
                    offsetY = -offsetY;

                if (p1.X > p6.X)
                    offsetX = offsetX.ClampMax(32);

                p2.Offset(offsetX, 0);
                p3.Offset(offsetX, offsetY);
                p4.Offset(-offsetX, -offsetY);
                p5.Offset(-offsetX, 0);

                g.DrawLines(currentPen, new PointF[] { p1, p2, p3, p4, p5, p6 });
            }

            // Draw control outline
            Rectangle outlineRect = e.ClipRectangle;
            outlineRect.Width--;
            outlineRect.Height--;
            g.DrawRectangle(OutlinePen, outlineRect);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Point RelativeLocation = e.Location.Add(ViewPoint);
            if (e.Button == MouseButtons.Left)
            {
                // Check for wires
                if (!Wiring)
                {
                    WiringCurrentNode = Board.Nodes.FirstOrDefault(node => node.GetOutputIndexAtPoint(RelativeLocation) != null);
                    WiringCurrentNodeOutput = WiringCurrentNode?.GetOutputIndexAtPoint(RelativeLocation);
                    Wiring = WiringCurrentNode != null;

                    if (Wiring)
                    {
                        SelectNode(null);
                        Invalidate();
                        return;
                    }

                    Node n = Board.Nodes.FirstOrDefault(node => node.GetInputIndexAtPoint(RelativeLocation) != null);
                    int? index = n?.GetInputIndexAtPoint(RelativeLocation);

                    if (n != null && index != null)
                    {
                        Wire wireToRemove = Board.Wires.FirstOrDefault(wire => wire.Output == n && wire.OutputIndex == index);
                        if (wireToRemove != null)
                        {
                            Board.Wires.Remove(wireToRemove);
                            Board.UpdateWires();
                            Invalidate();
                            return;
                        }
                    }
                }

                // Check for nodes
                SelectNode(Board.Nodes.FirstOrDefault(node => node.Intersects(RelativeLocation)));
                SelectedNodeOffset = SelectedNode?.Position.Subtract(RelativeLocation) ?? Point.Empty;

                if (SelectedNode == null)
                {
                    if (LinkedListView != null && LinkedListView.SelectedItems.Count == 1)
                    {
                        switch (LinkedListView.SelectedItems[0].Text)
                        {
                            case "Constant":
                                Board.AddNode(new Constant { Position = RelativeLocation });
                                break;
                            case "AND Gate":
                                Board.AddNode(new And(2) { Position = RelativeLocation });
                                break;
                            case "OR Gate":
                                Board.AddNode(new Or(2) { Position = RelativeLocation });
                                break;
                            case "XOR Gate":
                                Board.AddNode(new Xor(2) { Position = RelativeLocation });
                                break;
                            case "NOT Gate":
                                Board.AddNode(new Not { Position = RelativeLocation });
                                break;
                            case "NAND Gate":
                                Board.AddNode(new Nand(2) { Position = RelativeLocation });
                                break;
                            case "NOR Gate":
                                Board.AddNode(new Nor(2) { Position = RelativeLocation });
                                break;
                            case "Buffer":
                                Board.AddNode(new Buffer { Position = RelativeLocation });
                                break;
                            case "Timer":
                                Board.AddNode(new Nodes.Timer { Position = RelativeLocation });
                                break;
                            case "Adder":
                                Board.AddNode(new Adder(4) { Position = RelativeLocation });
                                break;
                        }
                        SelectNode(Board.Nodes.LastOrDefault());
                    }
                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                SelectNode(Board.Nodes.FirstOrDefault(node => node.Intersects(RelativeLocation)));
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point RelativeLocation = e.Location.Add(ViewPoint);
            MouseDelta = PreviousMouseLocation.Subtract(e.Location);

            if (Wiring)
            {
                WiringCurrentPoint = RelativeLocation;
                Invalidate();
            }

            if (SelectedNode != null && e.Button == MouseButtons.Left)
            {
                SelectedNode.Position = RelativeLocation.Add(SelectedNodeOffset);

                if (GridSnapping)
                    SelectedNode.Position = SelectedNode.Position.Snap(GridSize);

                Invalidate();
            }

            if (e.Button == MouseButtons.Middle)
            {
                ViewPoint = ViewPoint.Add(MouseDelta);
                Invalidate();
            }

            PreviousMouseLocation = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Point RelativeLocation = e.Location.Add(ViewPoint);

            if (Wiring)
            {
                WiringTargetNode = Board.Nodes.FirstOrDefault(node => node.GetInputIndexAtPoint(RelativeLocation) != null);
                WiringTargetNodeInput = WiringTargetNode?.GetInputIndexAtPoint(RelativeLocation);

                // Attempt wiring
                if (WiringCurrentNode != null && WiringTargetNode != null && WiringCurrentNodeOutput != null && WiringTargetNodeInput != null)
                {
                    Board.Wire(WiringCurrentNode, WiringTargetNode, (int)WiringCurrentNodeOutput, (int)WiringTargetNodeInput);
                    Board.UpdateWires();
                }

                Wiring = false;
                WiringCurrentNode = WiringTargetNode = null;
                WiringCurrentNodeOutput = WiringTargetNodeInput = null;
                Invalidate();
                return;
            }

            if (SelectedNode != null)
                LinkedPropertyGrid.Refresh();
        }

        public void RemoveNode(Node n)
        {
            Board.RemoveNode(n);
            SelectNode(null);
            Invalidate();
        }
        public void SelectNode(Node n)
        {
            SelectedNode = n;
            LinkedPropertyGrid.SelectedObject = n;
        }
    }
}
