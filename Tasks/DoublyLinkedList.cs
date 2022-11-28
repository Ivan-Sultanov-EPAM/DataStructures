using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> _head;

        public DoublyLinkedList()
        {
            _head = null;
        }

        public int Length => _head?.GetLength() ?? throw new IndexOutOfRangeException();

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
            return new NodeEnum<T>(_head);
        }

        public void Remove(T item)
        {
            if (_head.GetValueAt(0).Equals(item) && Length == 1)
            {
                _head = null;
                return;
            }

            _head.Remove(item);
        }

        public T RemoveAt(int index)
        {
            var result = ElementAt(index);

            if (index < 0 || index > Length - 1)
                throw new IndexOutOfRangeException();

            if (index == 0 && Length == 1)
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
            return GetEnumerator();
        }
    }

    public class Node<T>
    {
        private T _data;
        private Node<T> _next;

        public Node(T data)
        {
            _data = data;
        }

        public int GetLength(int length = 1)
        {
            if (_next != null)
            {
                length = _next.GetLength(length + 1);
            }

            return length;
        }

        public void Add(T value)
        {
            if (_next == null)
            {
                _next = new Node<T>(value);
            }
            else
            {
                _next.Add(value);
            }
        }

        public T GetValueAt(int index, int position = 0)
        {
            return index == position ? _data : _next.GetValueAt(index, position + 1);
        }

        public void AddValueAt(int index, T value, int position = 0)
        {
            if (index == position)
            {
                var newNext = new Node<T>(_data)
                {
                    _next = _next
                };

                _data = value;
                _next = newNext;

                return;
            }

            if (_next == null)
            {
                _next = new Node<T>(value);
                return;
            }

            _next.AddValueAt(index, value, position + 1);
        }

        public void RemoveNodeAt(int index, int position = 0)
        {
            if (index == position && _next != null)
            {
                _data = _next._data;
                _next = _next._next;
                return;
            }

            if (index == position + 1 && _next is { _next: null })
            {
                _next = null;
                return;
            }

            _next?.RemoveNodeAt(index, position + 1);
        }

        public void Remove(T item)
        {
            if (_data.Equals(item) && _next != null)
            {
                _data = _next._data;
                _next = _next._next;
                return;
            }

            if (_next != null && _next._data.Equals(item) && _next._next == null)
            {
                _next = null;
                return;
            }

            _next?.Remove(item);
        }
    }

    public class NodeEnum<T> : IEnumerator<T>
    {
        private readonly Node<T> _node;
        private int _position = -1;

        public NodeEnum(Node<T> node)
        {
            _node = node;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _node.GetLength();
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current => _node.GetValueAt(_position);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
