namespace Myob.Fma.Foundational.Games
{
    public class TimesTable : IGame
    {
        public string Play()
        {
            return OutputTimesTableEntries();
        }

        private int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        private string OutputTimesTableEntries(int start = 1, int stop = 1)
        {
            if (start == 13)
            {
                start = 1;
                stop += 1;
            }
            
            if (start == 12 && stop == 12)
            {
                return $"{start} x {stop} = {Multiply(start, stop)}";
            }
            
            return $"{start} x {stop} = {Multiply(start, stop)}, {OutputTimesTableEntries(start + 1, stop)}";
        }
    }
}