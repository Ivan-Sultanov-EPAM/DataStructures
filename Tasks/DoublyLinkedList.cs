using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> _head;
        private int _length;

        public DoublyLinkedList()
        {
            _head = null;
        }

        public int Length => _length;

        public void Add(T e)
        {
            if (_head == null)
            {
                _head = new Node<T>(e);
            }
            else
            {
                _head.Add(e);
            }

            _length++;
        }

        public void AddAt(int index, T e)
        {
            throw new NotImplementedException();
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index > _length - 1)
                throw new NotImplementedException();

            return _head.GetAt(index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Node<T>
    {
        private T _data;
        public Node<T> next;
        //public Node<T> previous;
        private int _index;

        public Node(T data, int index = 0)
        {
            _data = data;
            _index = index;
        }

        public void Add(T value)
        {
            if (next == null)
            {
                next = new Node<T>(value, _index++);
            }
            else
            {
                next.Add(value);
            }
        }

        public T GetAt(int index)
        {
            if (index == _index)
            {
                return _data;
            }

            return next.GetAt(index);
        }
    }
}
