using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            NPCPrototype npcOne = new NPCPrototype();
            npcOne.Health = "100Hp";
            npcOne.Money = "150$";
            npcOne.Status = "Alive";
            npcOne.Ai.Activity = "Smoking";
            npcOne.Ai.Behavior = "Aggressive";
            npcOne.Ai.Reaction = "Netrual";

            NPCPrototype npcTwo = new NPCPrototype();
            npcTwo.Health = "90Hp";
            npcTwo.Money = "500$";
            npcTwo.Status = "Alive";
            npcTwo.Ai.Activity = "Reading";
            npcTwo.Ai.Behavior = "Nervous";
            npcTwo.Ai.Reaction = "Netrual";

            NPCPrototype npcClone = npcOne.Clone() as NPCPrototype;
            npcClone.Ai.Activity = "HoldingGun";
            npcClone.Ai.Behavior = "Aggressive";
            npcClone.Ai.Reaction = "Combat";

            NPCPrototype npcCloneTwo = npcTwo.Clone() as NPCPrototype;
            npcCloneTwo.Ai.Activity = "Default";
            npcCloneTwo.Ai.Behavior = "Nervous";
            npcCloneTwo.Ai.Reaction = "Running";

            Console.WriteLine("\nOriginal NPC:");
            Console.WriteLine("Activity: {0}, Behavior: {1}, Reaction: {2}",
                npcOne.Ai.Activity,
                npcOne.Ai.Behavior,
                npcOne.Ai.Reaction
                );

            Console.WriteLine("\nOriginal NPC Two:");
            Console.WriteLine("Activity: {0}, Behavior: {1}, Reaction: {2}",
                npcTwo.Ai.Activity,
                npcTwo.Ai.Behavior,
                npcTwo.Ai.Reaction
                );

            Console.WriteLine("\nICloneable Deep Cloned NPC:");
            Console.WriteLine("Activity: {0}, Behavior: {1}, Reaction: {2}",
                npcClone.Ai.Activity,
                npcClone.Ai.Behavior,
                npcClone.Ai.Reaction
                );

            Console.WriteLine("\nICloneable Deep Cloned NPC Two:");
            Console.WriteLine("Activity: {0}, Behavior: {1}, Reaction: {2}",
                npcCloneTwo.Ai.Activity,
                npcCloneTwo.Ai.Behavior,
                npcCloneTwo.Ai.Reaction
                );

            Console.ReadKey();
        }
    }
}
