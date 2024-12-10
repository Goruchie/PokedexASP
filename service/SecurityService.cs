using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace service
{
    public class SecurityService
    {
        public static bool sessionActive(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;
            if (trainee != null && trainee.Id != 0)
            {
                return true;
            }
            else
                return false;
        }
        public static bool isAdmin(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : (Trainee)null;
            return trainee != null ? trainee.Admin : false;
        }
    }
}
