using Mntone.SvgForXaml;
using System.Composition;
using System.IO;
using System.Reflection;

namespace XElement.RedYellowBlue.UI.UWP.Resources
{
#region not unit-tested
    [Shared] [Export]
    internal class SvgSwitch
    {
        [ImportingConstructor]
        public SvgSwitch()
        {
            this.LoadSvg();
        }


        private void LoadSvg()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            using ( var resourceStream = assembly.GetManifestResourceStream( RESOURCE_NAME ) )
            using ( var reader = new StreamReader( resourceStream ) )
            {
                var document = reader.ReadToEnd();
                this.Svg = SvgDocument.Parse( document );
            }
        }


        //  link: http://www.flaticon.com/free-icon/plug-for-electric-connection_25793#term=plug&page=3&position=89
        public SvgDocument Svg { get; private set; }


        private const string NAMESPACE = "XElement.RedYellowBlue.UI.UWP.Assets";

        private const string RESOURCE_NAME = NAMESPACE + "." + "plug-for-electric-connection.svg";
    }
#endregion
}
