namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string c = Console.ReadLine();
            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(c[i]-1);
            }
        }
    }
}
