using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ToolsQAHomePage
{
    public partial class ToolsQAHomePage
    {
        public IWebElement Logo
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"page\"]/div[1]/header/div/a/img"));
            }
        }
    }
}
