﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaupjcFirst
{
    public class IntegerList : IIntegerList
    {
        private int?[] _internalStorage;

        public IntegerList()
        {
            _internalStorage = new int?[4];
        }

        public IntegerList(int sizeCount)
        {
            _internalStorage = new int?[sizeCount];
        }

        public void Add(int item)
        {
            if (Count == _internalStorage.Length)
            {
                var newInternalStorage = new int?[_internalStorage.Length + 4];
                for (var position = 0; position < Count; position++)
                {
                    newInternalStorage[position] = _internalStorage[position];
                }
                newInternalStorage[Count] = item;
                _internalStorage = newInternalStorage;
            }
            else
            {
                _internalStorage[Count] = item;
            }
            Count++;
        }
        public bool Remove(int item)
        {
            for (var index = 0; index < Count; index++)
            {
                if (_internalStorage[index] == item)
                    return RemoveAt(index);
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();
            if (_internalStorage.Length - Count == 5)
            {
                var newInternalStorage = new int?[_internalStorage.Length - 1];
                for (var position = 0; position < Count; position++)
                {
                    if (position == index)
                        continue;
                    newInternalStorage[position > index ? position - 1 : position] = _internalStorage[position];
                }
                _internalStorage = newInternalStorage;
            }
            else
            {
                for (var position = index; position < Count - 1; position++)
                {
                   _internalStorage[position] = _internalStorage[position + 1];
                }
                _internalStorage[Count - 1] = null;
            }
            Count--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();
            return _internalStorage[index].Value;
        }

        public int IndexOf(int item)
        {
            for (var index = 0; index < Count; index++)
            {
                if (_internalStorage[index] == item)
                    return index;
            }
            return -1;
        }

        public int Count { get; private set; } = 0;

        public void Clear()
        {
            _internalStorage = new int?[4];
            Count = 0;
        }

        public bool Contains(int item)
        {
            foreach (var element in _internalStorage)
            {
                if (element == item)
                    return true;
            }
            return false;
        }

    }
}
