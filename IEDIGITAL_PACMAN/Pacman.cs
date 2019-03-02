using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEDIGITAL_PACMAN
{
    /// <summary>
    /// A pacman has all the details about itself. For example the x coordinate,
    /// the y coordinate, the direction. 
    /// </summary>
    public class Pacman
    {
        private int X;
        private int Y;
        private String direction;

        /// <summary>
        /// Pacman constructor, has a x and y coordinate, and direction
        /// </summary>
        public Pacman(string direction)
        {
            this.X = 0;
            this.Y = 0;
            this.direction = direction;
        }

        /// <summary>
        /// The x coordinate of the pacman
        /// </summary>
        /// <returns>the x coordinate of the ship</returns>
        public int PacmanX()
        {
            return this.X;
        }

        /// <summary>
        /// The y coordinate of the pacman
        /// </summary>
        /// <returns>the y coordinate of the ship</returns>
        public int PacmanY()
        {
            return this.Y;
        }

        /// <summary>
        /// The direction of the pacman
        /// </summary>
        /// <returns>the direction of the pacman</returns>
        public String PacmanDirection()
        {
            return this.direction;
        }

        /// <summary>
        /// Sets the x coordinate of pacman
        /// </summary>
        /// <value>The number between 0-4</value>
        public void setPacmanX(int x)
        {
            this.X = x;
        }

        /// <summary>
        /// Sets the y coordinate of pacman
        /// </summary>
        /// <value>The number between 0-4</value>
        public void setPacmanY(int y)
        {
            this.Y = y;
        }

        /// <summary>
        /// Sets the direction of pacman
        /// </summary>
        /// <value>The enum direction : NORTH,EAST,SOUTH,WEST</value>
        public void setPacmanDir(String direction)
        {
            this.direction = direction;
        }

        /// <summary>
        /// The direction in enum data type of the pacman
        /// </summary>
        /// <returns>the direction of the pacman</returns>
        public Direction getDirection()
        {
            Direction _direction;
            Enum.TryParse(direction, out _direction);
            return _direction;
        }

        /// <summary>
        /// The direction in string data type of the pacman
        /// </summary>
        /// <returns>the direction of the pacman</returns>
        public String getDirectionString()
        {
            return direction;
        }
    }
}
