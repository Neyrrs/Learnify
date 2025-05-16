using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaernify
{
    internal class userSession
    {
        public static string nama { get; set; }
        public static string password { get; set; }
        public static string namaLengkap { get; set; }
        public static string alamat { get; set; }
        public static string noTelp { get; set; }
        public static string email { get; set; }
        public static string role { get; set; }
        public static int id { get; set; }

        public static void logout() {
            nama = null;
            password = null;
            namaLengkap = null;
            alamat = null;
            noTelp = null;
            email = null;
            role = null;
            id = 0;
        }
    }
}
