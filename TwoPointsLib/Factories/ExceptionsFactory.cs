using System;

namespace TwoPointsLib.Factories
{
    /// <summary>
    /// Simple factory technique to make sure that all Exceptions are created in one place for better manage. 
    /// </summary>
    public static class ExceptionsFactory
    {
        public static Exception NoPathFound() 
        {
            return new Exception("Path not found! Clear canvas to start again.");
        }
        public static Exception PixelVisited()
        {
            return new Exception("You clicked on the line! Try in not used area.");
        }
    }
}
