using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Prototype
{
    [Serializable()]
    class Book : BookPrototype
    {
        private int pages;
        private Color color;
        private string title;
        
        public Book(int pages, Color color, string title)
        {
            this.pages = pages;
            this.color = color;
            this.title = title;
        }
        
        public override BookPrototype Duplicate()
        {
            Console.WriteLine("Duplicating: " + title);

            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            BookPrototype copy = (BookPrototype)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }

        public void SetPages(int noPages)
        {
            pages = noPages;
        }

        public void SetColor(Color col)
        {
            color = col;
        }

        public void SetTitle(String newTitel)
        {
            title = newTitel;
        }

        public override string ToString()
        {
            return "Pages: " + pages + ", color: " + color + ", title: " + title;
        }
    }
}
