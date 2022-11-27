using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> _head;

        public DoublyLinkedList()
        {
            _head = null;
        }

        public int Length => _head.GetLength();

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
        }

        public void AddAt(int index, T e)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            _head.AddValueAt(index, e);
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index > Length - 1)
                throw new IndexOutOfRangeException();

            return _head.GetValueAt(index);
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
            var result = ElementAt(index);

            if (index < 0 || index > Length - 1)
                throw new IndexOutOfRangeException();

            if (index == 0 && _head.next == null)
            {
                _head = null;
            }
            else
            {
                _head.RemoveNodeAt(index);
            }

            return result;
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

        public Node(T data)
        {
            _data = data;
        }

        public int GetLength(int length = 1)
        {
            if (next != null)
            {
                length = next.GetLength(length + 1);
            }

            return length;
        }

        public void Add(T value)
        {
            if (next == null)
            {
                next = new Node<T>(value);
            }
            else
            {
                next.Add(value);
            }
        }

        public T GetValueAt(int index, int position = 0)
        {
            return index == position ? _data : next.GetValueAt(index, position + 1);
        }

        public void AddValueAt(int index, T value, int position = 0)
        {
            if (index == position)
            {
                var newNext = new Node<T>(_data)
                {
                    next = next
                };

                _data = value;
                next = newNext;

                return;
            }

            if (next == null)
            {
                next = new Node<T>(value);
                return;
            }

            next.AddValueAt(index, value, position + 1);
        }

        public void RemoveNodeAt(int index, int position = 0)
        {
            if (index == position && next != null)
            {
                _data = next._data;
                next = next.next;
                return;
            }

            if (index == position + 1 && next is { next: null })
            {
                next = null;
                return;
            }

            next?.RemoveNodeAt(index, position + 1);
        }
    }
}
