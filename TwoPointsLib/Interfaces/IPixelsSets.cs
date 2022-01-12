using System.Collections.Generic;

namespace TwoPointsLib.Interfaces
{
    public interface IPixelsSets
    {
        int IdsCounter { get; }
        int[,] CoordinatesToId { get; }
        Dictionary<int, IPixel> Pixels { get; }
        List<IPixel> PixelsToDraw { get;}
        bool[] Visited { get; set; }
        int GetPixelId(IPixel pixel);
        void CheckPixelUsed(IPixel pixel);
    }
}
