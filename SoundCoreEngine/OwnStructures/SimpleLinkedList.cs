using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Daniela Vianey Garcia Padilla - I25050363 - 28 Sept 2026

namespace SoundCoreEngine.OwnStructures
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        public Node<T>? Head { get; private set; }
        public int Count { get; private set; }

        public bool IsEmpty => Head == null;

        // 1. Insert at the end: O(n)
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);
            if (IsEmpty)
            {
                Head = newNode;
            }
            else
            {
                var current = Head!;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }

        // 2. Up Next: immediate insertion after the head: O(1)
        public void PlayNext(T value)
        {
            var newNode = new Node<T>(value);
            if (IsEmpty)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head!.Next;
                Head.Next = newNode;
            }
            Count++;
        }

        // 3. Dequeue current track (remove head): O(1)
        public T AdvanceTrack()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The playback queue is empty.");
            T value = Head!.Value;
            Head = Head.Next;
            Count--;
            return value;
        }

        // 4. In-place inversion: O(n) time, O(1) auxiliary memory
        // 3-pointer technique: previous, current, next. Only redirects links.
        public void Invert()
        {
            Node<T>? previous = null;
            Node<T>? current = Head;

            while (current != null)
            {
                Node<T>? next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            Head = previous;
        }

        // 5. Ordered insertion by criterion (e.g., BPM): O(n)
        public void InsertOrdered(T value, Comparison<T> comparer)
        {
            var newNode = new Node<T>(value);

            if (IsEmpty || comparer(value, Head!.Value) < 0)
            {
                newNode.Next = Head;
                Head = newNode;
                Count++;
                return;
            }

            var current = Head;
            while (current.Next != null && comparer(value, current.Next.Value) >= 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            Count++;
        }

        // 6. Remove duplicates without external structures: O(n^2) time, O(1) space
        //ingles
        public void RemoveDuplicates(Func<T, T, bool> areEqual)
        {
            var current = Head;

            while (current != null)
            {
                var runner = current;
                while (runner.Next != null)
                {
                    if (areEqual(current.Value, runner.Next.Value))
                    {
                        runner.Next = runner.Next.Next;
                        Count--;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        // Enables foreach and clean data binding with DataGridView
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

