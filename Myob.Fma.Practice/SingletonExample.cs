using System;

namespace Myob.Fma.Practice
{
    public class SingletonExample
    {
        private int _counter;
        private SingletonExample()
        {
            _counter++;
            Console.WriteLine(_counter);
        }
        
        private static SingletonExample instance = new SingletonExample();
        public static SingletonExample Instance => instance;
    }
}