using System;

namespace Myob.Fma.BookingLibrary
{
    public class Library
    {
        private readonly string _name;
        private readonly string _address;

        public Library(string name, string address)
        {
            _name = name;
            _address = address;
        }
    }
}