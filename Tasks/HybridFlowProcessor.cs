using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _storage;

        public T Dequeue()
        {
            if (_storage == null)
            {
                throw new InvalidOperationException();
            }

            return _storage.RemoveAt(_storage.Length - 1);
        }

        public void Enqueue(T item)
        {
            _storage ??= new DoublyLinkedList<T>
            {
                item
            };

            _storage.AddAt(0, item);
        }

        public T Pop()
        {
            if (_storage == null)
            {
                throw new InvalidOperationException();
            }

            return _storage.RemoveAt(0);
        }

        public void Push(T item)
        {
            _storage ??= new DoublyLinkedList<T>
            {
                item
            };

            _storage.AddAt(0, item);
        }
    }
}
