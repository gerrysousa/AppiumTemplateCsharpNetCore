using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Reflection;
using AppiumTemplateCsharpNetCore.Helpers;

namespace UITestNetCore.Helpers
{
    public class GeneralHelpers
    {
        public static string ReturnStringWithRandomCharacters(int size)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ReturnStringWithRandomNumbers(int size)
        {
            Random random = new Random();

            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static IEnumerable ReturnCSVData(string csvPath)
        {
            using (StreamReader sr = new StreamReader(csvPath, CodePagesEncodingProvider.Instance.GetEncoding(1252)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ArrayList result = new ArrayList();
                    result.AddRange(line.Split(';'));
                    yield return result;
                }
            }
        }

        public static string GetScreenshot(string path)
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string date = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "-");

            Screenshot screenShot = ((ITakesScreenshot)DriverFactory.INSTANCE).GetScreenshot();
            string filePathAndName = path + "/" + testName + "_" + date + ".png";
            screenShot.SaveAsFile(filePathAndName, ScreenshotImageFormat.Png);

            return filePathAndName;
        }

        public static string GetProjectPath()
        {
            string pth = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            return new Uri(actualPath).LocalPath;
        }

        public static string GetProjectBinDebugPath()
        {
            return GetProjectPath() + "bin\\Debug\\" + GlobalParameters.CONFIG_PATH_DEBUG_NET_CORE+"\\";
        }

        public static string GetProjectBinReleasePath()
        {
            string chromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return chromeDriverPath;            
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodNameByLevel(int level)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(level);
            return sf.GetMethod().Name;
        }

        public static string GetRandomIDNumber()
        {
            return Guid.NewGuid().ToString();
        }

        public static void EnsureDirectoryExists(string fullReportFilePath)
        {
            var directory = Path.GetDirectoryName(fullReportFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        public static string GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }
    }
}
