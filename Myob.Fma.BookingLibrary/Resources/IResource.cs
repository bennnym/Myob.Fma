namespace Myob.Fma.BookingLibrary.Resources
{
    public interface IResource
    {
        string Name { get; set; }
        int Id { get; set; }

        ResourceType ResourceType { get; set; }
    }
}