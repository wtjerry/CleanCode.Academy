namespace bbv.Examples.SOLID._1_SRP.II_Solution
{
    public class OutputFormatter
    {
        public string ToSimpleString(double sum)
        {
            return string.Format("Sum of the areas provided: {0}", sum);
        }

        public string ToJsonString(double sum)
        {
            return string.Format("{{ \"sum\" : {0} }}", sum);
        }

        public string ToHtmlString(double sum)
        {
            return string.Format("<sum>{0}</sum>", sum);
        }
    }
}