using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace LightFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();

            
            Settings.URL = configurationRoot.GetSection("testSettings").Get<TestSettings>().URL;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;       
            Settings.AppConnectionString = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUTConnectionString;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
            Settings.IsRemoteDriver = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsRemoteDriver;

        }

    }
}
