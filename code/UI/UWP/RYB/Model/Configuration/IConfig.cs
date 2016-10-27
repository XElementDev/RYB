using System;

namespace XElement.RedYellowBlue.UI.UWP.Model
{
    public interface IConfig
    {
        Uri BoxUrl { get; }


        string BoxUrlAsString { get; set; }


        string Password { get; set; }


        string Username { get; set; }
    }
}
