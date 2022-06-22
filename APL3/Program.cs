namespace APL3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var source = File.ReadAllText("HelloWorld.apl3");
            Lexer tokenizer = new Lexer(source);

            string hello = string.Empty;
        }

        public static void Abort(string message, int errorCode)
        {
            Console.WriteLine(message, errorCode);
            Environment.Exit(errorCode);
        }
    }
}