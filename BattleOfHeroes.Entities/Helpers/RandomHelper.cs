namespace BattleOfHeroes.Entities.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random Random = new();

        public static bool NextBool()
        {
            return Random.NextDouble() >= 0.5;
        }

        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[Random.Next(list.Count)];
        }
    }
}
