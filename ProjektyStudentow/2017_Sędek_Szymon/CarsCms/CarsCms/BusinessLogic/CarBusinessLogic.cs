using System.Web;
using CarsCms.Interfaces;

namespace CarsCms.BusinessLogic
{
    public class CarBusinessLogic : ICarBusinessLogic
    {
        public string CheckIfUserIsAuthAndReturnName()
        {
            string name = "Niezalogowany";
            if (CheckIfUserIsAutorize())
                name = HttpContext.Current.User.Identity.Name;
            return name;
        }

        public bool CheckIfUserIsAutorize()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}