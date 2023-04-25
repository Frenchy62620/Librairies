namespace ConsoleApp6;

class Program
{
    static private readonly object _sync = new object();

    static async Task Main(string[] args)
    {
        var colors = new List<Enum> 
        { 
            ConsoleColor.DarkBlue,ConsoleColor.Red, ConsoleColor.Yellow, 
            ConsoleColor.Green, ConsoleColor.DarkGray, ConsoleColor.Blue
        };
        char[] symbol = new char[] { '#', '\u25A0', '\u2592', '\u2588', '\u2551', '\u2502' };
        var min = 0;
        var max = 100;
        var tasks = Enumerable.Range(0, 6).Select(async p =>
        {
            await foreach (var i  in DoJob(p))
            {
                Update(i, (p + 1) * 3, min, max, colors[p], symbol[p]);
                //if( p == 0)
                //    await Task.Delay(175);
                //else
                //    await Task.Delay(25 + p * 25);
            }
        });
        await Task.WhenAll(tasks);

        Console.Read();
    }

    private static async IAsyncEnumerable<int> DoJob(int p)
    {
        for (int i = 0; i <= 100; i++)
        {
            await Task.Delay(50 + p * 25);//Simulate waiting for data to come through. 
            yield return i;
        }
    }
    private static void Update(int value, int row, int min, int max, Enum _color, char symbol)
    {
        // Calculate the percentage complete
        var percentComplete = (double)(value - min) / (max - min);

        // Calculate the width of the progress bar
        var width = Console.WindowWidth - 10;
        var progressWidth = (int)(percentComplete * width);
        lock (_sync)
        {
            // Set the cursor position and color
            Console.SetCursorPosition(0, row);
            Console.ForegroundColor = (ConsoleColor)_color;
            // Write the progress bar
            Console.Write("[{0}{1}] {2:P0}", new string(symbol, progressWidth), new string(' ', width - progressWidth), percentComplete);

            // Reset the color
            Console.ResetColor();
        }
    }

    public void atest(int az, string ad)
    {

    }
}


