

using ExamPep1.Pages;

namespace ExamPep1.Tests
{
    public class IdeaCentreTests : BaseTest
    {
        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;



        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea("", "", "");

            createIdeaPage.AssertErrorMessages();
        }
        [Test, Order(2)]
        public void CreateIdeaWithValidDataTest()
        {
            lastCreatedIdeaTitle = "Idea " + GenerateRandomString(5);
            lastCreatedIdeaDescription = "Description " + GenerateRandomString(5);
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);

            //createIdeaPage.AssertErrorMessages();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Url is not correct");

            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Description not match");


        }

        [Test, Order(3)]
        public void ViewLastCreatedIdea()
        {

            myIdeasPage.OpenPage(); 
            myIdeasPage.ViewButtonLastIdea.Click();
            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "Title do not match");
            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Description do not match");

        }

    }
}


