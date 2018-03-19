using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlideSaver
{
    /// <summary>
    /// Represents a mode for traversing a sequence of elements
    /// </summary>
    public enum SequenceMode
    {
        /// <summary>
        /// Traverses the elements by name in ascending order
        /// </summary>
        Name,
        /// <summary>
        /// Traverses the elements by name in descending order
        /// </summary>
        NameDescending,
        /// <summary>
        /// Traverses the elements by date in ascending order
        /// </summary>
        Date,
        /// <summary>
        /// Traverses the elements by date in descending order
        /// </summary>
        DateDescending,
        /// <summary>
        /// Traverses the elements randomly where repeating can occur
        /// </summary>
        Random,
        /// <summary>
        /// Traverses the elements in shuffle mode where the entire list is shuffled and each element is traversed once
        /// <para>The entire list is shuffled again when the final element in the previous sequence is traversed</para>
        /// </summary>
        Shuffle,
    }
}
