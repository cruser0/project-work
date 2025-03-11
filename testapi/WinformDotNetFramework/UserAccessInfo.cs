using System;
using System.Collections.Generic;

namespace WinformDotNetFramework
{
    public static class UserAccessInfo
    {
        public static string Token { get; set; }
        public static string Name { get; set; }
        public static string LastName { get; set; }
        public static string Email { get; set; }
        public static List<string> Role { get; set; }
        public static int RefreshTokenID { get; set; }
        public static int RefreshUserID { get; set; }
        public static string RefreshToken { get; set; }
        public static DateTime RefreshCreated { get; set; }
        public static DateTime RefreshExpires { get; set; }

        public static ICollection<string> Favorites { get; set; }

    }
}
