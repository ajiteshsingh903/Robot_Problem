using System;
using System.Collections.Generic;
using System.Linq;

namespace Program_DIS_GitHub
{
    class Program
    {
        private static bool Main(string[] args)
        {
            try
            {
                // write your code here
                Console.WriteLine("Enter the no of moves:");
                string moves = Console.ReadLine();

                {
                    int L_R = 0, U_D = 0;
                    foreach (char i in moves)
                    {
                        if (i == 'L')
                            L_R++;
                        else if (i == 'R')
                            L_R--;
                        else if (i == 'U')
                            U_D++;
                        else if (i == 'D')
                            U_D--;
                    }
                    return (L_R == 0 && U_D == 0);

                }

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
