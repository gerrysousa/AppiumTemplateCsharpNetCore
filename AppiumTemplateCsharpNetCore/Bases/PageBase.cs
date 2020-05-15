using AppiumTemplateCsharpNetCore.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects;
using System.Threading;
using System.Drawing;
using UITestNetCore.Helpers;
using PageFactoryCore;

namespace AppiumTemplateCsharpNetCore.Bases
{
    public class PageBase
    {
        //Variaveis globlais
        protected AppiumDriver<AppiumWebElement> driver { get; private set; }
        public WebDriverWait wait { get; private set; }
        protected IJavaScriptExecutor javaScriptExecutor { get; private set; }
        private int countException = 0;

        //Construtor
        public PageBase()
        {
            DriverFactory.CreateInstance();
            driver = DriverFactory.INSTANCE;
            AppiumPageObjectMemberDecorator decorator = new AppiumPageObjectMemberDecorator(new TimeOutDuration(System.TimeSpan.FromSeconds(GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS)));
            //PageFactory.InitElements(driver, this, decorator);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS));
            javaScriptExecutor = (IJavaScriptExecutor)driver;
        }

        protected void AguardarLoading1()
        {
            //By loading = By.Id("br.com.ole.oleconsignado.staging:id/progress");
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loading));

            //By loading2 = By.XPath("//center/div[@mode='indeterminate']");
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loading2));
        }

        protected void WaitForElement(IWebElement element)
        {
            countException++;
            AguardarLoading();
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception)
            {
                ExtentReportHelpers.AddTestInfo(4, "Wait Exception!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + countException);
                if (countException < 2)
                {
                    WaitForElement(element);
                }
            }

        }

        protected void WaitForElementToBeClickeable(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        protected void WaitForElementByTime(IWebElement element, int time)
        {
            WebDriverWait waitTime = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(time));
        }

        protected void Click(IWebElement element)
        {
            AguardarLoading();
            WebDriverException possibleWebDriverException = null;
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();
            while ((((int)timeOut.Elapsed.TotalSeconds) / 1000) <= GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS)
            {
                try
                {
                    TouchAction action = new TouchAction(DriverFactory.INSTANCE);
                    action.Tap(element);
                    // action.SingleTap(element);
                    action.Perform();
                    action.Release();
                    ExtentReportHelpers.AddTestInfo(3, "");
                    timeOut.Stop();
                    return;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
                catch (WebDriverException e)
                {
                    possibleWebDriverException = e;
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }
                    throw e;
                }
            }
            try
            {
                throw new Exception(possibleWebDriverException.Message);
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }
        }

        protected void ClickByText(string text)
        {
            IWebElement element = driver.FindElementByXPath("//*[@text='" + text + "']");
            Click(element);
        }

        protected void ClickByName(string text)
        {
            IWebElement element = driver.FindElementByXPath("//*[@name='" + text + "']");
            Click(element);
        }

        protected void SendKeys(IWebElement element, string text)
        {
            WaitForElement(element);
            Clear(element);
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void SendKeysWithoutWaitVisible(IWebElement element, string text)
        {
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void Clear(IWebElement element)
        {
            WaitForElement(element);
            element.Clear();
        }

        protected void clearAndSendKeys(IWebElement element, string text)
        {
            WaitForElement(element);
            element.Clear();
        }

        protected void ClearAndSendKeysAlternative(IWebElement element, string text)
        {
            WaitForElement(element);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(text);
        }

        protected string GetText(IWebElement element)
        {
            WaitForElement(element);
            string text = element.Text;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }

        protected string GetValue(IWebElement element)
        {
            WaitForElement(element);
            string text = element.GetAttribute("value");
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }

        protected bool ReturnIfElementIsDisplayed(IWebElement element)
        {
            AguardarLoading();
            bool result = element.Displayed;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected bool ReturnIfElementIsEnabled(IWebElement element)
        {
            WaitForElement(element);
            bool result = element.Enabled;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected bool ReturnIfElementIsSelected(IWebElement element)
        {
            WaitForElement(element);
            bool result = element.Selected;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected void scrollUsingTouchActions(int startX, int startY, int endX, int endY, int seconds)
        {
            TouchAction actions = new TouchAction(DriverFactory.INSTANCE);
            actions.Press(startX, startY).Wait(seconds).MoveTo(endX, endY).Release().Perform();
        }

        protected void longPress(IWebElement element)
        {
            WaitForElement(element);
            TouchActions action = new TouchActions(DriverFactory.INSTANCE);
            action.LongPress(element);
            action.Release();
            action.Perform();
        }

        protected void scrollingJavaScript(string direction)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverFactory.INSTANCE;
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", direction);
            js.ExecuteScript("mobile: scroll", scrollObject);
        }

        protected void Tap(IWebElement element)
        {
            WaitForElement(element);
            TouchActions action = new TouchActions(DriverFactory.INSTANCE);
            action.SingleTap(element);
            action.Perform();
        }

        protected void doubleTap(IWebElement element)
        {
            WaitForElement(element);           
            TouchActions action = new TouchActions(DriverFactory.INSTANCE);
            action.DoubleTap(element);
            action.Perform();
        }

        protected void ScrollUsingTouchActions(int xStart, int yStart, int xFinal, int yFinal)
        {
            TouchAction action = new TouchAction(DriverFactory.INSTANCE);
            action.Press(xStart, yStart);
            action.Wait(1000);
            action.MoveTo(xFinal, yFinal);
            action.Release();
            action.Perform();

            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected void ScrollDownAndroid()
        {
            ScrollUsingTouchActions(525, 1900, 525, 300);
        }

        protected void ScrollUpAndroid()
        {
            ScrollUsingTouchActions(525, 600, 525, 1900);
        }

        protected void ScrollLeftAndroid()
        {
            ScrollUsingTouchActions(90, 1100, 999, 1100);
        }

        protected void ScrollRightAndroid()
        {
            int width = DriverFactory.INSTANCE.Manage().Window.Size.Width;
            int height = DriverFactory.INSTANCE.Manage().Window.Size.Height;

                       int xInicial = 999;
            int yInicial = 1100;

            int xFinal = 90;
            int yFinal = 1100;

            ScrollUsingTouchActions(xInicial, yInicial, xFinal, yFinal);
        }

        protected bool ReturnIfElementExists___NaoFunciona(IWebElement element)
        {
            try
            {
                AguardarLoading();
                bool result = element.Enabled;
                bool result1 = element.Selected;
                bool result2 = element.Displayed;

                ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
                //ExtentReportHelpers.AddTestInfo(3, "RETURN:(Enabled):" + result+ " (Selected):" + result1+ "(Displayed):" + result2);
                return true;
            }
            catch (Exception)
            {
                ExtentReportHelpers.AddTestInfo(3, "RETURN: false");
                return false;
            }
        }

        protected bool ReturnIfTextExistsOnScreen(string text)
        {
            Thread.Sleep(2000);
            AguardarLoading();
            bool existe = driver.PageSource.Contains(text);
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + existe);
            return existe;
        }

        protected void AguardarLoading()
        {
            int aux = 0;
            while ((driver.PageSource.Contains("br.com.ole.oleconsignado.staging:id/progress")) && aux < GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS)
            {
                Thread.Sleep(2000);
                aux++;
                aux++;
            }

            while ((driver.PageSource.Contains("br.com.ole.oleconsignado.staging:id/sh_placeholder")) && aux < GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS)
            {
                Thread.Sleep(2000);
                aux++;
                aux++;
            }
        }

        protected void ScreenshotBase()
        {
            AguardarLoading();
            ExtentReportHelpers.AddTestScreenshot(3, " Screenshot!");
        }

        protected void ScrollVerticalWithParameter(int inicio, int final)
        {//"{Width = 1080 Height = 2088}";
            Size screenSize = DriverFactory.INSTANCE.Manage().Window.Size;

            int xMiddleScreen = screenSize.Width / 2;
            int yInitial = (int)(screenSize.Height * inicio) / 100;
            int yFinal = (int)(screenSize.Height * final) / 100;

            ScrollUsingTouchActions(xMiddleScreen, yInitial, xMiddleScreen, yFinal);
        }

        protected void ScrollHorizontalWithParameter(int inicio, int final)
        {//"{Width = 1080 Height = 2088}";
            Size screenSize = DriverFactory.INSTANCE.Manage().Window.Size;

            int yMiddleScreen = screenSize.Height / 2;

            int xInitial = (int)(screenSize.Height * inicio) / 100;
            int xFinal = (int)(screenSize.Height * final) / 100;

            ScrollUsingTouchActions(xInitial, yMiddleScreen, xFinal, yMiddleScreen);
        }

        protected void ScrollDownToText(string text)
        {//"{Width = 1080 Height = 2088}";
            AguardarLoading();

            Size screenSize = DriverFactory.INSTANCE.Manage().Window.Size;

            int xMiddleScreen = screenSize.Width / 2;
            int yInitial = (int)(screenSize.Height * 70) / 100;
            int yFinal = (int)(screenSize.Height * 20) / 100;
            
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();
            while (!ReturnIfTextExistsOnScreen(text) && ((int)timeOut.Elapsed.TotalSeconds) <= GlobalParameters.CONFIG_DEFAULT_TIMEOUT_IN_SECONDS)
            {
                try
                {
                    ScrollUsingTouchActions(xMiddleScreen, yInitial, xMiddleScreen, yFinal);
                    ExtentReportHelpers.AddTestInfo(3, "");
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            timeOut.Stop();
        }

    }
}
