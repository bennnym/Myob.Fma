namespace Myob.Fma.AbcKata
{
    public class Block
    {
        public  char[] Sides;
        
        public Block(char side1, char side2)
        {
            Sides = new [] {side1, side2};
        }
    }
}