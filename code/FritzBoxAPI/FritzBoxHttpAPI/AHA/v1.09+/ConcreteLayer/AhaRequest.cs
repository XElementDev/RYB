using System;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109_.ConcreteLayer
{
#region not unit-tested
    internal class AhaRequest : v109.ConcreteLayer.AhaRequest
    {
        public AhaRequest( Uri fritzBoxUrl, v109.ConcreteLayer.AhaCmd switchcmd, string sid )
            : base( fritzBoxUrl, switchcmd, sid ) { }
    }
#endregion
}
