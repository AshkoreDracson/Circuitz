namespace Circuitz.Nodes
{
    public enum NodeIdentifier : uint
    {
        None = 0,
        Constant = 1,
        And = 2,
        Or = 3,
        Xor = 4,
        Buffer = 5,
        Not = 6,
        Nand = 7,
        Nor = 8,
        Xnor = 9,
        Adder = 10,
        SRLatch = 11,
        Timer = 12
    }
}
