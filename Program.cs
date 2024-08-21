using System;
using SplashKitSDK;


// prepared by aiden eyles(103736081)

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            // Initialize a window
            SplashKit.OpenWindow("Shape Drawer", 800, 600);

            // Create a new Drawing with an initial background color
            Drawing myDrawing = new Drawing(Color.LightGray);

            // Set up the game loop
            do
            {
                // Handle events
                SplashKit.ProcessEvents();

                // Check if the user has clicked the left mouse button
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Get the current mouse pointer location
                    Point2D mousePoint = SplashKit.MousePosition();

                    // Create a new Shape at the mouse position
                    Shape newShape = new Shape
                    {
                        X = (float)mousePoint.X, // Explicitly cast double to float
                        Y = (float)mousePoint.Y, // Explicitly cast double to float
                        Color = Color.Blue // Optional: Set a color for the new shape
                    };

                    // Add the new shape to the drawing
                    myDrawing.AddShape(newShape);
                }

                // Check if the user has clicked the right mouse button
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    // Get the current mouse pointer location
                    Point2D mousePoint = SplashKit.MousePosition();

                    // Select shapes at the current mouse pointer position
                    myDrawing.SelectShapesAt(mousePoint);
                }

                // Check if the space bar is pressed
                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    // Generate a new random color
                    Color randomColor = SplashKit.RandomColor();

                    // Change the background color of the drawing
                    myDrawing.Background = randomColor;
                }

                // Check if the Delete or Backspace key is pressed
                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    // Get the list of selected shapes
                    List<Shape> selectedShapes = myDrawing.SelectedShapes();

                    // Remove all selected shapes from the drawing
                    foreach (Shape shape in selectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                // Draw the current state of the drawing
                myDrawing.Draw();

                // Check if the user wants to exit
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}

