using System;
using System.Windows;
using System.Windows.Controls;
using TwoPointsLib.Interfaces;
using TwoPointsLib.Models;
using TwoPointsLib.Collections;
using TwoPointsLib.Logic;
using TwoPointsLib.Graphics;

namespace TwoPointsLib
{
    /// <summary>
    /// Class is responsible for main algorithm flow. 
    /// </summary>
    public class PixelManager : IPixelManager
    {
        private IPixel _startPixel;
        private IPixel _endPixel;
        private readonly Canvas _canvas;
        private readonly int _width;
        private readonly int _height;
        private readonly IIncidenceLists _incidenceLists;
        private readonly IBFS _bfs;
        private readonly IPixelsSets _pixelsSets;
        private readonly IDraw _drawing;

        private PixelManager(Canvas canvas)
        {
            _canvas = canvas;
            _width = Convert.ToInt32(canvas.Width);
            _height = Convert.ToInt32(canvas.Height);
            _pixelsSets = PixelsSets.Create(_width, _height);
            _incidenceLists = IncidenceLists.Create(_pixelsSets);
            _bfs = BFS.Create();
            _drawing = Draw.Create();
        }

        public static PixelManager CreateInstance(Canvas canvas)
        {
            return new PixelManager(canvas);
        }

        public void UserClick(Point point)
        {
            try
            {
                if (_startPixel == null)
                {
                    _startPixel = Pixel.Create(point);
                    _pixelsSets.CheckPixelUsed(_startPixel);
                }
                else if (_endPixel == null)
                {
                    _endPixel = Pixel.Create(point);
                    _pixelsSets.CheckPixelUsed(_endPixel);
                    _bfs.FindPath(_startPixel, _endPixel, _pixelsSets, _incidenceLists);
                    _drawing.DrawLine(_pixelsSets, _canvas);
                    _incidenceLists.RemoveFromLists(_pixelsSets);
                    ClearSelectedPixels();
                }
            }
            catch
            {
                ClearSelectedPixels();
                throw;
            }
            finally 
            {
                _pixelsSets.PixelsToDraw.Clear();
            }
        }

        public void ClearCanvas() 
        {
            _canvas.Children.Clear();
        }

        private void ClearSelectedPixels()
        {
            _startPixel = null;
            _endPixel = null;
        }

    }
}
