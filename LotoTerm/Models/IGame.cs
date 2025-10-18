using System;
using System.Collections.Generic;
using System.Text;

namespace LotoTerm.Models;

public interface IGame
{
    string Name { get; }
    string Description { get; }
    IEnumerable<string> GenerateTicket(Random rng);
}
