using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Resources
{
#region not unit-tested
    [Shared] [Export]
    internal class SvgThermostat : SvgBase
    {
        //  link: http://www.flaticon.com/free-icon/heating_34915#term=heating&page=1&position=83

        [ImportingConstructor]
        public SvgThermostat() : base() { }


        protected override string FileName { get { return "heating.svg"; } }
    }
#endregion
}
