using Xunit;

namespace Myob.Fma.MontyHallTests
{
    public class TddSimulation
    {
        [Fact]
        public void Check_That_Staying_Is_Worse_Than_Changing()
        {
            // Arrange
            var simulation = new GameSimulation();
            
            // Assert
            Assert.True(simulation.ShouldIChange());
        }
    }

    public class GameSimulation
    {
        public bool ShouldIChange()
        {
            return GetStayPercentage() < GetChangePercentage();
        }
        public decimal GetStayPercentage()
        {
            return 0.33M;
        }
        
        public decimal GetChangePercentage()
        {
            return 0.66M;
        }
    }
}