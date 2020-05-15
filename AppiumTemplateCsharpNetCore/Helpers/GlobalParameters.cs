using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumTemplateCsharpNetCore.Helpers
{
    class GlobalParameters
    {
        //---Config geral
        public static string ENVIRONMENT = "CONFIG_ENVIRONMENT";
        public static string DEVICE_TYPE = "CONFIG_DEVICE_TYPE";
        public static int TIMEOUT_DEFAULT = 60;
        public static string REPORT_NAME = "CONFIG_REPORT_NAME";
        public static bool GET_SCREENSHOT_FOR_EACH_STEP = false;
        public static string DOWNLOAD_DEFAULT_PATH;
        public static string REPORT_PATH;
        public static string pathProject = "GeneralHelpers.ReturnProjectPath()";
        public static string reportName = "CONFIG_REPORT_NAME" + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        //---Appium config
        public static string AppiumAutomationName = "APPIUM_AUTOMATION_NAME";
        public static string AppiumIPAddress = "APPIUM_IP_ADDRESS";
        public static string AppiumPort = "APPIUM_PORT";
        public static string AppiumVersion = "APPIUM_VERSION";
        public static string AppiumServerName = "APPIUM_SERVER";

        //---Android config
        public static string AndroidDeviceName = "ANDROID_DEVICE_NAME";
        public static string AndroidUDID = "ANDROID_UDID";
        public static string AndroidPlatformName = "ANDROID_PLATAFORM_NAME";
        public static string AndroidPlatformVersion = "ANDROID_PLATAFORM_VERSION";
        public static string AndroidAppPackage = "ANDROID_APP_PACKAGE";
        public static string AndroidAppActivity = "ANDROID_APP_ACTIVITY";
        public static string AndroidAppPath = pathProject + "Resources/App/Android/" + "ANDROID_APP";
        public static string AndroidBrowserName = "";
        public static bool AndroidNoReset = false;
        public static bool AndroidFullReset = false;
        public static string AndroidOrientation = "ANDROID_ORIENTATION";

        //---iOS config
        public static string IOSUDID = "IOS_UDID";
        public static string IOSPlatformName = "IOS_PLATFORM_NAME";
        public static string IOSPlatformVersion = "IOS_PLATFORM_VERSION";
        public static string IOSBundleId = "IOS_BUNDLE_ID";
        public static bool IOSNoReset = false;
        public static bool IOSFullReset = false;
        public static string IOSAutomationName = "IOS_AUTOMATION_NAME";
        public static string IOSDeviceName = "IOS_DEVICE_NAME";
        public static string IOSAppPath = pathProject + "Resources/App/iOS/" + "IOS_APP";
        public static string IOSReportFormat;
        public static string IOSTestName;
        public static string IOSSendKeyStrategy;

        //---DeviceFarm config
        public static string TestObjectApiKey = "TEST_OBJECT_API_KEY";
        public static string TestObjectURL = "TEST_OBJECT_URL";

        //---variaveis B2C
        public static string B2C_TOKEN_PADRAO = "B2C_TOKEN_PADRAO";
        public static string B2C_SENHA_SISTEMA_PADRAO = "B2C_SENHA_SISTEMA_PADRAO";
        public static string B2C_SENHA_CARTAO_PADRAO = "B2C_SENHA_CARTAO_PADRAO";
        public static string B2C_TELEFONE_PADRAO = "B2C_TELEFONE_PADRAO";
        public static string B2C_CEP_COM_BAIRRO = "B2C_CEP_COM_BAIRRO";
        public static string B2C_CEP_SEM_BAIRRO = "B2C_CEP_SEM_BAIRRO";
        public static string B2C_EMAIL_PADRAO = "B2C_EMAIL_PADRAO";
        public static string B2C_DATA_NASCIMENTO_PADRAO = "B2C_DATA_NASCIMENTO_PADRAO";

        //public GlobalParameters()
        //{
        //    if ("CONFIG_ENVIRONMENT == "qa" || "CONFIG_ENVIRONMENT == "QA")
        //    {

        //    }
        //    else
        //    {
        //        //url = "DEV_URL";

        //    }
        //}
    }
}
