using System.Xml.Linq;

namespace JWTAuthentication.Services;

public class XmlRetrieverService
{
    private XElement root;
    public XmlRetrieverService(XElement _root)
    {
        root = _root;
    }

    public string GetParameter(string param)
    {
        string value = null;
        XElement demiChild = null;
        try
        {
            var tokens = param.Split('.');
            for (var i = 0; i < 100; i++)
            {
                XElement child;
                if (i == 0)
                {
                    child = root.Element(tokens[i]);
                }
                else
                {
                    child = demiChild.Element(tokens[i]);
                }
                if (i == tokens.Length - 1)
                {
                    value = child.Value;
                    break;
                }
                demiChild = child;
            }
            return value;
        }
        catch
        {
            return null;
        };
    }
}