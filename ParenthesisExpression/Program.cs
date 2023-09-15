using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParenthesisExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lineSymbols = "(())";

            bool isLineCorrect = true;

            int lastSymbolCorrectLineSymbol = lineSymbols.Length - 1;
            int firstSymbolCorrectLintSymbol = 0;
            int death = 0;
            int maxDeath = 0;

            for (int i = 0; i < lineSymbols.Length; i++)
            {
                if (lineSymbols[firstSymbolCorrectLintSymbol] == ')' || lineSymbols[lastSymbolCorrectLineSymbol] == '(')
                {
                    isLineCorrect = false;
                }

                if (lineSymbols[i] == '(') 
                {
                    death++;

                    if (death > maxDeath)
                    {
                        maxDeath = death;
                    }
                }
                else
                {
                    death--;
                }
            }
            
            if (isLineCorrect && death == 0)
            {
                Console.WriteLine($"Строка коректная, максимум глубины {maxDeath}"); ;
            }
            else
            {
                Console.WriteLine($"Строка не коректная");
            }
        }
    }
}
