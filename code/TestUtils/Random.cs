using XElement.RedYellowBlue.UI.UWP.Model;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.RedYellowBlue.TestUtils
{
    public static class Random
    {
        public static IConfig CreateConfigMockWithRandomCredentials()
        {
            var randomUrl = XeRandom.CreateString();
            var randomPassword = XeRandom.CreateString();
            var randomUsername = XeRandom.CreateString();
            var configMock = new StubIConfig()
                .BoxUrlAsString_Get( () => randomUrl )
                .Password_Get( () => randomPassword )
                .Username_Get( () => randomUsername );
            return configMock;
        }
    }
}
