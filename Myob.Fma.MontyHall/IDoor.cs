namespace Myob.Fma.MontyHall
{
    public interface IDoor
    {
        bool ContainsPrize { get; set; }
        bool IsUsersSelection { get; set; }
    }
}