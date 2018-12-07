using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class CharacterCreationSystem
    {
        public Character Create(CharacterBuilder characterBuilder)
        {
            return characterBuilder;
        }     
    }
}
