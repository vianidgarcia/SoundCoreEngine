using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundCoreEngine.Models;
using SoundCoreEngine.OwnStructures;

namespace SoundCoreEngine.Motor
{
    public class BenchmarkService
    { 
        public const int DefaultInsertions = 20_000;

        /// <summary>
        /// Measures, with Stopwatch, the cost of "n" intermediate insertions (position 1)
        /// on the 3 structures: CustomLinkedList (PlayNext),
        /// LinkedList<T> (AddAfter the first node) and List<T> (Insert(1)).
        /// </summary>
        public BenchmarkResults Execute(int n = DefaultInsertions)
        {
            var random = new Random(42);
            var sw = new Stopwatch();

            var testCustomList = new SimpleLinkedList<Track>();
            testCustomList.AddLast(new Track(0, "Head", "DJ", 120, 200));
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                testCustomList.PlayNext(new Track(i, $"Track {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long customListTime = sw.ElapsedMilliseconds;

            var testLinkedList = new LinkedList<Track>();
            testLinkedList.AddLast(new Track(0, "Head", "DJ", 120, 200));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                var track = new Track(i, $"Track {i}", "DJ", random.Next(100, 150), 180);
                if (testLinkedList.First == null) testLinkedList.AddFirst(track);
                else testLinkedList.AddAfter(testLinkedList.First, track);
            }
            sw.Stop();
            long linkedListTime = sw.ElapsedMilliseconds;

            var testList = new List<Track> { new Track(0, "Head", "DJ", 120, 200) };
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testList.Insert(1, new Track(i, $"Track {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long listTime = sw.ElapsedMilliseconds;

            return new BenchmarkResults(n, customListTime, linkedListTime, listTime);
        }
    }
}
