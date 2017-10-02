using Mntone.SvgForXaml;
using System.IO;
using System.Reflection;

namespace XElement.RedYellowBlue.UI.UWP.Resources
{
#region not unit-tested
    internal abstract class SvgBase
    {
        protected SvgBase()
        {
            this.LoadSvg();
        }


        protected abstract string FileName { get; }


        private void LoadSvg()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            using ( var resourceStream = assembly.GetManifestResourceStream( this.ResourceName ) )
            using ( var reader = new StreamReader( resourceStream ) )
            {
                var document = reader.ReadToEnd();
                this.Svg = SvgDocument.Parse( document );
            }
        }


        private string ResourceName { get { return NAMESPACE + "." + this.FileName; } }


        public SvgDocument Svg { get; private set; }


        private const string NAMESPACE = "XElement.RYB.UI.UWP.Assets";
    }
#endregion
}
