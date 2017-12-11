using System;

namespace AdapterExample
{
    public class LegacyGfxLibrary
    {
        public string ObtainGraphicsChipsetInfo()
        {
            return "nVidia GeForce 650";
        }

        public void DrawRectangle(int width, int height)
        {
            // doing stuff

            Console.WriteLine("Drawing specified rectangle on canvas using legacy rectangle");
        }

        public void DrawCircle(int width, int height)
        {
            Console.WriteLine("Drawing specified circle on canvas using legacy rectangle");
        }

        public void DrawTriangle(int width, int height)
        {
            Console.WriteLine("Drawing specified traingle on canvas using legacy rectangle");
        }
    }
}
