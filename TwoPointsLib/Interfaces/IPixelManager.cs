using System.Windows;

namespace TwoPointsLib.Interfaces
{
    public interface IPixelManager
    {
        void UserClick(Point point);
        void ClearCanvas();
    }
}
