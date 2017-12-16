using AdapterExample.Interfaces;
using System;

namespace AdapterExample
{
    public class NewGfxLibrary : IGfxLibrary
    {
        public string GetGfxCardInfo()
        {
            return "nVidia GeForce 650";
        }

        public string Draw(Shape shape)
        {
            return string.Format("Drawing {0} on canvas using new library", shape.Type.ToLower());
        }
    }
}
