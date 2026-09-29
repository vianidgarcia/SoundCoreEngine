using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Daniela Vianey Garcia Padilla - I25050363 - 28 Sept 2026

namespace SoundCoreEngine.Audio
{
    public interface IAudioMetadataProvider
    {
        // Tries to read the BPM embedded in the file tags (ID3v2, Vorbis, etc.).
        // Returns null if the file does not contain the data or the tag is unreadable.
        int? ReadBpm(string filePath);
        int ReadDurationSeconds(string filePath);

        string? ReadTitle(string filePath);

        string? ReadArtist(string filePath);
    }
}
