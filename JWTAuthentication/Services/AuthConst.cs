namespace JWTAuthentication.Const;

public class AuthConst
{
    public static readonly string PARAM_APPLICATION = "Auth";
    public static readonly string PARAM_MODULE_NAME = PARAM_APPLICATION + ".moduleName";
    public static readonly string PARAM_ACTION_NAME = PARAM_APPLICATION + ".actionName";

    public static string DB_CONNECTION;

    public static string TOKEN_SECRECT;
    public static string TOKEN_ISSUER;

    public static string MODULE_NAME_USERACCOUNT;

    public static string ACTION_NAME_VIEW;
    public static string ACTION_NAME_ADD_OR_EDIT;
    public static string ACTION_NAME_DELETE;

    public static void LoadConfigData()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\appsetting.config");
        var xml = System.Xml.Linq.XElement.Load(filePath);
        var xmlRetriever = new XmlRetrieverService(xml);

        DB_CONNECTION = xmlRetriever.GetParameter(PARAM_APPLICATION + ".dbConnection");

        TOKEN_SECRECT = xmlRetriever.GetParameter(PARAM_APPLICATION + ".tokenSecrect");
        TOKEN_ISSUER = xmlRetriever.GetParameter(PARAM_APPLICATION + ".tokenIssuer");

        MODULE_NAME_USERACCOUNT = xmlRetriever.GetParameter(PARAM_MODULE_NAME + ".userAccount");

        ACTION_NAME_VIEW = xmlRetriever.GetParameter(PARAM_ACTION_NAME + ".view");
        ACTION_NAME_ADD_OR_EDIT = xmlRetriever.GetParameter(PARAM_ACTION_NAME + ".addOrEdit");
        ACTION_NAME_DELETE = xmlRetriever.GetParameter(PARAM_ACTION_NAME + ".delete");
    }
}
