namespace PersonManagement
{
    public static class CollectionExtension
    {
        public static void AddAll<T>(
            this ICollection<T> target,
            IEnumerable<T> source)
        {
            foreach (var item in source) {
                target.Add(item);
            }
        }
    }
}