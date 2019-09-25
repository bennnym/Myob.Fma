using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.BookingLibrary.Resources
{
    public class ResourceManager
    {
        private readonly List<IResource> _inventory = new List<IResource>();

        public void AddResourceToInventory(IResource resource)
        {
            _inventory.Add(resource);
        }
        
        public void RemoveResourceToInventory(IResource resource)
        {
            _inventory.Remove(resource);
        }

        public bool IsResourceAvailable(int id)
        {
            return _inventory.Any(r => r.Id == id && r.IsAvailable);
        }

        public void CheckoutResource(int resourceId)
        {
            var resource = GetResource(resourceId);
            resource.IsAvailable = false;
        }

        public IResource GetResource(int resourceId)
        {
            return _inventory.Find(r => r.Id == resourceId);
        }
    }
}