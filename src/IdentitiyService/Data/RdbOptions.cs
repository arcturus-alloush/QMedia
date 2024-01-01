using Microsoft.Extensions.Hosting;

namespace IdentityService1.Data
{
    public class RdbOptions
    {
        public string Host { get; set; } = string.Empty;
        public string DbName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public string GetPostgresConnectionString()
        {
            var userIdPart = $"User ID={this.UserName};";
            var passwordPart = $"Password={this.Password};";
            var serverPart = $"Server={this.Host};";
            var databasePart = $"Database={this.DbName};";
            var poolingPart = "Pooling=true;";

            return userIdPart + passwordPart + serverPart + databasePart + poolingPart;
        }
    }
}
