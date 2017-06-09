using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        // IO
        public void Load(string path)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
            {
                string magicWord = br.ReadString();
                if (magicWord != "CIRCUITZ")
                    return;

                Reset();

                int nodeCount = br.ReadInt32();
                for (int i = 0; i < nodeCount; i++)
                {
                    NodeIdentifier type = (NodeIdentifier)br.ReadUInt32();
                    int inputCount = br.ReadInt32();
                    int outputCount = br.ReadInt32();
                    Point pos = new Point(br.ReadInt32(), br.ReadInt32());
                    switch (type)
                    {
                        case NodeIdentifier.None:
                            break;
                        case NodeIdentifier.Constant:
                            bool value = br.ReadBoolean();
                            AddNode(new Constant { Position = pos, Value = value });
                            break;
                        case NodeIdentifier.And:
                            AddNode(new And(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.Or:
                            AddNode(new Or(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.Xor:
                            AddNode(new Xor(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.Buffer:
                            AddNode(new Buffer { Position = pos });
                            break;
                        case NodeIdentifier.Not:
                            AddNode(new Not { Position = pos });
                            break;
                        case NodeIdentifier.Nand:
                            AddNode(new Nand(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.Nor:
                            AddNode(new Nor(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.Xnor:
                            AddNode(new Xnor(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.Adder:
                            AddNode(new Adder(inputCount) { Position = pos });
                            break;
                        case NodeIdentifier.SRLatch:
                            AddNode(new SRLatch { Position = pos });
                            break;
                        case NodeIdentifier.Timer:
                            uint interval = br.ReadUInt32();
                            AddNode(new Timer { Position = pos, Interval = interval });
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                int wireCount = br.ReadInt32();
                for (int i = 0; i < wireCount; i++)
                {
                    Node node1 = Nodes[br.ReadInt32()];
                    Node node2 = Nodes[br.ReadInt32()];
                    int inputIndex = br.ReadInt32();
                    int outputIndex = br.ReadInt32();

                    Wire(node1, node2, inputIndex, outputIndex);
                }
            }
        }
        public void Save(string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(path)))
            {
                // NODES
                bw.Write("CIRCUITZ"); // Magic word
                bw.Write(Nodes.Count); // Node count
                foreach (Node n in Nodes)
                {
                    bw.Write((uint)n.Type); // Node type
                    bw.Write(n.InputCount); // Input count
                    bw.Write(n.OutputCount); // Output count
                    // Position
                    bw.Write(n.Position.X);
                    bw.Write(n.Position.Y);
                    // Extra specific node data
                    switch (n)
                    {
                        case Constant constant:
                            bw.Write(constant.Value);
                            break;
                        case Timer timer:
                            bw.Write(timer.Interval);
                            bw.Write(timer.Value);
                            break;
                    }
                }

                // WIRES
                bw.Write(Wires.Count);
                foreach (Wire w in Wires)
                {
                    bw.Write(Nodes.IndexOf(w.Input));
                    bw.Write(Nodes.IndexOf(w.Output));
                    bw.Write(w.InputIndex);
                    bw.Write(w.OutputIndex);
                }

                bw.Flush();
            }
        }

        public void Reset()
        {
            Wires.Clear();
            Nodes.Clear();
        }
    }
}