using SoundCoreEngine.Models;
using SoundCoreEngine.OwnStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCoreEngine.Motor
{
    public class PlaybackQueueManager
    {
        private readonly SimpleLinkedList<Track> _customQueue = new();
        private readonly LinkedList<Track> _linkedListQueue = new();
        private readonly List<Track> _listQueue = new();

        public StructureType ActiveStructure { get; set; } = StructureType.CustomList;

        /// <summary>Fires after any operation that changes the queue, allowing the UI to refresh.</summary>
        public event Action? QueueUpdated;

        public Track? PlayingTrack { get; private set; }

        public IEnumerable<Track> GetActiveQueue() => ActiveStructure switch
        {
            StructureType.CustomList => _customQueue,
            StructureType.
            LinkedListNative => _linkedListQueue,
            StructureType.
            ListNative => _listQueue,
            _ => throw new NotSupportedException()
        };

        public int TotalTracks => ActiveStructure switch
        {
            StructureType.CustomList => _customQueue.Count,
            StructureType.LinkedListNative => _linkedListQueue.Count,
            StructureType.ListNative => _listQueue.Count,
            _ => 0
        };

        public void EnqueueAtEnd(Track track)
        {
            switch (ActiveStructure)
            {
                case StructureType.CustomList:
                    _customQueue.AddLast(track);
                    break;
                case StructureType.LinkedListNative:
                    _linkedListQueue.AddLast(track);
                    break;
                case StructureType.ListNative:
                    _listQueue.Add(track);
                    break;
            }
            QueueUpdated?.Invoke();
        }

        public void PlayNext(Track track)
        {
            switch (ActiveStructure)
            {
                case StructureType.CustomList:
                    _customQueue.PlayNext(track);
                    break;
                case StructureType.LinkedListNative:
                    if (_linkedListQueue.First == null)
                        _linkedListQueue.AddFirst(track);
                    else
                        _linkedListQueue.AddAfter(_linkedListQueue.First, track);
                    break;
                case StructureType.ListNative:
                    _listQueue.Insert(0, track); // Inserta al inicio para que sea la siguiente
                    break;
            }
            QueueUpdated?.Invoke();
        }

        public Track AdvanceTrack()
        {
            Track pista;
            switch (ActiveStructure)
            {
                case StructureType.CustomList:
                    pista = _customQueue.AdvanceTrack();
                    break;
                case StructureType.LinkedListNative:
                    if (_linkedListQueue.First == null) throw new InvalidOperationException();
                    pista = _linkedListQueue.First.Value;
                    _linkedListQueue.RemoveFirst();
                    break;
                case StructureType.ListNative:
                    if (_listQueue.Count == 0) throw new InvalidOperationException();
                    pista = _listQueue[0];
                    _listQueue.RemoveAt(0);
                    break;
                default:
                    throw new NotSupportedException();
            }

            PlayingTrack = pista;
            QueueUpdated?.Invoke();
            return pista;
        }

        public void Invert()
        {
            switch (ActiveStructure)
            {
                case StructureType.CustomList:
                    _customQueue.Invert();
                    break;
                case StructureType.LinkedListNative:
                    var temporal = new List<Track>(_linkedListQueue);
                    temporal.Reverse();
                    _linkedListQueue.Clear();
                    foreach (var p in temporal) _linkedListQueue.AddLast(p);
                    break;
                case StructureType.ListNative:
                    _listQueue.Reverse();
                    break;
            }
            QueueUpdated?.Invoke();
        }

        public void OrderByBpm()
        {
            switch (ActiveStructure)
            {
                case StructureType.CustomList:
                    var ordenadaPropia = new SimpleLinkedList<Track>();
                    foreach (var pista in _customQueue)
                        ordenadaPropia.InsertOrdered(pista, (a, b) => a.Bpm.CompareTo(b.Bpm));
                    _customQueue.Clear();
                    foreach (var p in ordenadaPropia) _customQueue.AddLast(p);
                    break;
                case StructureType.LinkedListNative:
                    var ordenadas = _linkedListQueue.OrderBy(p => p.Bpm).ToList();
                    _linkedListQueue.Clear();
                    foreach (var p in ordenadas) _linkedListQueue.AddLast(p);
                    break;
                case StructureType.ListNative:
                    _listQueue.Sort((a, b) => a.Bpm.CompareTo(b.Bpm));
                    break;
            }
            QueueUpdated?.Invoke();
        }

        public void PurgeDuplicatesByTitle()
        {
            switch (ActiveStructure)
            {
                case StructureType.CustomList:
                    _customQueue.RemoveDuplicates((a, b) =>
                        a.Title.Equals(b.Title, StringComparison.OrdinalIgnoreCase));
                    break;
                case StructureType.LinkedListNative:
                    var unicosLL = _linkedListQueue.DistinctBy(p => p.Title).ToList();
                    _linkedListQueue.Clear();
                    foreach (var p in unicosLL) _linkedListQueue.AddLast(p);
                    break;
                case StructureType.ListNative:
                    var unicosL = _listQueue.DistinctBy(p => p.Title).ToList();
                    _listQueue.Clear();
                    _listQueue.AddRange(unicosL);
                    break;
            }
            QueueUpdated?.Invoke();
        }

        /// <summary>Loads seed data into all 3 structures at once (so that the radio button switch is consistent).</summary>
        public void LoadSeedData(IEnumerable<Track> tracks)
        {
            foreach (var p in tracks)
            {
                _customQueue.AddLast(p);
                _linkedListQueue.AddLast(p);
                _listQueue.Add(p);
            }
            QueueUpdated?.Invoke();
        }

    }
}
