using TestStack.Seleno.Configuration;

namespace HttpMockSocketExceptionSample
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

        static Host()
        {
            Instance.Run("HttpMockSocketExceptionSample", 5005, c => c
              .WithRemoteWebDriver(BrowserFactory.Chrome));
        }
    }
}
