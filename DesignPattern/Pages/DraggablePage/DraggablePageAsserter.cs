using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertFirstTabSourceAttribute(this DraggablePage page, string text)
        {
            Assert.AreEqual(text, page.SourceFirstTab.GetAttribute("class"));
        }

        public static void AssertFirstTabSourceLocation(this DraggablePage page)
        {
            Assert.AreNotSame(page.SourceFirstTab.Location, page.SourceFirstTab.Location);
        }
    }
}
