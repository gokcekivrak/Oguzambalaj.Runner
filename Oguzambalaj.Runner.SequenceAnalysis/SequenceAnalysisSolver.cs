using System;
using System.Linq;
using System.Text;

namespace Oguzambalaj.Runner.SequenceAnalysis
{
    public class SequenceAnalysisSolver
    {
        private const int MaxChar = 26;

        public string Solve(string input)
        {
            var punctuation = input.Where(char.IsPunctuation).Distinct().ToArray();
            var words = input.Split().Select(x => x.Trim(punctuation));
         
            var charCount = new int[MaxChar];
            foreach (var word in words)
            {
                if (word != word.ToUpper()) continue;

                
                char[] charsToTrim = { '*', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                var asciiBytes = Encoding.ASCII.GetBytes(word.Trim(charsToTrim).Replace("'", string.Empty));

               
                foreach (var letter in asciiBytes)
                {
                    if (letter < 65 || letter > 90)
                        throw new InvalidOperationException($"Input contains non-ascii character '{(char)letter}'. Non-Ascii characters are not supported");

                    charCount[letter % 65]++;
                }
            }

            var result = new StringBuilder();
            
            for (var i = 0; i < MaxChar; i++)
                result.Append(new string((char)(i + 65), charCount[i]));

            return result.ToString();
        }
    }
}