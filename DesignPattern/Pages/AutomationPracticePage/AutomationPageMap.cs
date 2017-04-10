using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.AutomationPracticePage
{
    public partial class AutomationPage
    {
        public IWebElement NewTabButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"content\"]/p[4]/button"));
            }
        }

    }
}
