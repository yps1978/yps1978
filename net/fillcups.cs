using System;
using System.Collections.Generic;
using System.Text;

namespace net
{
    public class fc
    {
        public static void xyz()
        {
            Console.WriteLine(new fc().FillCups(new[] {5, 4, 4}));
        }

        public int FillCups(int[] amount)
        {
            var seconds = 0;
            while (amount[0] + amount[1] + amount[2] > 0)
            {
                // sort
                if (amount[0] < amount[1])
                {
                    var aux = amount[1];
                    amount[1] = amount[0];
                    amount[0] = aux;
                }
                if (amount[0] < amount[2])
                {
                    var aux = amount[2];
                    amount[2] = amount[0];
                    amount[0] = aux;
                }
                if (amount[1] < amount[2])
                {
                    var aux = amount[2];
                    amount[2] = amount[1];
                    amount[1] = aux;
                }

                //compare
                if (amount[0] > 0 && amount[1] > 0)
                {
                    amount[0]--;
                    amount[1]--;
                    seconds++;
                }
                else if (amount[0] > 0 && amount[2] > 0)
                {
                    amount[0]--;
                    amount[2]--;
                    seconds++;
                }
                else if (amount[1] > 0 && amount[2] > 0)
                {
                    amount[1]--;
                    amount[2]--;
                    seconds++;
                }
                else if (amount[0] > 0)
                {
                    amount[0]--;
                    seconds++;
                }
                else if (amount[1] > 0)
                {
                    amount[1]--;
                    seconds++;
                }
                else if (amount[2] > 0)
                {
                    amount[2]--;
                    seconds++;
                }
            }

            return seconds;
        }
    }
}