using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Resources
{
#region not unit-tested
    [Shared] [Export]
    internal class SvgSwitch : SvgBase
    {
        //  link: http://www.flaticon.com/free-icon/plug-for-electric-connection_25793#term=plug&page=3&position=89

        [ImportingConstructor]
        public SvgSwitch() : base() { }


        protected override string FileName { get { return "plug-for-electric-connection.svg"; } }
    }
#endregion
}
