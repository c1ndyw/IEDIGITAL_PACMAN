using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace IEDIGITAL_PACMAN
{      
 
    class Program
        {
        static void Main(string[] args)
        {
            Grid _grid = new Grid();
            Pacman _pacman = new Pacman("NORTH");
            String userCommand;
            Console.WriteLine("*.................Welcome to Pacman 5x5..................*");

            do
            {
                userCommand = (Console.ReadLine()).ToUpper();
                String pattern = @"PLACE\s[0-4]\,[0-4]\,([NORTH]*|[EAST]*|[WEST]*|[SOUTH]*)$";
                if(Regex.Match(userCommand, pattern, RegexOptions.IgnoreCase).Success){
                    //Console.WriteLine("regex entered");
                    String[] Place_keyword = userCommand.Split(' ');
                    string[] placeWords = Place_keyword[1].Split(',');
                    if (
                        (Convert.ToInt16(placeWords[0]) > -1 && Convert.ToInt16(placeWords[0]) < 5) &&
                        (Convert.ToInt16(placeWords[1]) > -1 && Convert.ToInt16(placeWords[1]) < 5)
                        )
                    {
                        int corX = Convert.ToInt16(placeWords[0]);
                        int corY = Convert.ToInt16(placeWords[1]);
                        String direction = placeWords[2];
                        //  Console.WriteLine("PLACING THE Pacman");
                        _grid.place(_pacman, corX, corY, direction);
                       
                    }
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
