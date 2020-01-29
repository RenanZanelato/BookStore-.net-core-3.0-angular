namespace BookStore.Infra.Context
{
    public class EnvironmentConnection
    {
        public static int SessionLifeTime = 10;
        public const string DatabaseName = "BookStore";
        public static string ConnectionString = "Server=localhost,11433;Database=BookStore;Uid=SA;Pwd=DockerSql2017!;";
    }
}
