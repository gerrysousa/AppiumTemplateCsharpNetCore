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
                string deviceType = GlobalParameters.CONFIG_DEVICE_TYPE;
                string enviroment = GlobalParameters.CONFIG_ENVIRONMENT;

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
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.ANDROID_APP);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.ANDROID_DEVICE_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.ANDROID_PLATAFORM_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.ANDROID_UDID);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.ANDROID_PLATAFORM_VERSION);

                                //Opcionais
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.ANDROID_BROWSER_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, GlobalParameters.ANDROID_NO_RESET);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, GlobalParameters.ANDROID_FULL_RESET);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.Orientation, GlobalParameters.ANDROID_ORIENTATION);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.ANDROID_AUTOMATION_NAME);

                                INSTANCE = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.APPIUM_SERVER), appiumOptions, TimeSpan.FromSeconds(GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS));
                            }
                            if (deviceType.Equals("IOS"))
                            {
                                var appiumOptions = new AppiumOptions();
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.IOS_PLATFORM_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.IOS_PLATFORM_VERSION);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.IOS_DEVICE_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.IOS_AUTOMATION_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.IOS_APP);
                                //appiumOptions.AddAdditionalCapability("autoAcceptAlerts", "true");
                                //appiumOptions.AddAdditionalCapability("unicodeKeyboard", "true");
                                //appiumOptions.AddAdditionalCapability("resetKeyboard", "true");

                                //appiumOptions.AddAdditionalCapability("autoDismissAlerts", "true");
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.bundleId", GlobalParameters.IOSBundleId);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.IOSUDID);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.IosBrowserName);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset", GlobalParameters.IOSNoReset);
                                //appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset", GlobalParameters.IOSFullReset);

                                INSTANCE = new IOSDriver<AppiumWebElement>(new Uri(GlobalParameters.APPIUM_SERVER), appiumOptions);
                            }

                            break;

                        case "Remoto":
                            if (deviceType.Equals("Android"))
                            {
                                var appiumOptions = new AppiumOptions();
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.ANDROID_PLATAFORM_NAME);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.ANDROID_AUTOMATION_NAME);
                                appiumOptions.AddAdditionalCapability("testobject_api_key", GlobalParameters.DEVICE_FARM_KEY);
                                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, GlobalParameters.APPIUM_VERSION);

                                INSTANCE = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.DEVICE_FARM_URL), appiumOptions);
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
