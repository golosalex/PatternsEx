using System;
using System.Text;

namespace BilderPattern
{
    public class HTMLPage
    {
        public string Head { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("<!DOCTYPE html> < html lang = \"en\" >< head >< meta charset = \"UTF-8\" >< title > Title </ title ></ head >< body >");
            result.Append(Head);
            result.Append(Body);
            result.Append(Footer);
            result.Append("</body>");
            return result.ToString();
        }
    }
}