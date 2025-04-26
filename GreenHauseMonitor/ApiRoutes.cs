namespace Cmms
{
    public static class ApiRoutes
    {
        public const string BaseRoute = "api/[controller]";

        public static class UserProfiles
        {
            public const string IdRoute = "{id}";
        }

        public static class Quests
        {
            public const string IdRoute = "{id}";
        }

        public static class QuestTypes
        {
            public const string IdRoute = "{id}";
        }

        public static class Identity
        {
            public const string Login = "legin";
            public const string Registration = "registration";
            public const string IdentityById = "{identityUserId}";
        }
    }
}
