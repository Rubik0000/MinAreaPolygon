using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinArea
{
    /// <summary>
    /// An interface to draw objects
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draws the object
        /// </summary>
        /// <param name="grp">A graphcis component</param>
        /// <param name="pen">A pen to draw</param>
        void Draw(Graphics grp, Pen pen);
    }
}
