using System.Collections.Generic;
using TwoPointsLib.Factories;
using TwoPointsLib.Interfaces;
using TwoPointsLib.Models;

namespace TwoPointsLib.Collections
{

    /// <summary>
    /// Class is holder for collecions used in PixelManager's algorithm flow
    /// </summary>
    public class PixelsSets : IPixelsSets
    {
        public int IdsCounter { get; private set; }
        public int[,] CoordinatesToId { get; private set; }
        public Dictionary<int, IPixel> Pixels { get; private set; }
        public List<IPixel> PixelsToDraw { get; private set; }
        public bool[] Visited { get; set; }

        public PixelsSets(int width, int height)
        {
            try
            {
                PixelsToDraw = new List<IPixel>();
                IdsCounter = 0;
                CoordinatesToId = new int[width + 1, height + 1];
                Pixels = new Dictionary<int, IPixel>();
                for (int j = 0; j <= height; j++)
                {
                    for (int i = 0; i <= width; i++)
                    {
                        Pixels.Add(IdsCounter, Pixel.Create(i, j, IdsCounter));
                        CoordinatesToId[i, j] = IdsCounter;
                        IdsCounter++;
                    }
                }
                Visited = new bool[IdsCounter];
            }
            catch
            {

                throw;
            }
            
        }

        public int GetPixelId(IPixel pixel) 
        {
            return CoordinatesToId[pixel.CoordinateX, pixel.CoordinateY];
        }

        public void CheckPixelUsed(IPixel pixel)
        {
            try
            {
                if (Visited[GetPixelId(pixel)])
                    throw ExceptionsFactory.PixelVisited();
            }
            catch 
            {
                throw;
            }
            
        }

        public static PixelsSets Create(int width, int height)
        {
            return new PixelsSets(width, height);
        }
    }
}
