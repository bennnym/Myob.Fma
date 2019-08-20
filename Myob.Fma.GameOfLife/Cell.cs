namespace Myob.Fma.GameOfLife
{
    public class Cell : ICell
    {

        public Cell(bool cellState)
        {
            CellState = cellState;
            Symbol = CellState ? " @ " : " . ";
        }
        
        public int NeighboursAlive {  get; set; }
        public bool CellState { get; set; }
        public string Symbol { get; set; }

        public int[] Position { get; set; }

    }

}
