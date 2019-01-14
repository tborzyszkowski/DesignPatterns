using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class DemonHunterBuilder : CharacterBuilder
    {
        public DemonHunterBuilder()
        {
            character = new Character("Demon Hunter");
        }

        public override CharacterBuilder SetStrength()
        {
            character["str"] = "8";
            return this;
        }
        public override CharacterBuilder SetIntelligence()
        {
            character["int"] = "7";
            return this;
        }
        public override CharacterBuilder SetAgility()
        {
            character["agi"] = "12";
            return this;
        }
        public override CharacterBuilder SetDexterity()
        {
            character["dex"] = "13";
            return this;
        }
    }
}
