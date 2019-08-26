namespace Myob.Fma.GameOfLife.Cells
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

        public CellPosition Position { get; set; }

    }

}
