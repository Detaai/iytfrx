using System.Collections;

public static class Recursion
{
    // Problem 1
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char letter = letters[i];
            string remaining = letters.Remove(i, 1);

            PermutationsChoose(results, remaining, size, word + letter);
        }
    }

    // Problem 3
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;

        return ways;
    }

    // Problem 4
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string with0 = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string with1 = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);

        WildcardBinary(with0, results);
        WildcardBinary(with1, results);
    }

    // Problem 5
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Fixed: pass the arguments in the correct order
        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        currPath.RemoveAt(currPath.Count - 1);
    }
}
