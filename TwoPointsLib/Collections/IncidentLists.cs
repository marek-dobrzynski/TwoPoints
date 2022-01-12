using System.Collections.Generic;
using TwoPointsLib.Interfaces;

namespace TwoPointsLib.Collections
{
    /// <summary>
    /// Class is responsible for creating incident Lists. Indicident lists are usually used to present a graf structure. In my case 
    /// I used Dictionary. Every index(Pixel id) in dictionary holds his neighbours as collection of Pixels ids (List).
    /// </summary>
    public class IncidentLists : IIncidentLists
    {
        public Dictionary<int, List<int>> Lists { get; private set; }

        public IncidentLists(IPixelsSets pixelsSets)
        {
            try
            {
                Lists = new Dictionary<int, List<int>>();
                Init(pixelsSets);
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Method removes used Pixels to prevent use on the next BFS algorithm run.
        /// </summary>
        public void RemoveFromLists(IPixelsSets pixelsSets)
        {
            try
            {
                foreach (IPixel pixel in pixelsSets.PixelsToDraw)
                {
                    Lists[pixel.Id] = new List<int>();
                }
            }
            catch
            {
                throw;
            }
        }

        private void Init(IPixelsSets pixelsSets)
        {
            try
            {
                foreach (var pixel in pixelsSets.Pixels)
                {
                    Lists.Add(pixel.Key, new List<int>());
                    GetNeighbours(pixel.Value, pixelsSets);
                }
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Method create collection of neighbours for Pixel.
        /// </summary>
        private void GetNeighbours(IPixel pixel, IPixelsSets pixelsSets)
        {
            int leftNeighbour = pixel.CoordinateX - 1,
                rightNeighbour = pixel.CoordinateX + 1,
                topNeighbour = pixel.CoordinateY - 1,
                bottomNeighbour = pixel.CoordinateY + 1;

            try
            {
                if (leftNeighbour >= 0)
                {
                    Lists[pixel.Id].Add(pixelsSets.CoordinatesToId[leftNeighbour, pixel.CoordinateY]);
                }
                if (rightNeighbour <= pixelsSets.CoordinatesToId.GetLength(0) - 1)
                {
                    Lists[pixel.Id].Add(pixelsSets.CoordinatesToId[rightNeighbour, pixel.CoordinateY]);
                }
                if (topNeighbour >= 0)
                {
                    Lists[pixel.Id].Add(pixelsSets.CoordinatesToId[pixel.CoordinateX, topNeighbour]);
                }
                if (bottomNeighbour <= pixelsSets.CoordinatesToId.GetLength(1) - 1)
                {
                    Lists[pixel.Id].Add(pixelsSets.CoordinatesToId[pixel.CoordinateX, bottomNeighbour]);
                }
            }
            catch
            {
                throw;
            }
        }
        public static IncidentLists Create(IPixelsSets pixelsSets)
        {
            return new IncidentLists(pixelsSets);
        }

    }
}
