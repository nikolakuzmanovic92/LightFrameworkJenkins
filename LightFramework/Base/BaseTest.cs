using LightFramework.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightFramework.Base
{
    [TestFixture]
    public class BaseTest : TestInitialize
    {
        public BasePage CurrentPage { get; set; }
        public BaseTest() : base() {}

        [SetUp]
        public void SetupForEachTest()
        {
            InitializeSettings();
            Driver.Navigate().GoToUrl(Settings.URL);

        }
        [TearDown]
        public void TearDownForEachTest()
        {
            if (Driver == null)
            {
                return;
            }
            Driver.Quit();
        }
    }
}

