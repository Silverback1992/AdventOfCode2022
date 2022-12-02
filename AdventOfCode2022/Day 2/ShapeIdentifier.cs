using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_2
{
    public static class ShapeIdentifier
    {
        private static Dictionary<string, ShapeType> _shapeLetters = new Dictionary<string, ShapeType>()
        {
            { "A", ShapeType.Rock },
            { "B", ShapeType.Paper },
            { "C", ShapeType.Scissors },
            { "X", ShapeType.Rock},
            { "Y", ShapeType.Paper },
            { "Z", ShapeType.Scissors }
        };

        public static ShapeType IdentifyShape(string shapeLetter)
        {
            return _shapeLetters[shapeLetter];
        }
    }
}
