using System;
using System.Collections.Generic;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    public interface ILoginRecognizer
    {
        LoginType GetLoginType( Uri fritzBoxUrl );


        IEnumerable<string> SupportedFritzOsVersions { get; }
    }
}
