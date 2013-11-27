using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;
using HttpMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttpMockSocketExceptionSample
{
    [TestClass]
    public class StubbedResponse
    {
        private IHttpServer stubHttp;

        [TestMethod]
        public void Index_WhenHttpIsStubbed_ReturnStubbedValue()
        {
            stubHttp = HttpMockRepository.At("http://localhost:5009");
            stubHttp.Stub(x => x.Get("/Stub")).Return("I AM A STUB").OK();

            var page = Host.Instance.NavigateToInitialPage<Page>("/");

            var actual = page.Find.Element(By.CssSelector("*")).Text;
            Assert.IsTrue(actual.Contains("I AM A STUB"));
        }
    }
}
