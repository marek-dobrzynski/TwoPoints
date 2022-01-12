using System.Windows.Controls;

namespace TwoPointsLib.Interfaces
{
    public interface IDraw
    {
        void DrawLine(IPixelsSets pixelsSets, Canvas canvas);
    }
}
