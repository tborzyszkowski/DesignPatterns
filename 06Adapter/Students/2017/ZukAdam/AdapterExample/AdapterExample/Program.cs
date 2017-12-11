using System;

namespace AdapterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapter = new GfxAdapter(new NewGfxLibrary());
            Console.WriteLine(adapter.Draw(new Rectangle()));

            adapter = new GfxAdapter(new LegacyGfxLibrary());
            Console.WriteLine(adapter.Draw(new Rectangle()));

            Console.ReadKey();
        }
    }
}