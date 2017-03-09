using System;
using System.ComponentModel;

namespace XElement.RedYellowBlue.UI.UWP.Model
{
    public interface IConfig : INotifyPropertyChanged
    {
        Uri BoxUrl { get; }


        string BoxUrlAsString { get; set; }


        string Password { get; set; }


        string Username { get; set; }
    }
}
