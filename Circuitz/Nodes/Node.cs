using System;
using System.ComponentModel;
using System.Drawing;


namespace Circuitz.Nodes
{
    [DisplayName("Node")]
    public abstract class Node
    {
        private static uint _curID;
        [Category("Base")]
        public uint ID { get; }

        [Category("Base")]
        public virtual string Name => "Node";

        [Browsable(false)]
        public Board Board { get; set; }

        [Browsable(false)]
        public bool[] Inputs { get; protected set; }
        [Browsable(false)]
        public bool[] Outputs { get; protected set; }

        [DisplayName("Input count")]
        public virtual int InputCount
        {
            get => Inputs?.Length ?? 0;
            set { }
        }

        [DisplayName("Output count")]
        public virtual int OutputCount
        {
            get => Outputs?.Length ?? 0;
            set { }
        }

        public Point Position { get; set; }
        [Browsable(false)]
        public virtual Image Icon => null;
        [Browsable(false)]
        public virtual string Text => null;

        [Browsable(false)]
        public bool RequiresUpdate { get; set; }

        [Browsable(false)]
        public virtual Size Size
        {
            get
            {
                int maxBranches = InputCount > OutputCount ? InputCount : OutputCount;

                if (maxBranches < 2)
                    return new Size(32, 32);
                return new Size(32, 32 + 16 * (maxBranches - 2));
            }
        }

        [Browsable(false)]
        public Point Center
        {
            get
            {
                Size s = Size;
                return Position.Add(new Point(s.Width / 2, s.Height / 2));
            }
        }

        protected Node(int inCount, int outCount)
        {
            if (inCount < 0)
                throw new Exception("Input count must be equal or superior to 0");

            if (outCount < 0)
                throw new Exception("Output count must be equal or superior to 0");

            ID = _curID++;

            Inputs = new bool[inCount];
            Outputs = new bool[outCount];
        }

        public virtual void Update()
        {
            RequiresUpdate = false;
        }

        public bool HasInput(int index)
        {
            return index >= 0 && index < InputCount;
        }
        public bool HasOutput(int index)
        {
            return index >= 0 && index < OutputCount;
        }

        public Point GetInputPoint(int index)
        {
            Point p = Position;
            int offset = Size.Height / (InputCount + 1);
            int spacing = (Size.Height + offset / 2) / (InputCount + 1) * index;
            p.Offset(0, spacing + offset);
            return p;
        }
        public Point GetOutputPoint(int index)
        {
            Point p = Position;
            int offset = Size.Height / (OutputCount + 1);
            int spacing = (Size.Height + offset / 2) / (OutputCount + 1) * index;
            p.Offset(Size.Width, spacing + offset);
            return p;
        }

        public int? GetInputIndexAtPoint(Point p, float threshold = 12f)
        {
            for (int i = 0; i < InputCount; i++)
            {
                Point inputPoint = GetInputPoint(i);
                float distance = p.Distance(inputPoint);

                if (distance <= threshold)
                    return i;
            }
            return null;
        }
        public int? GetOutputIndexAtPoint(Point p, float threshold = 12f)
        {
            for (int i = 0; i < OutputCount; i++)
            {
                Point outputPoint = GetOutputPoint(i);
                float distance = p.Distance(outputPoint);

                if (distance <= threshold)
                    return i;
            }
            return null;
        }

        public bool Intersects(Point p)
        {
            return p.X >= Position.X && p.Y >= Position.Y && p.X < Position.X + Size.Width &&
                   p.Y < Position.Y + Size.Height;
        }
    }
}