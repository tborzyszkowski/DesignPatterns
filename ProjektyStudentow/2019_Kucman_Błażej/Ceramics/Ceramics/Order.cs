using Ceramics.Ceramics;
using Ceramics.Iterator;
using Ceramics.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics
{
    public class Order : Plate
    {
        //List<Plate> orderedItems = new List<Plate>();
        private IMyData<Plate> orderedItems = new MyData<Plate>();

        public void addItem(Plate plate)
        {
            orderedItems.AddItem(plate);
        }

        public override void AttachObserver(IObserver observer)
        {
            var items = orderedItems.GetAll();

            for (int i = 0; i < items.Count(); i++)
            {
                Plate plate = (Plate)items.ElementAt(i);
                plate.AttachObserver(observer);
            }
        }

        public override void Firing()
        {
            var items = orderedItems.GetAll();
            for(int i = 0; i< items.Count(); i++)
            {
                Plate plate = (Plate)items.ElementAt(i);
                plate.Firing();
            }
        }

        public override void notifyObservers()
        {
            
        }

        public override void Prepare()
        {
            
        }

        public override void RemoveObserver(IObserver observer)
        {
            var items = orderedItems.GetAll();

            for (int i = 0; i < items.Count(); i++)
            {
                Plate plate = (Plate)items.ElementAt(i);
                plate.RemoveObserver(observer);
            }
        }

        public override string ToString()
        {
            return "Tutaj jest zamówienie. ";
        }
    }
}
