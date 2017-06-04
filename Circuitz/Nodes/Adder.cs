using Elementary;
using System.Drawing;

namespace Circuitz.Nodes
{
    public class Adder : Node
    {
        public override string Name => "Adder";

        public override int InputCount
        {
            set => Inputs = new bool[value.Clamp(1, 32)];
        }

        public uint Value
        {
            get
            {
                uint val = 0;
                for (int i = 0; i < InputCount; i++)
                {
                    val |= Inputs[i] ? 0x8000_0000u : 0u;

                    if (i < InputCount - 1)
                        val = val >> 1;
                }
                val = val >> 32 - InputCount;
                return val;
            }
        }

        public override Size Size
        {
            get
            {
                int maxBranches = InputCount > OutputCount ? InputCount : OutputCount;
                int width = (InputCount * 4).Clamp(32, 128);

                if (maxBranches < 2)
                    return new Size(width, 32);
                return new Size(width, 32 + 16 * (maxBranches - 2));
            }
        }

        public override string Text => Value.ToString();

        public Adder(int inCount) : base(inCount, 0)
        {
            inCount = inCount.Clamp(1, 32);
            Inputs = new bool[inCount];
        }
    }
}