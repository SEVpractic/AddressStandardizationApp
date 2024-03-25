namespace AddressStandardizationAPI.Configs
{
    public class SD
    {
        private static string dadataApiToken;
        private static string dadataApiSecret;

        public static string DadataApiToken { get => dadataApiToken; }
        public static string DadataApiSecret { get => dadataApiSecret; }

        public static void ConfigureSD(ConfigurationManager configuration)
        {
            dadataApiToken = configuration["DadataConnection:DadataApiToken"];
            dadataApiSecret = configuration["DadataConnection:DadataApiSecret"];
        }
    }
}
