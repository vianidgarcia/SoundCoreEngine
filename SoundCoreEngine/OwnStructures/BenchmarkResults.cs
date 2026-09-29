using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Daniela Vianey Garcia Padilla - I25050363 - 28 Sept 2026

namespace SoundCoreEngine.OwnStructures
{
    public record BenchmarkResults(
    int Insertions,
    long MillisecondsCustomList,
    long MillisecondsLinkedList,
    long MillisecondsList)
    {
        public string Conclusion =>
           $"En {Insertions:N0} inserciones intermedias, la Lista Enlazada Propia " +
        $"({MillisecondsCustomList} ms) y LinkedList<T> ({MillisecondsLinkedList} ms) " +
        $"superan a List<T> ({MillisecondsList} ms) porque reconectan referencias " +
        $"en O(1) en lugar de ejecutar Array.Copy en cada inserción.";
    }
}
