using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterCreationSystem characterCreationSystem = new CharacterCreationSystem();

            Character demonHunterBuilder = characterCreationSystem.Create(new DemonHunterBuilder());
            demonHunterBuilder.Show();

            Character wizardBuilder = characterCreationSystem.Create(new WizardBuilder());
            wizardBuilder.Show();

            Character barbarianBuilder = characterCreationSystem.Create(new BarbarianBuilder());
            barbarianBuilder.Show();

            Console.ReadKey();
        }
    }
}
