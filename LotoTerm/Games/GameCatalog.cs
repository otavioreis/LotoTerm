using LotoTerm.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LotoTerm.Games;

public static class GameCatalog
{
    public static IReadOnlyDictionary<string, IGame> Map => new Dictionary<string, IGame>
    {
        ["megasena"] = new MegaSena(),
        ["lotofacil"] = new LotoFacil(),
        ["quina"] = new Quina(),
        ["lotomania"] = new LotoMania(),
        ["timemania"] = new TimeMania(),
        ["duplasena"] = new DuplaSena(),
        ["diadesorte"] = new DiaDeSorte(),
        ["supersete"] = new SuperSete(),
        ["maismilionaria"] = new MaisMilionaria(),
    };

    public static IEnumerable<(string Key, IGame Game)> All() => Map.Select(kv => (kv.Key, kv.Value));

    // Helpers
    internal static int[] DrawUnique(Random rng, int minInclusive, int maxInclusive, int count)
    {
        var set = new HashSet<int>();
        while (set.Count < count)
            set.Add(rng.Next(minInclusive, maxInclusive + 1));
        return set.OrderBy(x => x).ToArray();
    }

    internal static string JoinNumbers(IEnumerable<int> nums, bool pad2 = false)
    {
        return string.Join("-", nums.Select(n => pad2 ? n.ToString("00", CultureInfo.InvariantCulture) : n.ToString(CultureInfo.InvariantCulture)));
    }
}
