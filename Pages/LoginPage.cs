

using OpenQA.Selenium;

namespace ExamPep1.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Users/Login";

        public IWebElement EmailInput => driver.FindElement(By.XPath(
           "//input[@type='email']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath(
        "//input[@type='password']"));

        public IWebElement SigningInButton => driver.FindElement(By.XPath(
        "//button[@class='btn btn-primary btn-lg btn-block']"));

        public void Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SigningInButton.Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
