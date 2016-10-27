using Windows.UI.Xaml;

namespace XElement.RedYellowBlue.UI.UWP.Modules.GitHubLink
{
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel() { }


        public bool IsInDarkMode
        {
            get { return Application.Current.RequestedTheme == ApplicationTheme.Dark; }
        }
    }
#endregion
}
