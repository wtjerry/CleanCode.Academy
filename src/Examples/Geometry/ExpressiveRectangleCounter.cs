namespace bbv.Examples.Geometry
{
    using System;
    using System.Linq;

    public class ExpressiveRectangleCounter : ICountRectangles
    {
        /// <inheritdoc />
        public int CountIn(int[,] pointSequence)
        {
            int numberOfRectanglesFound = 0;
            var points = GetPoints(pointSequence);
            var sortedPoints = SortPoints(points);

            foreach (var point in sortedPoints)
            {
                var pointsAbove = FindPointsAboveOf(point, sortedPoints);
                var pointsToTheRight = FindPointsRightOf(point, sortedPoints);

                foreach (var pointAbove in pointsAbove)
                {
                    foreach (var pointToTheRight in pointsToTheRight)
                    {
                        var expectedFourthRectanglePoint = new Point(pointAbove.X, pointToTheRight.Y);
                        if (sortedPoints.Contains(expectedFourthRectanglePoint))
                        {
                            numberOfRectanglesFound++;
                        }
                    }
                }
            }

            return numberOfRectanglesFound;
        }

        private static Point[] FindPointsAboveOf(Point startingPoint, Point[] sortedPoints)
        {
            return sortedPoints
                .Where(p => p.X == startingPoint.X)
                .Where(p => p.Y > startingPoint.Y)
                .ToArray();
        }

        private static Point[] FindPointsRightOf(Point startingPoint, Point[] sortedPoints)
        {
            return sortedPoints
                .Where(p => p.Y == startingPoint.Y)
                .Where(p => p.X > startingPoint.X)
                .ToArray();
        }

        private static Point[] GetPoints(int[,] pointSequence)
        {
            var numberOfPoints = pointSequence.GetLength(0);
            var points = new Point[numberOfPoints];

            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i] = new Point(pointSequence[i, 0], pointSequence[i, 1]);
            }

            return points;
        }

        private static Point[] SortPoints(Point[] unsortedPoints)
        {
            var sortedPoints = (Point[])unsortedPoints.Clone();
            Array.Sort(sortedPoints, (point, point1) => point.X - point1.X);

            return sortedPoints;
        }
    }
}