using Microsoft.Extensions.Configuration;

namespace Config.Email
{
    public class EmailAccountDetails
    {
        public IConfiguration _config = SpringItUp.Startup.Configuration;
        public string Subject { get { return _config["Email:Subject"]; } }
        public string DisplayName { get { return _config["Email:DisplayName"]; } }
        public string From { get { return _config["Email:From"]; } }
        public string UserName { get { return _config["Email:Credential:UserName"]; } }
        public string Password { get { return _config["Email:Credential:Password"]; } }
        public string Host { get { return _config["Email:Smtp:Host"]; } }
        public int Port { get { return int.Parse(_config["Email:Smtp:Port"]); } }
    }
}