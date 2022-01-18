// ReSharper disable CheckNamespace

namespace CleanCode.Design.SolidSolution
{
    public static class ItemCollectionFactory
    {
        public static ItemCollection GetInitializedCollection()
        {
            var collection = new ItemCollection();
            collection.Initialize();

            return collection;
        }
    }
}