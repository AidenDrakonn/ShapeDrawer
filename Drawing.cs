using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    using System.Collections.Generic;
    using SplashKitSDK;

    public class Drawing
    {
        // Private fields
        private readonly List<Shape> _shapes;
        private Color _background;

        // Public property for Background
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        // Constructor with background color parameter
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        // Constructor without parameters
        public Drawing() : this(Color.White) // Default background color is White
        {
        }

        // Read-only property for ShapeCount
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        // Method to add a shape
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // Method to remove a shape
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }

        // Method to draw all shapes
        public void Draw()
        {
            SplashKit.ClearScreen(_background);

            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }

            SplashKit.RefreshScreen();
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        public List<Shape> SelectedShapes()
        {
            List<Shape> result = new List<Shape>();

            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    result.Add(s);
                }
            }

            return result;
        }
    }
}
