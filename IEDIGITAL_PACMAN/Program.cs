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
            Pacman _pacman = new Pacman();
            String userCommand;

            /// <summary>
            /// The only keyword that is valid for the first time is "PLACE"
            /// Any other is invalid
            /// </summary>
            Boolean firstTime = true;
            Console.WriteLine("*.................Welcome to Pacman 5x5..................*");
            do {
                userCommand = (Console.ReadLine()).ToUpper();
                String pattern = @"PLACE\s[0-4]\,[0-4]\,([NORTH]*|[EAST]*|[WEST]*|[SOUTH]*)$";
                if (Regex.Match(userCommand, pattern, RegexOptions.IgnoreCase).Success)
                {
                        //Console.WriteLine("regex entered");
                        String[] Place_keyword = userCommand.Split(' ');
                        string[] placeWords = Place_keyword[1].Split(',');
                        if ((Convert.ToInt16(placeWords[0]) > -1 && Convert.ToInt16(placeWords[0]) < 5) &&
                            (Convert.ToInt16(placeWords[1]) > -1 && Convert.ToInt16(placeWords[1]) < 5)) {
                            int corX = Convert.ToInt16(placeWords[0]);
                            int corY = Convert.ToInt16(placeWords[1]);
                            String direction = placeWords[2];
                            //  Console.WriteLine("PLACING THE Pacman");
                            _grid.Place(_pacman, corX, corY, direction);
                            if (firstTime) {
                                firstTime = false;
                            } 
                         }
                }  
                if (!firstTime)
                {
                    if (userCommand == "MOVE")
                    {
                        _grid.Move(_pacman);
                    }
                    if (userCommand == "LEFT")
                    {
                        _grid.RotateLeft(_pacman);
                    }

                    if (userCommand == "RIGHT")
                    {
                        _grid.RotateRight(_pacman);
                    }

                    if (userCommand == "REPORT")
                    {
                        _grid.Report(_pacman);
                    }
                }
            } while (userCommand != "EXIT");
        }
     }
}
