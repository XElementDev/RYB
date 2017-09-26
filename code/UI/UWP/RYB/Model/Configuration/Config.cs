using GalaSoft.MvvmLight;
using System;
using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model.AutoSave;

namespace XElement.RedYellowBlue.UI.UWP.Model.Configuration
{
#region not unit-tested
    [Shared] [Export( typeof( IConfig ) )] [Export( typeof( IAutoSaveTarget ) )]
    internal class Config : ViewModelBase, IConfig, IAutoSaveTarget
    {
        [ImportingConstructor]
        public Config()
        {
            this._roaming = new RoamingConfig();
            this._roaming.Read();
        }


        public Uri /*IConfig.*/BoxUrl
        {
            get
            {
                Uri boxUrl = null;

                if ( this.BoxUrlAsString != null )
                    boxUrl = new UriBuilder( this.BoxUrlAsString ).Uri;

                return boxUrl;
            }
        }


        public string /*IConfig.*/BoxUrlAsString
        {
            get { return this._roaming.BoxUrlAsString; }
            set
            {
                this._roaming.BoxUrlAsString = value;
                this.RaisePropertyChanged( nameof( this.BoxUrl ) );
                this.RaisePropertyChanged( nameof( this.BoxUrlAsString ) );
            }
        }


        public string /*IConfig.*/Password
        {
            get { return this._roaming.Password; }
            set
            {
                this._roaming.Password = value;
                this.RaisePropertyChanged( nameof( this.Password ) );
            }
        }


        void IAutoSaveTarget.Persist()
        {
            ((IAutoSaveTarget)this._roaming).Persist();
        }


        public string /*IConfig.*/Username
        {
            get { return this._roaming.Username; }
            set
            {
                this._roaming.Username = value;
                this.RaisePropertyChanged( nameof( this.Username ) );
            }
        }


        private RoamingConfig _roaming;
    }
#endregion
}
