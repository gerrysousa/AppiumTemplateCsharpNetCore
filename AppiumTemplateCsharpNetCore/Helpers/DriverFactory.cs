using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumTemplateCsharpNetCore.Helpers
{
    class DriverFactory
    {
        public static AppiumDriver<AppiumWebElement> INSTANCE { get; set; } = null;
        public static AppiumLocalService appiumLocalService;
        public WebDriverWait wait;

        public static void CreateInstance()
        {
            try
            {
                string deviceType = GlobalParameters.DEVICE_TYPE;
                string enviroment = GlobalParameters.ENVIRONMENT;

                if (INSTANCE == null)
                {
                    appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
                    appiumLocalService.Start();

                    switch (enviroment)
                    {
                        case "Local":
                            if (deviceType.Equals("Android"))
                            {
                                var appiumOptions = new AppiumOptions();
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.AndroidAppPath);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.AndroidDeviceName);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.AndroidPlatformName);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.AndroidUDID);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.AndroidPlatformVersion);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.AndroidBrowserName);

                                //Opcionais
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, GlobalParameters.TIMEOUT_DEFAULT);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, GlobalParameters.AndroidNoReset);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, GlobalParameters.AndroidFullReset);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.Orientation, GlobalParameters.AndroidOrientation);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.AppiumAutomationName);

                                INSTANCE = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.AppiumServerName), appiumOptions, TimeSpan.FromSeconds(GlobalParameters.TIMEOUT_DEFAULT));
                            }
                            if (deviceType.Equals("IOS"))
                            {
                                var appiumOptions = new AppiumOptions();
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.IOSPlatformName);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.IOSPlatformVersion);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.IOSDeviceName);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.IOSAutomationName);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.IOSAppPath);
                                //appiumOptions.AddAdditionalCapability("autoAcceptAlerts", "true");
                                //appiumOptions.AddAdditionalCapability("unicodeKeyboard", "true");
                                //appiumOptions.AddAdditionalCapability("resetKeyboard", "true");

                                //appiumOptions.AddAdditionalCapability("autoDismissAlerts", "true");
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.bundleId", GlobalParameters.IOSBundleId);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.IOSUDID);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.IosBrowserName);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset", GlobalParameters.IOSNoReset);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset", GlobalParameters.IOSFullReset);

                                INSTANCE = new IOSDriver<AppiumWebElement>(new Uri(GlobalParameters.AppiumServerName), appiumOptions);
                            }

                            break;

                        case "Remoto":
                            if (deviceType.Equals("Android"))
                            {
                                var appiumOptions = new AppiumOptions();
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.AndroidPlatformName);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.AppiumAutomationName);
                                appiumOptions.AddAdditionalCapability("testobject_api_key", GlobalParameters.TestObjectApiKey);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, GlobalParameters.AppiumVersion);

                                INSTANCE = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.TestObjectURL), appiumOptions);
                            }
                            else if (deviceType == "IOS")
                            {

                            }
                            break;

                        default:
                            throw new Exception("O devive informado não existe ou não é suportado pela automação");
                    }
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        public static void QuitInstace()
        {
            if (INSTANCE != null)
            {
                INSTANCE.Quit();
                INSTANCE.Dispose();
                INSTANCE = null;
            }
        }
    }
}
