namespace bbv.Examples.Geometry
{
    /// <summary>
    /// Provides functionality for counting rectangles in an given area.
    /// </summary>
    public interface ICountRectangles
    {
        /// <summary>
        /// Counts the number of rectangles in the given sequence of points: <paramref name="pointSequence"/>.
        /// </summary>
        /// <param name="pointSequence">
        /// A multidimensional Array representing the points in an area.
        /// </param>
        /// <returns>
        /// The number of rectangles represented in <paramref name="pointSequence"/>.
        /// </returns>
        int CountIn(int[,] pointSequence);
    }
}