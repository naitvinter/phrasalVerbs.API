namespace PhrasalVerbs.API;

public class Endpoints
{
    private const string APIBase = "api/v{version:apiVersion}";

    public static class PhrasalVerbs
    {
        private const string Base = $"{APIBase}/phrasalVerbs";

        public const string Create = Base;

        public const string Get = $"{Base}/{{idOrSlug}}"; 
        public const string GetAll = Base;

        public const string Update = $"{Base}/{{id}}";

        public const string Delete = $"{Base}/{{id}}";
    }
}
