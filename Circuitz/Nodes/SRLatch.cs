using Circuitz.Properties;
using System.Drawing;

namespace Circuitz.Nodes
{
    public class SRLatch : Node
    {
        public override Image Icon => Resources.Node_SRLatch;

        public SRLatch() : base(2, 2) { }

        public override void Update()
        {
            base.Update();

            // Do it 2 times for conformity
            for (int i = 0; i < 2; i++)
            {
                Outputs[0] = !(Inputs[0] || Outputs[1]);
                Outputs[1] = !(Inputs[1] || Outputs[0]);
            }
        }
    }
}