namespace bbv.Examples.Geometry
{
    using System;
    using System.Linq;

    public class LinqRectangleCounter : ICountRectangles
    {
        /// <inheritdoc />
        public int CountIn(int[,] pointSequence)
        {
            var points = GetPoints(pointSequence);
            var sortedPoints = SortPoints(points);

            return
            (
                from point in sortedPoints let pointsAbove = FindPointsAboveOf(point, sortedPoints)
                let pointsToTheRight = FindPointsRightOf(point, sortedPoints)
                from pointAbove in pointsAbove
                from pointToTheRight in pointsToTheRight
                select new Point(pointAbove.X, pointToTheRight.Y)
            )
            .Count(fourthPoint => sortedPoints.Contains(fourthPoint));
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