

using OpenQA.Selenium;

namespace ExamPep1.Pages
{
    public class CreateIdeaPage :BasePage
    {
        public CreateIdeaPage(IWebDriver driver): base(driver)
        {
             
        }

        public string Url = BaseUrl + "/Ideas/Create";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));

        public IWebElement ImageInput => driver.FindElement(By.XPath("//input[@name='Url']"));

        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//textarea[@type='text']"));

        public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

        public IWebElement TitleErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Title field is required.']"));

        public IWebElement DescriptionErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Description field is required.']"));


        public void CreateIdea(string title, string imageUrl, string description)
        {
            TitleInput.SendKeys(title);
            ImageInput.SendKeys(imageUrl);
            DescriptionInput.SendKeys(description);
            CreateButton.Click();
        }

        public void AssertErrorMessages()
        {
            Assert.True(MainErrorMessage.Text.Equals("Unable to create new Idea!"), "Main messgae is not as expected");

            Assert.True(TitleErrorMessage.Text.Equals("The Title field is required."), "Title error message is not as expected");

            Assert.True(DescriptionErrorMessage.Text.Equals("The Description field is required."), "Description error message is not as expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);


        }



    }
}
