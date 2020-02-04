using Config.Email;
using Templates;

namespace SpringItUp
{
    public class Email
    {
        private static EmailAccountDetails _accountDetails;
        private static object syncRoot = new object();
        public static EmailAccountDetails AccountDetails
        {
            get
            {
                if (_accountDetails == null)
                    lock (syncRoot)
                    {
                        if (_accountDetails == null)
                            _accountDetails = new EmailAccountDetails();
                    }
                return _accountDetails;
            }
        }

        private static HtmlTemplates _templates;
        public static HtmlTemplates Templates
        {
            get
            {
                if (_templates == null)
                    _templates = new HtmlTemplates();
                return _templates;
            }
        }
    }
}