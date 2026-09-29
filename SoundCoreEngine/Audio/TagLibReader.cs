using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCoreEngine.Audio
{
    public class TagLibReader : IAudioMetadataProvider
    {
        public int? ReadBpm(string filePath)
        {
            try
            {
                using var file = TagLib.File.Create(filePath);
                uint bpm = file.Tag.BeatsPerMinute;
                return bpm > 0 ? (int)bpm : null;
            }
            catch (Exception)
            {
                // Corrupt file, unsupported format, or no read permissions.
                return null;
            }
        }

        public int ReadDurationSeconds(string filePath)
        {
            try
            {
                using var file = TagLib.File.Create(filePath);
                return (int)file.Properties.Duration.TotalSeconds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public string? ReadTitle(string filePath)
        {
            try
            {
                using var file = TagLib.File.Create(filePath);
                return string.IsNullOrWhiteSpace(file.Tag.Title) ? null : file.Tag.Title;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string? ReadArtist(string filePath)
        {
            try
            {
                using var file = TagLib.File.Create(filePath);
                return file.Tag.Performers.Length > 0 ? file.Tag.Performers[0] : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
