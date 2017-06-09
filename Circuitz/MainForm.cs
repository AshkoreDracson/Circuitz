using Elementary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Circuitz
{
    public partial class MainForm : Form
    {
        readonly Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            gateProperties.PropertyValueChanged += GateProperties_PropertyValueChanged;
            timer.Tick += Timer_Tick;

            UpdateStatusLabel();
        }

        // FUNCTIONS
        void Step()
        {
            boardControl.Board.Step();
            boardControl.Refresh();
        }
        void UpdateStatusLabel()
        {
            statusLabel.Text = $"{(timer.Enabled ? "Playing" : "Stopped")} | Step count: {boardControl.Board.StepCount}, Update count: {boardControl.Board.UpdateCount}";
        }

        // EVENTS

        void OnSizeChanged(object sender, EventArgs e)
        {
            boardControl.Invalidate();
        }

        void GateProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            boardControl.Board.UpdateWires();
            boardControl.Invalidate();
        }

        void stepBTN_Click(object sender, EventArgs e)
        {
            Step();
        }

        void autoStepBTN_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;

            autoStepBTN.Text = timer.Enabled ? "Stop Auto-step" : "Auto-step";
            timeField.Enabled = !timer.Enabled;
            stepBTN.Enabled = !timer.Enabled;
        }

        void timeField_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int)timeField.Value.Clamp(1, 10000);
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Step();
        }

        void OnBoardMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            deleteNodeToolStripMenuItem.Enabled = boardControl.SelectedNode != null;
        }

        void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boardControl.SelectedNode != null)
                boardControl.RemoveNode(boardControl.SelectedNode);
        }

        void OnBoardControlRepainting(object sender, PaintEventArgs e)
        {
            UpdateStatusLabel();
        }

        void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { CheckPathExists = true, CheckFileExists = true, Filter = "Circuitz File|*.cir" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    boardControl.Board.Load(ofd.FileName);
                    boardControl.Board.UpdateWires();
                    boardControl.ViewPoint = boardControl.Board.Nodes[0]?.Position ?? Point.Empty;
                    boardControl.Invalidate();
                }
            }
        }
        void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { CheckPathExists = true, Filter = "Circuitz File|*.cir" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    boardControl.Board.Save(sfd.FileName);
            }
        }
    }
}
