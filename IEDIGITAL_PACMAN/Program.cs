using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEDIGITAL_PACMAN
{      
 
    class Program
        {
        static void Main(string[] args)
        {
            Grid _grid = new Grid();
            Pacman _pacman = new Pacman("NORTH");
            String userCommand;
            Console.WriteLine("Welcome to Pacman 5x5");
            do
            {
                userCommand = Console.ReadLine();
                string[] placeWords = userCommand.Split(',');

                if (userCommand.Contains(',')) {
                    if (
                        ( Convert.ToInt16(placeWords[1]) >-1 && Convert.ToInt16(placeWords[1]) < 5) && 
                        (Convert.ToInt16(placeWords[2]) > -1 && Convert.ToInt16(placeWords[2]) < 5)
                        )
                        {
                            int corX = Convert.ToInt16(placeWords[1]);
                            int corY = Convert.ToInt16(placeWords[2]);
                            String direction = placeWords[3];
                          //  Console.WriteLine("PLACING THE Pacman");
                             _grid.place(_pacman, corX, corY,direction);
                        }
                       //  Console.WriteLine("contain coma");
                }
                if (userCommand == "MOVE")
                {
                    _grid.move(_pacman);
                }

                if (userCommand == "LEFT")
                {
                    _grid.rotateLeft(_pacman);
                }
                if (userCommand == "RIGHT")
                {
                    _grid.rotateRight(_pacman);
                }
                if (userCommand == "REPORT")
                {
                    _grid.report(_pacman);
                }

            } while (userCommand != "EXIT");
        }
        }
    }
