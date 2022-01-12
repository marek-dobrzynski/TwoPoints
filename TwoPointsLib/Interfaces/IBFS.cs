namespace TwoPointsLib.Interfaces
{
    public interface IBFS
    {
        void FindPath(IPixel startPixel, IPixel endPixel, IPixelsSets pixelsSets, IIncidentLists incidentLists);
    }
}
