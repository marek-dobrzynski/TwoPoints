using System.Collections.Generic;
using System.Linq;
using TwoPointsLib.Factories;
using TwoPointsLib.Interfaces;

namespace TwoPointsLib.Logic
{
    /// <summary>
    /// BFS(breadth-first search) is an algorithm for searching graph structure (in application I define canvas as graph where every 
    /// pixel is node ). Algorithm finds all paths from one node to other, if any exists. Algorithm works on created IncidenceLists. 
    /// Algorithm arrays :
    ///     _visited -> to find out if current node was visted(used), if so take another
    ///     _previous -> to hold current node (pixel) neighbours
    ///     _distance -> to hold the distance from start node to every visted node
    /// </summary>
    public class BFS : IBFS
    {
        private int[] _distance;
        private Dictionary<int, List<int>> _previous;
        private int _startPixelId;
        private int _endPixelId;
        private bool[] _visited;
        private Queue<int> _queue;
        private int _current;

        /// <summary>
        /// Method uses Queue to search all nodes(Pixels). Every loop add neneighbour of current node to Queue until Queue is empty.
        /// </summary>
        public void FindPath(IPixel startPixel, IPixel endPixel, IPixelsSets pixelsSets, IIncidenceLists incidenceLists)
        {
            try
            {
                _startPixelId = pixelsSets.GetPixelId(startPixel);
                _endPixelId = pixelsSets.GetPixelId(endPixel);

                Run(startPixel, pixelsSets, incidenceLists);

                List<int> kolekcja;

                while (_endPixelId != _startPixelId)
                {
                    pixelsSets.Visited[_endPixelId] = true;
                    pixelsSets.PixelsToDraw.Add(pixelsSets.Pixels[_endPixelId]);
                    try
                    {
                        kolekcja = _previous[_endPixelId].FindAll(x => pixelsSets.Visited[x] == false);
                        _endPixelId = kolekcja.OrderBy(x => _distance[x]).First();
                    }
                    catch
                    {
                        throw ExceptionsFactory.NoPathFound();
                    }
                }
                pixelsSets.PixelsToDraw.Add(pixelsSets.Pixels[_startPixelId]);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Method uses Queue to search all nodes(Pixels). Method loops through neneighbours of current node and enqueue them.
        /// Next dequeue node(pixel) to set it visted and set distance. Method works as long as Queue is not empty.
        /// </summary>
        private void Run(IPixel startPixel, IPixelsSets pixelsArrays, IIncidenceLists incidentLists)
        {
            _visited = new bool[pixelsArrays.IdsCounter];
            _distance = new int[pixelsArrays.IdsCounter];
            _previous = new Dictionary<int, List<int>>();
            _current = _startPixelId;
            _distance[_current] = 0;
            _queue = new Queue<int>();

            _visited[_startPixelId] = true;
            _queue.Enqueue(_current);

            try
            {
                while (_queue.Count != 0)
                {
                    _current = _queue.Dequeue();

                    foreach (var neighbour in incidentLists.Lists[_current])
                    {

                        if (!_previous.ContainsKey(neighbour))
                            _previous.Add(neighbour, new List<int>());
                        if (!_visited[neighbour] && incidentLists.Lists.ContainsKey(neighbour))
                        {
                            _queue.Enqueue(neighbour);
                            _distance[neighbour] = _distance[_current] + 1;
                            _visited[neighbour] = true;
                        }
                        if (!_previous[neighbour].Contains(_current))
                            _previous[neighbour].Add(_current);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static BFS Create()
        {
            return new BFS();
        }
    }
}
