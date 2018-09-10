//
//
//


namespace MarceRover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class Plateau
    {
        public int Id { get; set; }

        public int MinimumXPoint { get; set; }

        public int MaximumXPoint { get; set; }

        public int MinimumYPoint { get; set; }

        public int MaximumYPoint { get; set; }

        public Dictionary<int, Rover> RoverCollection = new Dictionary<int, Rover>();

        /// <summary>
        /// To set the plateau boundary points
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="minXpoint">Min Xpoint</param>
        /// <param name="minYPoint">Min YPoint</param>
        /// <param name="maxXPoint">Max XPoint</param>
        /// <param name="maxYPoint">Max YPoint</param>
        public void SetPlateau(int id, int minXpoint, int minYPoint, int maxXPoint, int maxYPoint)
        {
            Id = id;
            MinimumXPoint = minXpoint;
            MaximumXPoint = maxXPoint;
            MinimumYPoint = minYPoint;
            MaximumYPoint = maxYPoint;
        }
        
        /// <summary>
        /// Get all Rovers in this area
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Rover> GetAllRoversInPlateau()
        {
            return RoverCollection;
        }

        /// <summary>
        /// Add rover into Plateau
        /// </summary>
        /// <param name="rover"></param>
        /// <returns></returns>
        public int AddRoverIntoPlateau(Rover rover)
        {
            int roverKey = RoverCollection.Count + 1;
            RoverCollection.Add(roverKey, rover);
            return roverKey;
        }

        public Rover GetRover(int key)
        {
            return RoverCollection[key];
        }

        /// <summary>
        /// check if it is a boundary point or not
        /// </summary>
        /// <param name="points">current position</param>
        /// <param name="plateau">plateau</param>
        /// <returns>boolian</returns>
        public bool IsNotBoundaryPoint(int[] points, Plateau plateau)
        {
            bool isNotBoundary = points[0] >= plateau.MinimumXPoint && points[0] <= plateau.MaximumXPoint && points[1] >= plateau.MinimumYPoint && points[1] <= plateau.MaximumYPoint ? true : false;
            return isNotBoundary;
        }

        /// <summary>
        /// To check the given position of rover value is exsist in given plateau
        /// </summary>
        /// <param name="points">points</param>
        /// <param name="plateau">plateau</param>
        /// <returns>boolian</returns>
        public bool IsAnyRoverInThisPoint(int[] points, Dictionary<int, Rover> plateau)
        {
            bool isAnyRoverInThisPoint;
            try
            {
                int roverCount = (from roverCollection in plateau where points[0] == roverCollection.Value.XPoint && points[1] == roverCollection.Value.YPoint select roverCollection.Value.Id).ToList<int>().Count;
                isAnyRoverInThisPoint = roverCount != 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }

            return isAnyRoverInThisPoint;
        }

        /// <summary>
        /// To check any rover in this position
        /// </summary>
        /// <param name="rover">rover</param>
        /// <param name="plateau">plateau</param>
        /// <returns>boolian</returns>
        public bool IsAnyRoverInThisPoint(Rover rover, Dictionary<int, Rover> plateau)
        {
            bool isAnyRoverInThisPoint = false;
            try
            {
                int roverCount = (from getRover in plateau where getRover.Value.Id != rover.Id && getRover.Value.XPoint == rover.XPoint && getRover.Value.YPoint == rover.YPoint select getRover.Value.Id).ToList<int>().Count;
                isAnyRoverInThisPoint = roverCount != 0 ? true : false;

            }
            catch (Exception)
            {
                throw;
            }

            return isAnyRoverInThisPoint;
        }

    }
}
