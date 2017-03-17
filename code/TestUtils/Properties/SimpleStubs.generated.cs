using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using System.ComponentModel;

namespace XElement.RedYellowBlue.TestUtils
{
    [CompilerGenerated]
    public class StubIWebRequestCreate : IWebRequestCreate
    {
        private readonly StubContainer<StubIWebRequestCreate> _stubs = new StubContainer<StubIWebRequestCreate>();

        global::System.Net.WebRequest global::System.Net.IWebRequestCreate.Create(global::System.Uri uri)
        {
            return _stubs.GetMethodStub<Create_Uri_Delegate>("Create").Invoke(uri);
        }

        public delegate global::System.Net.WebRequest Create_Uri_Delegate(global::System.Uri uri);

        public StubIWebRequestCreate Create(Create_Uri_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace XElement.RedYellowBlue.UI.UWP.Model
{
    [CompilerGenerated]
    public class StubIConfig : IConfig
    {
        private readonly StubContainer<StubIConfig> _stubs = new StubContainer<StubIConfig>();

        global::System.Uri global::XElement.RedYellowBlue.UI.UWP.Model.IConfig.BoxUrl
        {
            get
            {
                return _stubs.GetMethodStub<BoxUrl_Get_Delegate>("get_BoxUrl").Invoke();
            }
        }

        string global::XElement.RedYellowBlue.UI.UWP.Model.IConfig.BoxUrlAsString
        {
            get
            {
                return _stubs.GetMethodStub<BoxUrlAsString_Get_Delegate>("get_BoxUrlAsString").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<BoxUrlAsString_Set_Delegate>("set_BoxUrlAsString").Invoke(value);
            }
        }

        string global::XElement.RedYellowBlue.UI.UWP.Model.IConfig.Password
        {
            get
            {
                return _stubs.GetMethodStub<Password_Get_Delegate>("get_Password").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Password_Set_Delegate>("set_Password").Invoke(value);
            }
        }

        string global::XElement.RedYellowBlue.UI.UWP.Model.IConfig.Username
        {
            get
            {
                return _stubs.GetMethodStub<Username_Get_Delegate>("get_Username").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Username_Set_Delegate>("set_Username").Invoke(value);
            }
        }

        public delegate global::System.Uri BoxUrl_Get_Delegate();

        public StubIConfig BoxUrl_Get(BoxUrl_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string BoxUrlAsString_Get_Delegate();

        public StubIConfig BoxUrlAsString_Get(BoxUrlAsString_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void BoxUrlAsString_Set_Delegate(string value);

        public StubIConfig BoxUrlAsString_Set(BoxUrlAsString_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Password_Get_Delegate();

        public StubIConfig Password_Get(Password_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Password_Set_Delegate(string value);

        public StubIConfig Password_Set(Password_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Username_Get_Delegate();

        public StubIConfig Username_Get(Username_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Username_Set_Delegate(string value);

        public StubIConfig Username_Set(Username_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void On_PropertyChanged(object sender)
        {
            global::System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(sender, null); }
        }

        public void PropertyChanged_Raise(object sender)
        {
            On_PropertyChanged(sender);
        }
    }
}