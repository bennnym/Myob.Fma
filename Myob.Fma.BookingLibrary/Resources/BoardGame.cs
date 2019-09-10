namespace Myob.Fma.BookingLibrary.Resources
{
    public class BoardGame : IResource
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ResourceType ResourceType { get; set; }
    }
}