using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector
{
    public class Canvas
    {
        private Bitmap _mainBitmap;
        private Bitmap _tmpBitmap;
        private bool MODE_REPAINT = false;
        public Bitmap Bitmap
        {
            get => MODE_REPAINT ? _tmpBitmap : _mainBitmap;
        }

        public Canvas(int width, int height)
        {
            _mainBitmap = new Bitmap(width, height);
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
        }

        public void Update()
        {
            _mainBitmap = _tmpBitmap;
            MODE_REPAINT = false;
            GC.Collect();
        }
        public void Clear()
        {
            _tmpBitmap = _mainBitmap = new Bitmap(_mainBitmap.Width, _mainBitmap.Height);
        }

        public void Duplicate()
        {
            MODE_REPAINT = true;
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
        }

    }
}
