﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace LimaVector.Shape
{
    public abstract class IThreePointShape : AShape
    {
        public abstract Point[] GetPoints(Point startPoint, Point middlePoint, Point endPoint);
    }
}
