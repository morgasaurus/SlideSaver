using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlideSaver
{
    /// <summary>
    /// Represents configuration options for the slide show
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Gets or sets the base path used to find photos for the slideshow
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether to include subdirectories of the base path for pictures
        /// </summary>
        public bool IncludeSubdirectories { get; set; }

        /// <summary>
        /// Gets or sets the sequence mode of the slide show
        /// </summary>
        public SequenceMode SequenceMode { get; set; }
    }
}
