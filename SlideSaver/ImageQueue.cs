using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlideSaver
{
    /// <summary>
    /// Represents a class that reads images in the background and queues them up in memory
    /// </summary>
    public class ImageQueue : IDisposable
    {
        /// <summary>
        /// Creates a new ImageQueue instance with the specified options
        /// </summary>
        /// <param name="folder">The base folder to draw images from</param>
        /// <param name="includeSubfolders">Flag indicating whether to include subfolders</param>
        /// <param name="sequenceMode">The sequence mode by which to traverse the list of files</param>
        /// <param name="limit">The limit of the number of files added to the queue</param>
        public ImageQueue(string folder, bool includeSubfolders, SequenceMode sequenceMode, int limit)
        {
            Folder = folder;
            IncludeSubfolders = includeSubfolders;
            SequenceMode = sequenceMode;
            Limit = limit;
            LoadImageFiles();
            EnqueueTimer = new Timer(QueueNextCallback, null, 50, 100);
        }

        private static readonly string[] ImageExtensions = { "png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff" };

        private string Folder;
        private bool IncludeSubfolders;
        SequenceMode SequenceMode;
        private int Limit;
        private List<string> ImageFiles;
        private int CurrentIndex;
        private object Lock = new object();
        private Random Rand = new Random();
        private Timer EnqueueTimer;

        private ConcurrentQueue<Image> Queue = new ConcurrentQueue<Image>();

        private void LoadImageFiles()
        {
            string[] files = Directory.GetFiles(Folder, "*.*", IncludeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            IEnumerable<string> images = files.Where(x => IsImageFile(x));

            // Order the list in various ways based on the sequence mode
            switch (SequenceMode)
            {
                case SequenceMode.Name:
                    ImageFiles = images.OrderBy(x => Path.GetFileName(x)).ToList();
                    break;
                case SequenceMode.NameDescending:
                    ImageFiles = images.OrderByDescending(x => Path.GetFileName(x)).ToList();
                    break;
                case SequenceMode.Date:
                    ImageFiles = images.OrderBy(x => File.GetCreationTime(x)).ToList();
                    break;
                case SequenceMode.DateDescending:
                    ImageFiles = images.OrderByDescending(x => File.GetCreationTime(x)).ToList();
                    break;
                case SequenceMode.Shuffle:
                    ImageFiles = images.OrderBy(x => Rand.Next()).ToList();
                    break;
                default:
                    ImageFiles = images.ToList();
                    break;
            }
            CurrentIndex = 0;
        }

        private bool IsImageFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            return ImageExtensions.Contains(path.Split('.').Last().ToLower());
        }

        private Image GetNextImage()
        {
            // For random we don't even need to concern ourselves with the index
            if (SequenceMode == SequenceMode.Random)
            {
                return LoadImage(ImageFiles[Rand.Next() % ImageFiles.Count]);
            }

            // Otherwise we need to support multithreading here for multiple monitors and shuffle the list if necessary
            string path = null;
            lock (Lock)
            {
                CurrentIndex++;
                if (CurrentIndex >= ImageFiles.Count)
                {
                    if (SequenceMode == SequenceMode.Shuffle)
                    {
                        ImageFiles = ImageFiles.OrderBy(x => Rand.Next()).ToList();
                    }

                    CurrentIndex = 0;
                }
                path = ImageFiles[CurrentIndex];
            }
            return LoadImage(path);
        }

        private Image LoadImage(string path)
        {
            // Here we do not care about errors the calling method will simply go to the next file
            try
            {
                return Image.FromFile(path);
            }
            catch
            {
                return null;
            }
        }

        private void QueueNextCallback(object state)
        {
            if (Queue.Count < Limit)
            {
                Image image = GetNextImage();
                if (image != null)
                {
                    Queue.Enqueue(image);
                }
            }
        }

        public Image Dequeue()
        {
            ThrowIfDisposed();
            Image image = null;
            if (Queue.TryDequeue(out image))
            {
                return image;
            }
            return null;
        }

        #region Dispose
        private bool Disposed;

        ~ImageQueue()
        {
            Dispose(false);
        }

        protected void ThrowIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("ImageQueue");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }

            EnqueueTimer.Dispose();

            if (disposing)
            {
                EnqueueTimer = null;
                Folder = null;
                Queue = null;
                Rand = null;
            }

            Disposed = true;
        }
        #endregion Dispose
    }
}
