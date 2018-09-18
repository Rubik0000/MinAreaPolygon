using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinArea
{
    public interface IDrawable
    {
        void Draw(Graphics grp, Pen pen);
    }
}
