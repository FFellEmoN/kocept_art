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
            string lineSymbols = "())(()";

            bool isLineCorrect = true;

            int lastSymbolCorrectLineSymbol = lineSymbols.Length - 1;
            int firstSymbolCorrectLintSymbol = 0;
            int death = 0;
            int maxDeath = 0;

            char openSymbol = '(';
            char closeSymbol = ')';

            for (int i = 0; i < lineSymbols.Length; i++)
            {
                if (lineSymbols[firstSymbolCorrectLintSymbol] == closeSymbol || 
                    lineSymbols[lastSymbolCorrectLineSymbol] == openSymbol ||
                    death < 0)
                {
                    isLineCorrect = false;
                }

                if (lineSymbols[i] == openSymbol) 
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
