using System.Composition;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
    [Shared] [Export( typeof( ILoginRecognizer ) )]
    internal class MefLoginRecognizer : 
        global::XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer.LoginRecognizer
    { }
}
