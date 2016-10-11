namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    public class AnonymousLogin : LoginBase
    {
        public AnonymousLogin( string fritzBoxUri ) : base( fritzBoxUri ) { }


        protected override string /*LoginBase.*/GetSid()
        {
            var sid = this.GetSessionInfo( this._baseUri ).Sid;
            return sid;
        }
    }
#endregion
}
