using Microsoft.VisualStudio.TestTools.UnitTesting;
using IEDIGITAL_PACMAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IEDIGITAL_PACMAN.Tests
{
    [TestClass()]
    public class GridTests
    {
        Grid _grid = new Grid();
        Pacman _pacman = new Pacman();
        

        [TestMethod()]
        public void unmatchingPattern_placeKeyword()
        {
            Boolean matchingPattern = false;
            String keyword = "PLACE 1,5,EA";
            String pattern = @"PLACE\s[0-4]\,[0-4]\,([NORTH]*|[EAST]*|[WEST]*|[SOUTH]*)$";
            if (Regex.Match(keyword, pattern, RegexOptions.IgnoreCase).Success)
            {
                //Console.WriteLine("regex entered");
                String[] Place_keyword = keyword.Split(' ');
                string[] placeWords = Place_keyword[1].Split(',');
                if ((Convert.ToInt16(placeWords[0]) > -1 && Convert.ToInt16(placeWords[0]) < 5) &&
                    (Convert.ToInt16(placeWords[1]) > -1 && Convert.ToInt16(placeWords[1]) < 5))
                {
                    int corX = Convert.ToInt16(placeWords[0]);
                    int corY = Convert.ToInt16(placeWords[1]);
                    String direction = placeWords[2];
                    matchingPattern = !matchingPattern;
                }
            }
            Assert.AreEqual(false, matchingPattern);
        }

        [TestMethod()]
        public void matchingRegex_placeKeyword()
        {
            Boolean matchingPattern = false;
            String keyword = "PLACE 1,2,WEST";
            String pattern = @"PLACE\s[0-4]\,[0-4]\,([NORTH]*|[EAST]*|[WEST]*|[SOUTH]*)$";
            if (Regex.Match(keyword, pattern, RegexOptions.IgnoreCase).Success)
            {
                //Console.WriteLine("regex entered");
                String[] Place_keyword = keyword.Split(' ');
                string[] placeWords = Place_keyword[1].Split(',');
                if ((Convert.ToInt16(placeWords[0]) > -1 && Convert.ToInt16(placeWords[0]) < 5) &&
                    (Convert.ToInt16(placeWords[1]) > -1 && Convert.ToInt16(placeWords[1]) < 5))
                {
                    int corX = Convert.ToInt16(placeWords[0]);
                    int corY = Convert.ToInt16(placeWords[1]);
                    String direction = placeWords[2];
                    matchingPattern = !matchingPattern;
                }
            }
            Assert.AreEqual(true, matchingPattern);
        }
     

        [TestMethod()]
        public void moveTest()
        {
            _pacman.setPacmanX (3);
            _pacman.setPacmanY(2);
            _pacman.setPacmanDir("WEST");
            Direction currentDirection = Direction.WEST;
            switch (currentDirection)
            {

                case Direction.NORTH:
                    if (_pacman.PacmanY() + 1 < 5)
                    {
                        _pacman.setPacmanY(_pacman.PacmanY() + 1);
                    }
                    break;
                case Direction.EAST:
                    if (_pacman.PacmanX() + 1 < 5)
                    {
                        _pacman.setPacmanX(_pacman.PacmanX() + 1);
                    }
                    break;
                case Direction.SOUTH:
                    if (_pacman.PacmanY() - 1 > -1)
                    {
                        _pacman.setPacmanY(_pacman.PacmanY() - 1);
                    }
                    break;
                case Direction.WEST:
                    if (_pacman.PacmanX() - 1 > -1)
                    {
                        _pacman.setPacmanX(_pacman.PacmanX() - 1);
                    }
                    break;
            }
            String result = _pacman.PacmanX().ToString() + "," + _pacman.PacmanY().ToString() + ","+ _pacman.getDirectionString();
            Assert.AreEqual("2,2,WEST", result);
        }

        [TestMethod()]
        public void rotateLeftTest()
        {
            Direction _direction = Direction.SOUTH;
            switch (_direction)
            {
                case Direction.NORTH:
                    _direction = Direction.WEST;
                    break;
                default:
                    _direction = _direction - 1;
                    break;
            }
            _pacman.setPacmanDir(_direction.ToString());
            Assert.AreEqual(Direction.EAST, _pacman.getDirection());
        }

        [TestMethod()]
        public void rotateRightTest()
        {
            Direction _direction = Direction.NORTH;
            switch (_direction)
            {
                case Direction.WEST:
                    _direction = Direction.NORTH;
                    break;
                default:
                    _direction = _direction + 1;
                    break;
            }
            _pacman.setPacmanDir(_direction.ToString());
            Assert.AreEqual(Direction.EAST, _pacman.getDirection());
        }

        [TestMethod()]
        public void reportTest()
        {
            _grid.move(_pacman);
            _grid.move(_pacman);
            String expected = "OUTPUT: 0,2,NORTH";
            string result = "OUTPUT: " + _pacman.PacmanX().ToString() + "," + _pacman.PacmanY().ToString() + "," + _pacman.PacmanDirection().ToString();
            Assert.AreEqual(expected,result);
        }

       
    }
}