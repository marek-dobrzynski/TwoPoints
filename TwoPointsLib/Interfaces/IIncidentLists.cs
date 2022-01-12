using System.Collections.Generic;

namespace TwoPointsLib.Interfaces
{
    public interface IIncidentLists
    {
        Dictionary<int, List<int>> Lists { get; }
        void RemoveFromLists(IPixelsSets pixelsSets);
    }
}
