namespace FriendzyBlog.Api.v1.Infrastructure
{
    public static class ConfigurationSetting
    {
        public const string ConnectionString = "DatabaseConfigs:DefaultConnection";
        public const string ConnectionMongoDbNameString = "DatabaseConfigs:DatabaseName";
        public const string JwtSecrectKey = "JwtBearerConfig:SigningKeys";
        public const string JwtIssuer = "JwtBearerConfig:Issuer";
        public const string JwtAudience = "JwtBearerConfig:Audience";
        public const string PublicKey = "RSAKeys:PublicKey";
        public const string PrivateKey = "RSAKeys:PrivateKey";
    }
}