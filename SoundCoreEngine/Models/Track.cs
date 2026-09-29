using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Daniela Vianey Garcia Padilla - I25050363 - 28 Sept 2026

namespace SoundCoreEngine.Models
{
    public record Track(int Id, string Title, string Artist, int Bpm, int Seconds, string FilePath = "")
    {
        public override string ToString() =>
               $"[ID: {Id:D3}] {Title} - {Artist} | {Bpm} BPM ({Seconds}s)";
    }
}