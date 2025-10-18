using static LotoTerm.Games.GameCatalog;

namespace LotoTerm.Models;

public sealed class MegaSena : IGame
{
    public string Name => "Mega-Sena";
    public string Description => "6 dezenas de 1 a 60.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var n = DrawUnique(rng, 1, 60, 6);
        yield return JoinNumbers(n);
    }
}

public sealed class LotoFacil : IGame
{
    public string Name => "Lotofácil";
    public string Description => "15 números de 1 a 25.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var n = DrawUnique(rng, 1, 25, 15);
        yield return JoinNumbers(n);
    }
}

public sealed class Quina : IGame
{
    public string Name => "Quina";
    public string Description => "5 números de 1 a 80.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var n = DrawUnique(rng, 1, 80, 5);
        yield return JoinNumbers(n);
    }
}

public sealed class LotoMania : IGame
{
    public string Name => "Lotomania";
    public string Description => "50 números de 00 a 99.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var set = new HashSet<int>();
        while (set.Count < 50)
            set.Add(rng.Next(0, 100)); // 0..99
        var ordered = set.OrderBy(x => x).ToArray();
        yield return JoinNumbers(ordered, pad2: true);
    }
}

public sealed class TimeMania : IGame
{
    public string Name => "Timemania";
    public string Description => "10 números de 1 a 80 e um Time do Coração.";

    private static readonly string[] Times = new[]
    {
        "Flamengo","Corinthians","Palmeiras","São Paulo","Santos",
        "Vasco","Fluminense","Botafogo","Grêmio","Internacional",
        "Cruzeiro","Atlético-MG","Bahia","Fortaleza","Ceará",
        "Athletico-PR","Coritiba","Goiás","Sport","Vitória"
    };

    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var n = DrawUnique(rng, 1, 80, 10);
        var time = Times[rng.Next(Times.Length)];
        yield return JoinNumbers(n) + $"  (Time: {time})";
    }
}

public sealed class DuplaSena : IGame
{
    public string Name => "Dupla Sena";
    public string Description => "6 números de 1 a 50.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var n = DrawUnique(rng, 1, 50, 6);
        yield return JoinNumbers(n);
    }
}

public sealed class DiaDeSorte : IGame
{
    public string Name => "Dia de Sorte";
    public string Description => "7 números de 1 a 31 e um mês de 1 a 12.";

    private static readonly string[] Meses =
    {
        "Janeiro","Fevereiro","Março","Abril","Maio","Junho",
        "Julho","Agosto","Setembro","Outubro","Novembro","Dezembro"
    };

    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var n = DrawUnique(rng, 1, 31, 7);
        var mes = Meses[rng.Next(12)];
        yield return JoinNumbers(n) + $"  (Mês: {mes})";
    }
}

public sealed class SuperSete : IGame
{
    public string Name => "Super Sete";
    public string Description => "Escolha 1 dígito (0 a 9) por cada uma das 7 colunas.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var digits = Enumerable.Range(0, 7).Select(_ => rng.Next(0, 10)).ToArray();
        yield return string.Join("-", digits);
    }
}

public sealed class MaisMilionaria : IGame
{
    public string Name => "+Milionária";
    public string Description => "6 números de 1 a 50 e 2 trevos de 1 a 6.";
    public IEnumerable<string> GenerateTicket(Random rng)
    {
        var numeros = DrawUnique(rng, 1, 50, 6);
        var trevos = DrawUnique(rng, 1, 6, 2);
        yield return JoinNumbers(numeros) + $"  (Trevos: {string.Join("-", trevos)})";
    }
}
