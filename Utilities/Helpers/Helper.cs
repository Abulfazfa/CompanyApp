namespace Utilities.Helpers
{
    public class Helper
    {
        public static void MessageAndItsColor(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
    }
}
