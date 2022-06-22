namespace APL3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var source = File.ReadAllText("HelloWorld.apl3");
            Tokenizer tokenizer = new Tokenizer(source);

            string hello = string.Empty;
        }
    }
}