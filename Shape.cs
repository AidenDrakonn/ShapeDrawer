using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected; // New field to track selection

        public Shape()
        {
            _color = Color.Green;
            _x = 0;
            _y = 0;
            _width = 100;
            _height = 100;
            _selected = false; // Default to not selected
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public void Draw()
        {
            // Draw the shape itself
            Color drawColor = _selected ? Color.Red : _color;
            SplashKit.FillRectangle(drawColor, _x, _y, _width, _height);

            // Draw the outline if the shape is selected
            if (_selected)
            {
                DrawOutline();
            }
        }

        public bool isAt(Point2D pt)
        {
            if (pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public bool IsAt(Point2D pt)
        {
            float px = (float)pt.X;
            float py = (float)pt.Y;

            return px >= _x && px <= _x + _width && py >= _y && py <= _y + _height;
        }

        public void DrawOutline()
        {
            // Define outline color
            Color outlineColor = Color.Black;

            // Define the thickness of the outline
            const int outlineThickness = 6; // set to be 5 + 1 as per task req

            // Draw the outline rectangle
            SplashKit.DrawRectangle(outlineColor,
                _x - outlineThickness, // X position adjusted to be 6 pixels before the shape
                _y - outlineThickness, // Y position adjusted to be 6 pixels before the shape
                _width + (2 * outlineThickness), // Width adjusted to include 6 pixels on each side
                _height + (2 * outlineThickness));// Height adjusted to include 6 pixels on each side       
        }
    }
}
