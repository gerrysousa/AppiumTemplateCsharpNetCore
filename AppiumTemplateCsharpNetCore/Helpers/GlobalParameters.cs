using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITestNetCore.Helpers;

namespace AppiumTemplateCsharpNetCore.Helpers
{
    class GlobalParameters
    {
        //---Config geral
        public static string CONFIG_DEVICE_TYPE = BuilderJson.ReturnParameterAppSettings("CONFIG_DEVICE_TYPE");
        public static string CONFIG_GET_SCREENSHOT_FOR_EACH_STEP = BuilderJson.ReturnParameterAppSettings("CONFIG_GET_SCREENSHOT_FOR_EACH_STEP");
        public static string CONFIG_REPORT_NAME = BuilderJson.ReturnParameterAppSettings("CONFIG_REPORT_NAME");
        public static int CONFIG_DEFAULT_TIMEOUT_IN_SECONDS = Int32.Parse(BuilderJson.ReturnParameterAppSettings("CONFIG_DEFAULT_TIMEOUT_IN_SECONDS"));
        public static string CONFIG_ENVIRONMENT = BuilderJson.ReturnParameterAppSettings("CONFIG_ENVIRONMENT");
        public static string CONFIG_EXECUTION = BuilderJson.ReturnParameterAppSettings("CONFIG_EXECUTION");

        //---Appium config
        public static string APPIUM_IP_ADDRESS = BuilderJson.ReturnParameterAppSettings("APPIUM_IP_ADDRESS");
        public static string APPIUM_PORT = BuilderJson.ReturnParameterAppSettings("APPIUM_PORT");
        public static string APPIUM_SERVER = BuilderJson.ReturnParameterAppSettings("APPIUM_SERVER");
        public static string APPIUM_VERSION = BuilderJson.ReturnParameterAppSettings("APPIUM_VERSION");

        //---Android config
        public static string ANDROID_PLATAFORM_NAME = BuilderJson.ReturnParameterAppSettings("ANDROID_PLATAFORM_NAME");
        public static string ANDROID_PLATAFORM_VERSION = BuilderJson.ReturnParameterAppSettings("ANDROID_PLATAFORM_VERSION");
        public static string ANDROID_DEVICE_NAME = BuilderJson.ReturnParameterAppSettings("ANDROID_DEVICE_NAME");
        public static string ANDROID_APP = BuilderJson.ReturnParameterAppSettings("ANDROID_APP");
        public static string ANDROID_AUTOMATION_NAME = BuilderJson.ReturnParameterAppSettings("ANDROID_AUTOMATION_NAME");
        public static string ANDROID_BROWSER_NAME = BuilderJson.ReturnParameterAppSettings("ANDROID_BROWSER_NAME");
        public static string ANDROID_UDID = BuilderJson.ReturnParameterAppSettings("ANDROID_UDID");
        public static string ANDROID_NO_RESET = BuilderJson.ReturnParameterAppSettings("ANDROID_NO_RESET");
        public static string ANDROID_FULL_RESET = BuilderJson.ReturnParameterAppSettings("ANDROID_FULL_RESET");
        public static string ANDROID_APP_ACTIVITY = BuilderJson.ReturnParameterAppSettings("ANDROID_APP_ACTIVITY");
        public static string ANDROID_APP_PACKAGE = BuilderJson.ReturnParameterAppSettings("ANDROID_APP_PACKAGE");
        public static string ANDROID_ORIENTATION = BuilderJson.ReturnParameterAppSettings("ANDROID_ORIENTATION");

        //---iOS config
        public static string IOS_UDID = BuilderJson.ReturnParameterAppSettings("IOS_UDID");
        public static string IOS_PLATFORM_NAME = BuilderJson.ReturnParameterAppSettings("IOS_PLATFORM_NAME");
        public static string IOS_PLATFORM_VERSION = BuilderJson.ReturnParameterAppSettings("IOS_PLATFORM_VERSION");
        public static string IOS_BUNDLE_ID = BuilderJson.ReturnParameterAppSettings("IOS_BUNDLE_ID");
        public static string IOS_NO_RESET = BuilderJson.ReturnParameterAppSettings("IOS_NO_RESET");
        public static string IOS_FULL_RESET = BuilderJson.ReturnParameterAppSettings("IOS_FULL_RESET");
        public static string IOS_AUTOMATION_NAME = BuilderJson.ReturnParameterAppSettings("IOS_AUTOMATION_NAME");
        public static string IOS_DEVICE_NAME = BuilderJson.ReturnParameterAppSettings("IOS_DEVICE_NAME");
        public static string IOS_APP = BuilderJson.ReturnParameterAppSettings("IOS_APP");

        //---DeviceFarm config
        public static string DEVICE_FARM_KEY = BuilderJson.ReturnParameterAppSettings("DEVICE_FARM_KEY");
        public static string DEVICE_FARM_URL = BuilderJson.ReturnParameterAppSettings("DEVICE_FARM_URL");


    }
}
