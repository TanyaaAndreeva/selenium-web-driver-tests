﻿

using ExamPep1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExamPep1.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public LoginPage loginPage;

        public CreateIdeaPage createIdeaPage;

        public MyIdeasPage myIdeasPage;

        public IdeasReadPage ideasReadPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            createIdeaPage = new CreateIdeaPage(driver);
            myIdeasPage = new MyIdeasPage(driver);
            ideasReadPage = new IdeasReadPage(driver);

            loginPage.OpenPage();
            loginPage.Login("t_test@test.bg", "123456");  
            
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "abcdefghtyedfsfe";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
         }
    }
}
