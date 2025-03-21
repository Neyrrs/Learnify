using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaernify
{
    internal class userSession
    {
        public static string username { get; set; }
        public static string password { get; set; }
        public static int id { get; set; }

        public static void logout() {
            username = null;
            username = null;
            id = 0;
        }
    }
}
