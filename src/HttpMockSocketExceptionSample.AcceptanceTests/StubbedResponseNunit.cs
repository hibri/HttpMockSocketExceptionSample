using HttpMock;
using NUnit.Framework;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace HttpMockSocketExceptionSample
{
    [TestFixture]
    public class StubbedResponseNunit
    {
        private IHttpServer stubHttp;

        [Test]
        public void Index_WhenHttpIsStubbed_ReturnStubbedValue()
        {
            stubHttp = HttpMockRepository.At("http://localhost:9009");
            stubHttp.Stub(x => x.Get("/Stub")).Return("I AM A STUB").OK();


            var page = Host.Instance.NavigateToInitialPage<Page>("/");

            var actual = page.Find.Element(By.CssSelector("*")).Text;
            Assert.That(actual, Is.StringContaining("I AM A STUB"));
        }
    }
}