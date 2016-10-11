using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model.AutoSave;

namespace XElement.RedYellowBlue.UI.UWP.Model.Configuration
{
#region not unit-tested
    [Shared] [Export( typeof( IConfig ) )] [Export( typeof( IAutoSaveTarget ) )]
    internal class Config : IConfig, IAutoSaveTarget
    {
        [ImportingConstructor]
        public Config()
        {
            this._roaming = new RoamingConfig();
            this._roaming.Read();
        }


        public string /*IConfig.*/BoxUrl
        {
            get { return this._roaming.BoxUrl; }
            set { this._roaming.BoxUrl = value; }
        }


        public string /*IConfig.*/Password
        {
            get { return this._roaming.Password; }
            set { this._roaming.Password = value; }
        }


        void IAutoSaveTarget.Persist()
        {
            ((IAutoSaveTarget)this._roaming).Persist();
        }


        public string /*IConfig.*/Username
        {
            get { return this._roaming.Username; }
            set { this._roaming.Username = value; }
        }


        private RoamingConfig _roaming;
    }
#endregion
}
