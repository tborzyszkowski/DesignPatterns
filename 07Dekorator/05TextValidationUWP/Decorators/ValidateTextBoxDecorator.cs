using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;
using _05TextValidationUWP.Components;

namespace _05TextValidationUWP.Decorators {
    public class ValidateTextBoxDecorator : TextBoxDecorator {
        private string _errorMessage;
        private readonly string _regExPattern;

        public ValidateTextBoxDecorator(TextBoxComponent component, string pattern)
            : base(component) {
            _regExPattern = pattern;
            component.PropertyChanged += ComponentOnPropertyChanged;
        }

        private void ComponentOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
            Validate();
        }

        public bool Validate() {
            if (!Regex.IsMatch(Text, _regExPattern))
            {
                ErrorMessage = "Validation failed.";
                return false;
            }

            ErrorMessage = string.Empty;
            return true;
        }

        public string ErrorMessage {
            get { return _errorMessage; }
            private set {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
    }
}
