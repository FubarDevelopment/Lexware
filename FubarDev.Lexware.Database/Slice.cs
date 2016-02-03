// <copyright file="Slice.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;

namespace FubarDev.Lexware.Database
{
    internal class Slice<T> : IList<T>, IReadOnlyList<T>
    {
        private readonly T[] _array;

        private readonly int _offset;

        public Slice(Slice<T> slice)
            : this(slice, 0, slice.Count)
        {
        }

        public Slice(Slice<T> slice, int offset, int length)
        {
            if (offset + length > slice.Count)
                throw new InvalidOperationException();
            _offset = slice._offset + offset;
            Count = length;
            _array = slice._array;
        }

        public Slice(T[] array)
            : this(array, 0, array.Length)
        {
        }

        public Slice(T[] array, int offset, int length)
        {
            if (offset + length > array.Length)
                throw new InvalidOperationException();
            _array = array;
            _offset = offset;
            Count = length;
        }

        public int Count { get; }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                return _array[_offset + index];
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                _array[_offset + index] = value;
            }
        }

        public int IndexOf(T item)
        {
            var comparer = Comparer<T>.Default;
            var index = 0;
            foreach (var thisItem in this)
            {
                if (comparer.Compare(thisItem, item) == 0)
                    return index;
                index += 1;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var thisItem in this)
                array[arrayIndex++] = thisItem;
        }

        public void CopyFrom(IEnumerable<T> source)
        {
            var targetOffset = 0;
            foreach (var item in source)
                this[targetOffset++] = item;
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)new ArraySegment<T>(_array, _offset, Count)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray(int startIndex)
        {
            if (startIndex >= Count)
                throw new InvalidOperationException();
            return ToArray(startIndex, Count - startIndex);
        }

        public T[] ToArray(int startIndex, int length)
        {
            if (startIndex + length > Count)
                throw new InvalidOperationException();
            var temp = new T[length];
            Array.Copy(_array, _offset + startIndex, temp, 0, length);
            return temp;
        }
    }
}
