﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace gfoidl.DataCompression.Wrappers
{
#pragma warning disable CS1591
    public readonly struct ArrayWrapper<T> : IList<T>
    {
        private readonly T[] _array;
        //---------------------------------------------------------------------
        public ArrayWrapper(T[]? array) => _array = array ?? throw new ArgumentNullException(nameof(array));
        //---------------------------------------------------------------------
        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }
        //---------------------------------------------------------------------
        public int Count => _array.Length;
        //---------------------------------------------------------------------
        public bool IsReadOnly                        => throw new NotSupportedException();
        public void Add(T item)                       => throw new NotSupportedException();
        public void Clear()                           => throw new NotSupportedException();
        public bool Contains(T item)                  => throw new NotSupportedException();
        public void CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException();
        public IEnumerator<T> GetEnumerator()         => throw new NotSupportedException();
        public int IndexOf(T item)                    => throw new NotSupportedException();
        public void Insert(int index, T item)         => throw new NotSupportedException();
        public bool Remove(T item)                    => throw new NotSupportedException();
        public void RemoveAt(int index)               => throw new NotSupportedException();
        IEnumerator IEnumerable.GetEnumerator()       => throw new NotSupportedException();
    }
#pragma warning restore CS1591
}
