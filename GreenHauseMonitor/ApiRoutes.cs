namespace Cmms
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/[controller]";

        public class UserProfiles
        {
            public const string IdRoute = "{id}";
        }

        public class Quests
        {
            public const string GetById = "{id}";
        }
    }
}
