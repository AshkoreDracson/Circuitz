using Circuitz.Properties;
using Elementary;
using System.Drawing;
using System.Linq;

namespace Circuitz.Nodes
{
    public class Xor : Node
    {
        public override string Name => "XOR";
        public override NodeIdentifier Type => NodeIdentifier.Xor;

        public override int InputCount
        {
            set => Inputs = new bool[value];
        }
        public override Image Icon => Resources.Node_XOR;

        public Xor(int inCount) : base(inCount, 1)
        {
            inCount.ClampMin(2);
            Inputs = new bool[inCount];
        }

        public override void Update()
        {
            base.Update();
            Outputs[0] = Inputs.Count(b => b) == 1;
        }
    }
}
