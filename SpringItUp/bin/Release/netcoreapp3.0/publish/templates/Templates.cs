using System.IO;
using System.Text;
using Config.Templates;
using SpringItUp;

namespace Templates
{
    public class HtmlTemplates
    {
        private static TemplatePath _path;
        public TemplatePath Path
        {
            get
            {
                if (_path == null)
                    _path = new TemplatePath();
                return _path;
            }
        }
        public string Lid(Lid lid)
        {
            var builder = new StringBuilder();

            using (var reader = File.OpenText(Path.Lid))
            {
                builder.Append(reader.ReadToEnd());
            }

            builder.Replace("OWNER_NAME", lid.OwnerName);
            builder.Replace("CUSTOMER_NAME", lid.CustomerName);
            builder.Replace("CUSTOMER_PHONE", lid.CustomerPhone);
            builder.Replace("CUSTOMER_MSG", lid.CustomerMsg);
            return builder.ToString();
        }
    }
    public class TextTemplates
    {

    }
}