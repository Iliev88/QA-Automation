using DesignPattern.Pages.AutomationPracticePage;
using DesignPattern.Pages.DraggablePage;
using DesignPattern.Pages.DroppablePage;
using DesignPattern.Pages.ResizablePage;
using DesignPattern.Pages.SelectablePage;
using DesignPattern.Pages.SortablePage;
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
    public class AdvancedTests
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
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }

        // DROPPABLE PAGE TESTS
        [Test]
        [Author("Iliya Iliev")]
        [Property("Droppable", "1")]
        public void DroppableFirstTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateTo();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Droppable", "1")]
        public void DroppableSecondTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateTo();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValueId("droppableview");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Droppable", "1")]
        public void DroppableThirdTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateTo();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetText("Dropped!");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Droppable", "1")]
        public void DroppableFourthTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateToSecondTab();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Droppable", "1")]
        public void DroppableFifthTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateToSecondTab();
            droppablePage.DragAndDropSecondTab();

            droppablePage.AssertSecondTabTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Droppable", "1")]
        public void DroppableSixthTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateToSecondTab();
            droppablePage.DragAndDropSecondTab();

            droppablePage.AssertTextSecondTarget("Dropped!");
        }

        // DRAGGABLE PAGE TESTS
        [Test]
        [Author("Iliya Iliev")]
        [Property("Draggable", "1")]
        public void DraggableFirstTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateTo();
            draggablePage.DragFirstTab();

            draggablePage.AssertFirstTabSourceAttribute("ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Draggable", "1")]
        public void DraggableSecondTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateTo();
            draggablePage.DragFirstTab();

            draggablePage.AssertFirstTabSourceLocation();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Draggable", "1")]
        public void DraggableThirdTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragVertical();

            draggablePage.AssertSecondTabVerticalSourceLocation();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Draggable", "1")]
        public void DraggableFourthTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragVertical();

            draggablePage.AssertSecondTabVerticalSourceAttribute("draggable ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Draggable", "1")]
        public void DraggableFifthTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragHorizontal();

            draggablePage.AssertSecondTabHorizontalSourceLocation();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Draggable", "1")]
        public void DraggableSixthTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragHorizontal();

            draggablePage.AssertSecondTabHorizontalSourceAttribute("draggable ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }

        // RESIZABLE PAGE TESTS
        [Test]
        [Author("Iliya Iliev")]
        [Property("Resizable", "1")]
        public void ResizableFirstTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(100, 100);

            resizablePage.AssertNewSize();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Resizable", "1")]
        public void ResizableSecondTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(100, 0);

            resizablePage.AssertNewSizeWidth();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Resizable", "1")]
        public void ResizableThirdTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(0, 100);

            resizablePage.AssertNewSizeHeight();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Resizable", "1")]
        public void ResizableFourthTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.ResizeWindowWithoutDropping();

            resizablePage.AssertWindowAttribute("ui-widget-content ui-resizable ui-resizable-resizing");
        }

        // SELECTABLE PAGE TESTS
        [Test]
        [Author("Iliya Iliev")]
        [Property("Selectable", "1")]
        public void SelectableFirstTest()
        {
            var selectablePage = new SelectablePage(driver);

            selectablePage.NavigateTo();
            selectablePage.DragAndDropOneItem();

            selectablePage.AssertSelectedItemAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Selectable", "1")]
        public void SelectableSecondTest()
        {
            var selectablePage = new SelectablePage(driver);

            selectablePage.NavigateTo();
            selectablePage.DragAndDropTwoItems();

            selectablePage.AssertSelectedItemAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Selectable", "1")]
        public void SelectableThirdTest()
        {
            var selectablePage = new SelectablePage(driver);

            selectablePage.NavigateTo();
            selectablePage.SelectItemWithoutDropping();

            selectablePage.AssertSelectedItemAttribute("ui-widget-content ui-corner-left ui-selectee ui-selecting");
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Sortable", "1")]
        public void SortableFirstTest()
        {
            var sortablePage = new SortablePage(driver);

            sortablePage.NavigateTo();
            sortablePage.DragAndDrop();

            sortablePage.AssertTargetLocation();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Sortable", "1")]
        public void SortableSecondTest()
        {
            var sortablePage = new SortablePage(driver);

            sortablePage.NavigateTo();
            sortablePage.ReverseDragAndDrop();

            sortablePage.AssertTargetLocation();
        }

        [Test]
        [Author("Iliya Iliev")]
        [Property("Sortable", "1")]
        public void SortableThirdTest()
        {
            var sortablePage = new SortablePage(driver);

            sortablePage.NavigateTo();
            sortablePage.SortWithoutDropping();

            sortablePage.AssertSortingItemAttribute("ui-state-default ui-corner-left ui-sortable-handle ui-sortable-helper");
        }
    }
}
