namespace PersonManagement
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(
            this IEnumerable<T> items,
            Action<T> action)
        {
            foreach (var item in items) {
                action(item);
            }
        }

        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> items,
            Func<T, bool> predicate)
        {
            foreach (var item in items) {
                if (predicate(item)) {
                    yield return item;
                }
            }
        }
    }
}
