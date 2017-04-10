using DesignPattern.Pages.AutomationPracticePage;
using DesignPattern.Pages.DroppablePage;
using DesignPattern.Pages.ToolsQAHomePage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    [TestFixture]
    public class ToolsQATests
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Priority", "3")]
        public void HandlePopUp()
        {
            var automationPage = new AutomationPage(driver);
            var homePage = new ToolsQAHomePage(driver);

            driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";

            automationPage.NewTabButton.Click();

            var firstTabName = driver.WindowHandles.First();

            driver.SwitchTo().ActiveElement();
            var secondTabName = driver.WindowHandles.Last();
            //secondTabName.Close();

            Assert.AreEqual("http://toolsqa.com/wp-content/uploads/2014/08/Toolsqa.jpg", homePage.Logo.GetAttribute("src"));
            Assert.AreEqual(1, driver.WindowHandles.Count);
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Priority", "3")]
        public void DroppableFirstTry()
        {
            var droppablePage = new DroppablePage(driver);

            driver.Url = droppablePage.URL;
            Actions builder = new Actions(driver);

            var drag = builder.DragAndDrop(droppablePage.Source, droppablePage.Target);
            drag.Perform();

            Assert.AreEqual("ui-widget-header ui-droppable ui-state-highlight", droppablePage.Target.GetAttribute("class"));
        }
    }
}
