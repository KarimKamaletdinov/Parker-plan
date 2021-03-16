using System.IO;

namespace ParkerPlan.Site.Data
{
    public class PasswordService
    {
        public string GetPassword()
        {
            return File.ReadAllText("password.txt");
        }
    }
}