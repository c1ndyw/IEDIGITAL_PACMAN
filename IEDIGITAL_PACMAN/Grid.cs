﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEDIGITAL_PACMAN
{
    /// <summary>
    /// The Grid is the grid upon which the pacman are placed.
    /// It is able to place,move,rotate to left, rotate to right, display the state of the pacman that is placed.
    /// </summary>
    public class Grid
    {
        private const int width = 5;

        /// <summary>
        /// Grid constructor, a grid has a 5x5 wide
        /// </summary>
        public Grid() { }

        /// <summary>
        /// The width of the grid.
        /// </summary>
        /// <value>The width of the grid.</value>
        /// <returns>The width of the grid.</returns>
        public int Width() { return width; }

        /// <summary>
        /// Change the coordinate of the pacman in the grid
        /// </summary>
        /// <param name="newX">x coordinate</param>
        /// <param name="newY">y coordinate</param>
        /// <param name="newDir">direction of pacman</param>
        /// <param name="p">the pacman</param>
        public void Place(Pacman p, int newX, int newY, String newDir)
        {
            p.SetPacmanX(newX);
            p.SetPacmanY(newY);
            p.SetPacmanDir(newDir);
        }

        /// <summary>
        /// Move allows for the pacman to be placed on the grid by one coordinate 
        /// depending the pacman's direction
        /// </summary>
        /// <param name="p">the pacman</param>
        public void Move(Pacman p)
        {
            Direction currentDirection = p.GetDirection();
            switch (currentDirection)
            {
                case Direction.NORTH:
                    if (p.PacmanY() + 1 < width)
                    {
                        p.SetPacmanY(p.PacmanY() + 1);
                    }
                    break;
                case Direction.EAST:
                    if (p.PacmanX() + 1 < width)
                    {
                        p.SetPacmanX(p.PacmanX() + 1);
                    }
                    break;
                case Direction.SOUTH:
                    if (p.PacmanY() - 1 > -1)
                    {
                        p.SetPacmanY(p.PacmanY() - 1);
                    }
                    break;
                case Direction.WEST:
                    if (p.PacmanX() - 1 > -1)
                    {
                        p.SetPacmanX(p.PacmanX() - 1);
                    }
                    break;
            }
        }

        /// <summary>
        /// RotateLeft allows for the pacman to rotate the direction 
        /// to the left with the left orders : NORTH - WEST - SOUTH - EAST
        /// </summary>
        /// <param name="p">the pacman</param>
        public void RotateLeft(Pacman p)
        {
            Direction _direction = p.GetDirection();
            switch (_direction)
            {
                case Direction.NORTH:
                    _direction = Direction.WEST;
                    break;
                default:
                    _direction = _direction - 1;
                    break;
            }
            p.SetPacmanDir(_direction.ToString());

        }

        /// <summary>
        /// rotateRight allows for the pacman to rotate the direction 
        /// to the right with the right orders : NORTH - EAST - SOUTH - WEST
        /// </summary>
        /// <param name="p">the pacman</param>
        public void RotateRight(Pacman p)
        {
            Direction _direction = p.GetDirection();
            switch (_direction)
            {
                case Direction.WEST:
                    _direction = Direction.NORTH;
                    break;
                default:
                    _direction = _direction + 1;
                    break;
            }
            p.SetPacmanDir(_direction.ToString());
        }

        /// <summary>
        /// Display current state (coordinate and direction) of the pacman in the grid.
        /// </summary>
        /// <param name="p">the pacman</param>
        public void Report(Pacman p)
        {
            Console.WriteLine("OUTPUT: " + p.PacmanX().ToString() + "," + p.PacmanY().ToString() + "," + p.PacmanDirection().ToString());
        }
    }
}
