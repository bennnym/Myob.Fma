namespace Myob.Fma.BookingLibrary.Resources
{
    public class Book : IResource
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Isbn { get; set; }
    }
}