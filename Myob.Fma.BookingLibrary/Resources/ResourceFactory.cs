using System;

namespace Myob.Fma.BookingLibrary.Resources
{
    public class ResourceFactory
    {
        public static IResource CreateResource(ResourceType resourceType, string name, int id)
        {
            switch (resourceType)
            {
                case ResourceType.Book:
                    return new Book()
                    {
                        Id = id,
                        Name = name,
                        ResourceType = resourceType,
                    };
                case ResourceType.BoardGame:
                    return new BoardGame()
                    {
                        Id = id,
                        Name = name,
                        ResourceType = resourceType,
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(resourceType), resourceType, null);
            }
        }
    }
}