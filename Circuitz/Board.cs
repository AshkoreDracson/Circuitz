using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Circuitz
{
    using Nodes;
    public class Board
    {
        public List<Node> Nodes { get; } = new List<Node>();
        public List<Wire> Wires { get; } = new List<Wire>();

        public uint UpdateCount { get; private set; }
        public uint StepCount { get; private set; }

        public Node GetNodeAtPoint(Point p)
        {
            return Nodes.FirstOrDefault(node => node.Intersects(p));
        }

        public void AddNode(Node n)
        {
            Nodes.Add(n);
            n.Board = this;
            UpdateWires();
        }
        public void RemoveNode(Node n)
        {
            Nodes.Remove(n);
            n.Board = null;
            CleanInvalidWires();
            UpdateWires();
        }

        public void Step()
        {
            foreach (Node node in Nodes)
            {
                node.Update();
                UpdateCount++;
            }
            UpdateWires();

            StepCount++;
        }
        public void UpdateWires()
        {
            do
            {
                foreach (Wire wire in Wires)
                {
                    wire.Update();
                    UpdateCount++;
                }
            } while (Nodes.Any(node => node.RequiresUpdate));
        }

        public void Wire(Node a, Node b, int inIndex, int outIndex)
        {
            Wires.RemoveAll(wire => wire.Output == b && wire.OutputIndex == outIndex);
            Wires.Add(new Wire(a, b, inIndex, outIndex) { Board = this });
        }

        public void CleanInvalidWires()
        {
            Wires.RemoveAll(wire => !wire.ConnectionValid);
        }
    }
}