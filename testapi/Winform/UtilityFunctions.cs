namespace Winform
{
    internal static class UtilityFunctions
    {

        public static bool IsAuthorized(string[] requiredRoles, bool requireAll = false)
        {
            var userRoles = new HashSet<string>(UserAccessInfo.Role);

            return requireAll ? requiredRoles.All(userRoles.Contains) : requiredRoles.Any(userRoles.Contains);
        }

    }
}
