using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class MyList<T> : IMyList<T>
    {
        private const int _defaultCapacity = 4;
        private T[] _items;
        private int _size;

        static readonly T[] _emptyArray = new T[0];

        

        public MyList()
        {
            _items = _emptyArray;
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _items[index];
            }
        }

        public void Add(T item)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size++] = item;
        }

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }

        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
    }
    {
    internal static class ListExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] array = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i];
            }

            return array;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            foreach (int item in list.GetArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(MyClass<List<int>>.FactoryMethod());
        }
    }
}
}