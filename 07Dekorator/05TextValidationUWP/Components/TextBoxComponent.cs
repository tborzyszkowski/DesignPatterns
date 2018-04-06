using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace _05TextValidationUWP.Components {
    public class TextBoxComponent : ITextBoxComponent {
        public event PropertyChangedEventHandler PropertyChanged;
        protected readonly TextBox _textBox;

        public TextBoxComponent(TextBox textBox) {
            _textBox = textBox;
        }

        public string Text {
            get { return _textBox.Text; }
            set {
                _textBox.Text = value;
                OnPropertyChanged("Text");
            }
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
