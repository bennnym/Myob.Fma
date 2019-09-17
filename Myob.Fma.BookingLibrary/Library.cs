using System;
using System.Collections.Generic;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary
{
    public class Library
    {
        private readonly List<IResource> _resources;

        public Library(List<IResource> resources)
        {
            _resources = resources;
        }

        public bool IsResourceAvailable(int id)
        {
            return true;
        }
    }
}