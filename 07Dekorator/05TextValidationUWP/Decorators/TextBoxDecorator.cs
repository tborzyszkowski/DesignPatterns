using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using _05TextValidationUWP.Components;

namespace _05TextValidationUWP.Decorators {
    public abstract class TextBoxDecorator : ITextBoxComponent {
        protected readonly ITextBoxComponent _component;

        protected TextBoxDecorator(ITextBoxComponent component) {
            _component = component;
        }

        public virtual string Text {
            get { return _component.Text; }
            set {
                _component.Text = value;
            }
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
