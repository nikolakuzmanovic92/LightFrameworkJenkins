using LightFramework.Base;
using LightFramework.Extensions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Test.Pages;

namespace Test
{
    [TestFixture]
    class Test1 : BaseTest
    {

        [Test]
        public void DefaultLoginCheck()
        {
            CurrentPage = new DefaultPage(Driver);
            CurrentPage = CurrentPage.As<DefaultPage>().ClickLogin();
            CurrentPage = CurrentPage.As<LogInPage>().LogIn();
            
            Assert.IsTrue(CurrentPage.As<HomePage>().CheckLoginSuccessfull());

        }
        [Test]
        public void CheckDropdown()
        {
            CurrentPage = new DefaultPage(Driver);
            CurrentPage = CurrentPage.As<DefaultPage>().ClickLogin();
            CurrentPage = CurrentPage.As<LogInPage>().LogIn();
            CurrentPage = CurrentPage.As<HomePage>().ManageUsers();
            CurrentPage.As<ManageUsersPage>().SetRoleToUser("guest", "Guest"); 
        }



    }
}
