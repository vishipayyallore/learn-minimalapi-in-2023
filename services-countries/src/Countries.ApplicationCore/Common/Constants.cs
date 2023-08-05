namespace Countries.ApplicationCore.Common;

public static class Constants
{
    public static class WelcomeRoutes
    {
        public static string Root => "/";

        public static string Api => "/api";
    }

    public static class CountriesRoutes
    {
        public static string Prefix { get; } = "/api/countries";

        public static string Root => "/";
    }

    public static class SqlDatabaseConnectionStringName
    {
        public static string Name { get; } = "CountriesDbConnection";
    }

}