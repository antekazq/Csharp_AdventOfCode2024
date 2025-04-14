namespace AdventOfCode2024;

public static class Day04
{
    public static void Run()
    {
        Console.WriteLine("Running Day 4");
        string word = "XMAS";
        int wordCount = 0;

        string[] grid = File.ReadAllLines("Day04/input.txt");


        //Array conisting of tuples 
        var directions = new (int dx, int dy)[]{
            (-1,-1), (-1,0), (-1,1),
            (0,-1),(0,1),
            (1,-1), (1,0), (1,1)


        };

        for(int row = 0; row < grid.Length; row++)
        {
            for(int col = 0; col < grid[0].Length; col++)
            {
                foreach(var (dx, dy) in directions)
                {
                    if (FindWord(grid, row, col, dx, dy, word))
                    {
                        //The word XMAS has been found if True
                        wordCount++;
                    }
                }
            }
        }
        Console.WriteLine("XMAS found: " + wordCount);

    }
    static bool FindWord(string[] grid, int row, int col, int dx, int dy, string word)
        {
            for(int i = 0; i < word.Length; i++)
            {
                int r = row + i * dx;
                int c = col + i * dy;

                if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length)
                    //Out of bounds
                    return false;

                if (grid[r][c] != word[i])
                    //Wrong letter
                    return false;
            }

            return true;
        }
}
