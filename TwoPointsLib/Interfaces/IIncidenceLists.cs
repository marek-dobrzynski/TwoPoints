using System.Collections.Generic;

namespace TwoPointsLib.Interfaces
{
    public interface IIncidenceLists
    {
        Dictionary<int, List<int>> Lists { get; }
        void RemoveFromLists(IPixelsSets pixelsSets);
    }
}
