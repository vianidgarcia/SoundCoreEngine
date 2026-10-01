
using System.Threading;
using System.Threading.Tasks;

namespace SoundCoreEngine.Audio
{
    /// <summary>
    /// Contrato para estimadores de BPM.
    /// </summary>
    public interface IBpmAnalyzer
    {
        /// <summary>
        /// Estima BPM del archivo. Devuelve null si no pudo estimarse.
        /// El double es confianza en [0..1].
        /// </summary>
        Task<(int bpm, double confidence)?> EstimateBpmAsync(string filePath, CancellationToken ct = default);
    }
}