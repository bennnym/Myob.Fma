using System;
using System.Linq;

namespace Myob.Fma.AbcKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var blocks = new BlockCollection();

            var block1 = new Block('B', 'O');
            var block2 = new Block('X', 'K');
            var block3 = new Block('D', 'Q');
            var block4 = new Block('C', 'P');
            var block5 = new Block('N', 'A');
            var block6 = new Block('G', 'T');
            var block7 = new Block('R', 'E');
            var block8 = new Block('T', 'G');
            var block9 = new Block('Q', 'D');
            var block10 = new Block('F', 'S');
            var block11 = new Block('J', 'W');
            var block12 = new Block('H', 'U');
            var block13 = new Block('V', 'I');
            var block14 = new Block('A', 'N');
            var block15 = new Block('O', 'B');
            var block16 = new Block('E', 'R');
            var block17 = new Block('F', 'S');
            var block18 = new Block('L', 'Y');
            var block19 = new Block('P', 'C');
            var block20 = new Block('Z', 'M');

            blocks.AddBlock(block1);
            blocks.AddBlock(block2);
            blocks.AddBlock(block3);
            blocks.AddBlock(block4);
            blocks.AddBlock(block5);
            blocks.AddBlock(block6);
            blocks.AddBlock(block7);
            blocks.AddBlock(block8);
            blocks.AddBlock(block9);
            blocks.AddBlock(block10);
            blocks.AddBlock(block11);
            blocks.AddBlock(block12);
            blocks.AddBlock(block13);
            blocks.AddBlock(block14);
            blocks.AddBlock(block15);
            blocks.AddBlock(block16);
            blocks.AddBlock(block17);
            blocks.AddBlock(block18);
            blocks.AddBlock(block19);
            blocks.AddBlock(block20);
            

            Console.WriteLine(CanMakeWord("A", blocks));
            Console.WriteLine(CanMakeWord("BARK", blocks));
            Console.WriteLine(CanMakeWord("BOOK", blocks));
            Console.WriteLine(CanMakeWord("TREAT", blocks));
            Console.WriteLine(CanMakeWord("COMMON", blocks));
            Console.WriteLine(CanMakeWord("SQUAD", blocks));
            Console.WriteLine(CanMakeWord("CONFUSE", blocks));
        }

        static bool CanMakeWord(string wordToCheck, BlockCollection blockCollection)
        {
            var word = wordToCheck.ToCharArray().ToList();

            foreach (var block in blockCollection.Blocks)
            {
                var firstLetterIndex = word.IndexOf(block.Sides[0]);
                var secondLetterIndex = word.IndexOf(block.Sides[1]);

                if (firstLetterIndex >= 0)
                {
                    word.RemoveAt(firstLetterIndex);
                }
                else if (secondLetterIndex >= 0)
                {
                    word.RemoveAt(secondLetterIndex);
                }

                if (word.Count == 0) return true;
            }

            return false;
        }
    }
}