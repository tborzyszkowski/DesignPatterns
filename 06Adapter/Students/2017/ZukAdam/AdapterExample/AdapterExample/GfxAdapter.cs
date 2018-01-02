using System;

namespace AdapterExample
{
    public class GfxAdapter
    {
        public Func<string> GetGraphicsCardInfo;

        public Func<Shape, string> Draw;

        public GfxAdapter(NewGfxLibrary newGfxLibrary)
        {
            this.GetGraphicsCardInfo = newGfxLibrary.GetGfxCardInfo;
            this.Draw = newGfxLibrary.Draw;
        }

        public GfxAdapter(LegacyGfxLibrary legacyGfxLibrary)
        {
            this.GetGraphicsCardInfo = legacyGfxLibrary.ObtainGraphicsChipsetInfo;

            Draw = delegate (Shape shape)
            {
                switch (shape.Type)
                {
                    case "Rectangle":
                        legacyGfxLibrary.DrawRectangle(shape.Width, shape.Height);
                        return "Drawing rectangle using legacy library.";
                    case "Circle":
                        legacyGfxLibrary.DrawCircle(shape.Width, shape.Height);
                        return "Drawing circle using legacy library.";
                    case "Triangle":
                        legacyGfxLibrary.DrawTriangle(shape.Width, shape.Height);
                        return "Drawing triangle using legacy library.";
                    default:
                        return "Unable to find correct method.";
                }
            };
        }
    }
}
