using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    abstract class CharacterBuilder
    {
        protected Character character;

        Character Character
        {
            get { return character; }
        }

        public abstract CharacterBuilder SetStrength();
        public abstract CharacterBuilder SetIntelligence();
        public abstract CharacterBuilder SetAgility();
        public abstract CharacterBuilder SetDexterity();
        
        public static implicit operator Character(CharacterBuilder cb)
        {
            return cb.SetStrength()
                .SetIntelligence()
                .SetAgility()
                .SetDexterity()
                .Character;
        }
    }
}
