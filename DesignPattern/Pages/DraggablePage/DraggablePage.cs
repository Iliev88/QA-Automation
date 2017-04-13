using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DesignPattern.Pages.DraggablePage
{
    public partial class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return url + "draggable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragFirstTab()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(SourceFirstTab).MoveByOffset(10, 10);

            drag.Perform();
        }
    }
}
