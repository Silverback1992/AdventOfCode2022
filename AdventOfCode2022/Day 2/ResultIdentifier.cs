using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_2
{
    public static class ResultIdentifier
    {
        private static Dictionary<string, ResultType> _resultLetters = new Dictionary<string, ResultType>()
        {
            { "X", ResultType.Lose },
            { "Y", ResultType.Draw },
            { "Z", ResultType.Win }
        };

        public static ResultType IdentifyResult(string resultLetter)
        {
            return _resultLetters[resultLetter];
        }
    }
}
