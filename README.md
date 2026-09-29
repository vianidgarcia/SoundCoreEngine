# SoundCore Engine GUI

Proyecto evaluativo de la asignatura **Estructura de Datos** — TecNM Campus Monclova, Ingeniería en Informática, 3er semestre.

Compara una **Lista Enlazada Simple genérica implementada desde cero** contra las colecciones nativas de .NET (`LinkedList<T>` y `List<T>`) en un escenario realista de cola de reproducción para DJs, midiendo el rendimiento con `Stopwatch` ante inserciones intermedias masivas.

**Estudiante:** Daniela Vianey García Padilla - I25050363
**Calificación:** 100
---

## 1. Objetivo

Demostrar, tanto en teoría como en la práctica, por qué una lista enlazada resuelve en **O(1)** una inserción intermedia (operación *"Up Next"* de un DJ) mientras que un arreglo dinámico (`List<T>`) degrada a **O(n)** por el corrimiento de memoria (`Array.Copy`) que exige mantener sus elementos contiguos.

## 2. Stack técnico

| Componente | Tecnología |
|---|---|
| Lenguaje / Framework | C# / .NET 8 |
| UI | Windows Forms |
| Reproducción de audio | [NAudio](https://github.com/naudio/NAudio) |
| Lectura de metadatos (BPM, título, artista) | [TagLibSharp](https://github.com/mono/taglib-sharp) |

## 3. Arquitectura

Proyecto único (`SoundCoreEngine.csproj`) organizado en carpetas/namespaces por responsabilidad:

```
SoundCoreEngine/
├── Models/       → Track (record): Id, Title, Artist, Bpm, Seconds, FilePath
├── OwnStructures/→ Node<T>, SimpleLinkedList<T>, BenchmarkResult
├── Audio/        → IAudioMetadataProvider, TagLibReader, NAudioPlayer
├── Motor/        → StructureType, PlaybackQueueManager, BenchmarkService
└── UI/           → MainForm (.cs + .Designer.cs), Program.cs
```

La capa `OwnStructures` está **totalmente desacoplada** de WinForms y de NAudio: no tiene ninguna referencia a ellos, por lo que el compilador impide físicamente que la lógica de la lista enlazada dependa de la interfaz gráfica.

## 4. `SimpleLinkedList<T>` — implementación desde cero

Construida exclusivamente con manipulación directa de punteros (`Node<T>.Next`). **Prohibido y no utilizado**: arrays internos, `List<T>`, `LinkedList<T>` o `HashSet<T>` como estructuras auxiliares.

| Método | Complejidad | Técnica |
|---|---|---|
| `AddLast(T)` | O(n) | Recorrido hasta el último nodo |
| `PlayNext(T)` | O(1) | Inserción inmediata tras la cabeza ("Up Next") |
| `AdvanceTrack()` | O(1) | Remueve y retorna la cabeza; lanza `InvalidOperationException` si la lista está vacía |
| `Reverse()` | O(n) tiempo, O(1) memoria auxiliar | **3 punteros** (previo, actual, siguiente) — reorienta enlaces in-place, sin listas temporales |
| `InsertOrdered(T, Comparison<T>)` | O(n) | Inserción ordenada (usado para ordenar por BPM) |
| `RemoveDuplicates(Func<T,T,bool>)` | O(n²) tiempo, O(1) espacio | **Puntero corredor** (runner), sin `HashSet` |
| `IEnumerable<T>` | — | `yield return`, habilita `foreach` y data binding con `DataGridView` |

## 5. Decisión de paquetes NuGet

- **NAudio**: estándar de facto en .NET para reproducción de audio (WASAPI/DirectSound, decodificación MP3/WAV).
- **TagLibSharp**: se usa para leer el BPM **ya embebido** en los tags del archivo (ID3v2 `TBPM`, Vorbis Comments), en vez de calcularlo por análisis de señal (DSP). La mayoría de pistas exportadas desde software de DJ (Rekordbox, Serato) ya traen este dato, por lo que leerlo es O(1), confiable y no distrae del objetivo académico del reto.
- **Alternativa evaluada y descartada**: `BpmFinder` (NuGet) — versión 0.1.0 sin historial ni adopción, riesgo inaceptable para un entregable calificado. `NWaves` (DSP maduro, 100k+ descargas) queda documentado como vía posible si en el futuro se requiere detección real de tempo por FFT/autocorrelación en vez de leer el tag.

## 6. Interfaz gráfica

- **Registrar pista**: Título, Artista, BPM (60-220), Duración, selector de estructura activa (Lista Propia / `LinkedList<T>` / `List<T>`) y carga de archivos reales (`OpenFileDialog` + TagLibSharp).
- **Acciones**: Encolar al Final, Reproducir Siguiente, Avanzar Pista, Invertir (in-place), Ordenar por BPM, Purgar Duplicados.
- **Reproducción**: Play (siempre sobre la cabeza de la cola activa) / Pause / Stop, barra de progreso y tiempo transcurrido, con **auto-avance** a la siguiente pista cuando una termina sola.
- **Cola de reproducción**: `DataGridView` en tiempo real (Posición, ID, Título/Artista, BPM, Duración) + indicador "Now Playing".
- **Manejo de excepciones**: cola vacía controlada con `MessageBox`, sin caídas de la aplicación.

## 7. Benchmark de estrés

Botón "Iniciar Prueba de Rendimiento" + consola de resultados. Mide con `Stopwatch` el costo de insertar **20,000 elementos en posición intermedia** (`PlayNext` / `Insert(1)`) sobre las 3 estructuras:

1. `SimpleLinkedList<T>` — reconecta 2 referencias, **O(1)** por inserción.
2. `LinkedList<T>` nativa — también **O(1)**, como control de referencia.
3. `List<T>` — sufre **O(n)** por `Array.Copy` y reasignación de búfer en cada inserción.

**Resultado esperado**: la lista propia y `LinkedList<T>` completan la prueba en milisegundos de un solo dígito; `List<T>` tarda órdenes de magnitud más — evidencia empírica de la teoría Big-O.

```
=== RESULTADOS DE ESTRÉS (20,000 INSERCIONES INTERMEDIAS) ===
• Lista Enlazada Propia (Nodos):   X ms   [O(1) por reconexión]
• .NET LinkedList<T>:              X ms   [O(1) nativa]
• .NET List<T> (Arreglo Dinámico): X ms   [O(n) por Array.Copy]
```
*(pegar aquí la salida real de una corrida antes de entregar)*

> **Nota para el video:** el guion de entrega pide correr la prueba con **25,000** pistas — cambia el valor en `numInseccionesBenchmark` antes de grabar esa sección.

## 8. Casos de prueba formales

| ID | Operación / Escenario | Pasos | Resultado esperado en pantalla |
|---|---|---|---|
| CP-01 | Inserción al final | Registrar "Track 1" (120 BPM) y presionar **+ Enqueue at End**. | Se agrega en la última fila del `dgvCola` sin alterar las anteriores. |
| CP-02 | Prioridad "Up Next" | Registrar "Track VIP" y presionar **Play Next**. | Se posiciona en la fila 2 (inmediatamente detrás de la cabeza actual). |
| CP-03 | Avanzar pista | Clic en **Advance Track**. | `lblNowPlaying` se actualiza con la nueva cabeza; desaparece la primera fila del grid. |
| CP-04 | Inversión in-place | Cola con BPM `[100, 110, 120]`, presionar **Reverse List (In-Place)**. | El grid queda `[120, 110, 100]` sin crear estructuras temporales. |
| CP-05 | Curva ascendente de BPM | Insertar desordenado: `128, 115, 140, 120`. Presionar **Sort by BPM Curve**. | El grid reordena de menor a mayor tempo: `115 → 120 → 128 → 140`. |
| CP-06 | Purga de duplicados | Insertar dos pistas con el mismo título (ej. "Strobe"). Presionar **Purge Duplicates**. | Se conserva la primera aparición; la réplica se elimina sin romper enlaces. |
| CP-07 | Manejo de excepciones | Presionar **Advance Track** con la cola en 0 elementos. | `MessageBox` controlado ("End of Setlist"), sin congelamiento ni caída de la app. |
| CP-08 | Reproducción real | Cargar un archivo con **Load Files...**, presionar **Play**. | Suena el audio, la barra de progreso avanza y el tiempo transcurrido se actualiza. |
| CP-09 | Auto-avance | Dejar sonar una pista corta hasta el final sin intervenir. | Al terminar, la app avanza sola a la siguiente cabeza y continúa reproduciendo. |

## 9. Rúbrica de evaluación (referencia)

| Dimensión | Peso |
|---|---|
| Estructuras propias (punteros, nodos, los 6 métodos) | 40% |
| Interfaz gráfica WinForms | 25% |
| Integración con `LinkedList<T>` / `List<T>` nativas | 20% |
| Benchmark y análisis de resultados | 15% |

## 10. Cómo ejecutar

1. Abrir `SoundCoreEngine.sln` en Visual Studio 2022+.
2. Restaurar paquetes NuGet (`NAudio`, `TagLibSharp`).
3. Compilar y ejecutar (`F5`). El proyecto apunta a `net8.0-windows`.

## 11. Limitaciones conocidas

- El relleno del `ProgressBar` de reproducción usa el color por defecto del tema de Windows — WinForms no permite recolorearlo sin dibujo personalizado (owner-draw).
- La detección de BPM depende de que el archivo tenga el tag `TBPM` embebido; si no lo tiene, se usa un valor por defecto de 120 BPM.
