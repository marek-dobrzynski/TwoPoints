using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TwoPointsLib.Interfaces;

namespace TwoPointsLib.Graphics
{
    /// <summary>
    /// Class is resposible for drawing operations.
    /// </summary>
    public class Draw : IDraw
    {
        private Brush _brush;

        public void DrawLine(IPixelsSets pixelsSets, Canvas canvas) 
        {
            try
            {
                _brush = PickColor();

                foreach (IPixel pixel in pixelsSets.PixelsToDraw)
                {
                    DrawPixel(pixel, canvas);
                }
            }
            catch
            {
                throw;
            }
           
        }
        private void DrawPixel(IPixel node, Canvas canvas)
        {
            try
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 3,
                    Height = 3,
                    Fill = _brush
                };
                ellipse.SnapsToDevicePixels = true;
                ellipse.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

                Canvas.SetLeft(ellipse, node.CoordinateX);
                Canvas.SetTop(ellipse, node.CoordinateY);
                canvas.Children.Add(ellipse);
            }
            catch
            {
                throw;
            }

        }

        private Brush PickColor()
        {
            try
            {
                var properties = typeof(Brushes).GetProperties()
                .Where(x => x.Name.ToLower().Contains("dark")
                    || x.Name.ToLower().Contains("red")
                    || x.Name.ToLower().Contains("black")
                ).ToArray();

                int random = new Random().Next(properties.Length);
                return (Brush)properties[random].GetValue(null, null);
            }
            catch 
            {
                throw;
            }
            
        }

        public static Draw Create() 
        {
            return new Draw();
        }
    }
}
