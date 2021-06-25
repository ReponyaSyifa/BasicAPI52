using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class HashingPassword
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash); //login after change password bisa
                                                                    //dari reset pw yg fail
                                                                    //invalid salt version
        }

        public static bool PasswordValidation(string password, string trueHash) //login after reset bisa
                                                                                //dari change password yg fail
        {
            if (password.Equals(trueHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
