namespace bbv.Examples.Geometry
{
    using System;

    public class StructuralRectangleCounter : ICountRectangles
    {
        /// <inheritdoc />
        public int CountIn(int[,] pointSequence)
        {
            int numberOfRectanglesFound = 0;
            int n = pointSequence.GetLength(0);

            // sort points from left to right using bubble sort
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (pointSequence[j, 0] > pointSequence[j + 1, 0])
                    {
                        int[] temp = { pointSequence[j, 0], pointSequence[j, 1] };
                        pointSequence[j, 0] = pointSequence[j + 1, 0];
                        pointSequence[j, 1] = pointSequence[j + 1, 1];
                        pointSequence[j + 1, 0] = temp[0];
                        pointSequence[j + 1, 1] = temp[1];
                    }
                }
            }

            // iterate through all points
            for (int i = 0; i < n; i++)
            {
                int[] point = { pointSequence[i, 0], pointSequence[i, 1] };
                int lastAboveIndexFound = 0;
                int lastRightIndexFound = 0;

                // find points above the current point
                int[,] pointsAbove = new int[n, 2];
                for (int j = 0; j < n; j++)
                {
                    int[] candidatePoint = { pointSequence[j, 0], pointSequence[j, 1] };
                    if (candidatePoint[0] == point[0] && candidatePoint[1] > point[1])
                    {
                        pointsAbove[lastAboveIndexFound, 0] = candidatePoint[0];
                        pointsAbove[lastAboveIndexFound, 1] = candidatePoint[1];
                        lastAboveIndexFound++;
                    }
                }

                // find points, that are right of the current point
                int[,] pointsToTheRight = new int[n, 2];
                for (int j = 0; j < n; j++)
                {
                    int[] candidatePoint = { pointSequence[j, 0], pointSequence[j, 1] };
                    if (candidatePoint[0] > point[0] && candidatePoint[1] == point[1])
                    {
                        pointsToTheRight[lastRightIndexFound, 0] = candidatePoint[0];
                        pointsToTheRight[lastRightIndexFound, 1] = candidatePoint[1];
                        lastRightIndexFound++;
                    }
                }

                // determine fourth point of rectangle and if present, increment counter
                for (int j = 0; j < lastAboveIndexFound; j++)
                {
                    int[] pointAbove = { pointsAbove[j, 0], pointsAbove[j, 1] };

                    for (int k = 0; k < lastRightIndexFound; k++)
                    {
                        int[] pointToTheRight = { pointsToTheRight[k, 0], pointsToTheRight[k, 1] };

                        for (int m = 0; m < n; m++)
                        {
                            if (pointSequence[m, 0] == pointAbove[0]
                                && pointSequence[m, 1] == pointToTheRight[1])
                            {
                                numberOfRectanglesFound++;
                            }
                        }
                    }
                }
            }

            return numberOfRectanglesFound;
        }
    }
}
