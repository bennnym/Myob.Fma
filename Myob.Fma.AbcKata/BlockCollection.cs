using System.Collections.Generic;

namespace Myob.Fma.AbcKata
{
    public class BlockCollection
    {
        public List<Block> Blocks { get; }

        public BlockCollection()
        {
            Blocks = new List<Block>();
        }

        public void AddBlock(Block block)
        {
            Blocks.Add(block);
        }

        public void RemoveBlock(Block block)
        {
            Blocks.Remove(block);
        }
    }
}