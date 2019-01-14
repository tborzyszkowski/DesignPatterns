using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class WizardBuilder : CharacterBuilder
    {
        public WizardBuilder()
        {
            character = new Character("Wizard");
        }

        public override CharacterBuilder SetStrength()
        {
            character["str"] = "5";
            return this;
        }
        public override CharacterBuilder SetIntelligence()
        {
            character["int"] = "15";
            return this;
        }
        public override CharacterBuilder SetAgility()
        {
            character["agi"] = "10";
            return this;
        }
        public override CharacterBuilder SetDexterity()
        {
            character["dex"] = "10";
            return this;
        }
    }
}
