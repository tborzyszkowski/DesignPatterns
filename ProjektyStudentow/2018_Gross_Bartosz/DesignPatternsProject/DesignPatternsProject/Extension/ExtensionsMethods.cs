using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Extension
{
    public class ExtensionsMethods
    {
        public static string Game(int number, int playerValue)
        {
            try
            {
                if (playerValue > number)
                {
                    return "Too Big";
                }
                if (playerValue < number)
                {
                    return "Too Small";
                }
                return "Correct!";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
