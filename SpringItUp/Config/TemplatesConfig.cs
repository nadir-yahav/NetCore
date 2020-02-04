
namespace Config.Templates
{
    public class TemplatePath
    {
        private const string _basePath = "Templates/";
        public string Lid { get => _basePath + "lid.template.html"; }
        public string Sms { get => _basePath + "sms.template.html"; }
        public string SpringItUpContact { get => _basePath + "springitup-contact.template"; }
    }
}