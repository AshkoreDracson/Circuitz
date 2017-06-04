using Circuitz.Properties;
using Elementary;
using System.Drawing;
using System.Linq;

namespace Circuitz.Nodes
{
    public class Or : Node
    {
        public override string Name => "OR";

        public override int InputCount
        {
            set => Inputs = new bool[value];
        }
        public override Image Icon => Resources.Node_OR;

        public Or(int inCount) : base(inCount, 1)
        {
            inCount.ClampMin(2);
            Inputs = new bool[inCount];
        }

        public override void Update()
        {
            base.Update();
            Outputs[0] = Inputs.Any(b => b);
        }
    }
}
