using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_6
{
    public class MarkerPositionCalculator
    {
        public static int CalculateMarkerPosition(string dataStreamBuffer, int requiredDistinctChars)
        {
            for (int i = 0; i < dataStreamBuffer.Length; i++)
            {
                string slice = dataStreamBuffer.Substring(i, requiredDistinctChars);

                if (slice.Distinct().Count() == requiredDistinctChars)
                {
                    return i + requiredDistinctChars;
                }
            }

            throw new Exception("Marker not found");
        }
    }
}
