using System.Collections.Generic;

namespace MyKeys.ViewModel
{
    internal static class GameInfo
    {
        static public IEnumerable<int> PossibleColumnNumber { get; } = new[] { 3, 4, 5, 6 };
        static public IEnumerable<int> PossibleRowNumber { get; } = new[] { 3, 4, 5, 6 };
    }
}
