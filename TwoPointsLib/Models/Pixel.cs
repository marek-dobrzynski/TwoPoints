using System;
using System.Windows;
using TwoPointsLib.Interfaces;

namespace TwoPointsLib.Models
{
    /// <summary>
    /// Main model used in application.
    /// </summary>
    public class Pixel : IPixel
    {
        public int Id { get; private set; }
        public int CoordinateX { get; private set; }
        public int CoordinateY { get; private set; }

        public static Pixel Create(Point point)
        {
            return new Pixel
            {
                CoordinateX = Convert.ToInt32(point.X),
                CoordinateY = Convert.ToInt32(point.Y)
            };
        }

        public static Pixel Create(int x, int y, int id)
        {
            return new Pixel
            {
                CoordinateX = x,
                CoordinateY = y,
                Id = id
            };
        }

        
    }
}
