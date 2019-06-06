using Ceramics.Ceramics;
using Ceramics.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Adapter
{
    public class VaseAdapter : Plate
    {
        Vase vase;
        Observerable observable;

        public VaseAdapter(Vase vase)
        {
            this.vase = vase;
            this.observable = new  Observerable(this);
        }

        public override void AttachObserver(IObserver observer)
        {
            observable.AttachObserver(observer);
        }

        public override void Firing()
        {
            vase.HandMadeFormation();
            notifyObservers();
        }

        public override void notifyObservers()
        {
            observable.notifyObservers();
        }

        public override void Prepare()
        {
            price = 160;
        }

        public override void RemoveObserver(IObserver observer)
        {
            observable.RemoveObserver(observer);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
