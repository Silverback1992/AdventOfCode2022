using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_2
{
    public static class PointCalculator
    {
        public static ResultType ResultTypeCalculator(ShapeType opponentShape, ShapeType myShape)
        {
            if (opponentShape == myShape)
            {
                return ResultType.Draw;
            }

            if (opponentShape == ShapeType.Rock && myShape  == ShapeType.Scissors)
            {
                return ResultType.Lose;
            }

            if (opponentShape == ShapeType.Paper && myShape == ShapeType.Rock)
            {
                return ResultType.Lose;
            }

            if (opponentShape == ShapeType.Scissors && myShape == ShapeType.Paper)
            {
                return ResultType.Lose;
            }

            return ResultType.Win;
        }

        public static ShapeType ShouldBeChoosenShapeCalculator(ShapeType opponentShape, ResultType desiredResult)
        {
            if (opponentShape == ShapeType.Rock && desiredResult == ResultType.Win)
            {
                return ShapeType.Paper;
            }

            if (opponentShape == ShapeType.Rock && desiredResult == ResultType.Lose)
            {
                return ShapeType.Scissors;
            }

            if (opponentShape == ShapeType.Paper && desiredResult == ResultType.Win)
            {
                return ShapeType.Scissors;
            }

            if (opponentShape == ShapeType.Paper && desiredResult == ResultType.Lose)
            {
                return ShapeType.Rock;
            }

            if (opponentShape == ShapeType.Scissors && desiredResult == ResultType.Win)
            {
                return ShapeType.Rock;
            }

            if (opponentShape == ShapeType.Scissors  && desiredResult == ResultType.Lose)
            {
                return ShapeType.Paper;
            }

            return opponentShape;
        }
    }
}
