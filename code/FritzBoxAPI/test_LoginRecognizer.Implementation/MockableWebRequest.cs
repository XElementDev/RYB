using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    internal class MockableWebRequest : WebRequest
    {
        public MockableWebRequest()
        {
            this.GetResponseAsyncInt = () => base.GetResponseAsync();
        }


        public override void Abort()
        {
            throw new NotImplementedException();
        }


        public override string ContentType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public override IAsyncResult BeginGetRequestStream( AsyncCallback callback, object state )
        {
            throw new NotImplementedException();
        }

        public override Stream EndGetRequestStream( IAsyncResult asyncResult )
        {
            throw new NotImplementedException();
        }


        public override IAsyncResult BeginGetResponse( AsyncCallback callback, object state )
        {
            throw new NotImplementedException();
        }

        public override WebResponse EndGetResponse( IAsyncResult asyncResult )
        {
            throw new NotImplementedException();
        }

        public override Task<WebResponse> GetResponseAsync()
        {
            return this.GetResponseAsyncInt();
        }

        internal Func<Task<WebResponse>> GetResponseAsyncInt;


        public override WebHeaderCollection Headers
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public override string Method
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public override Uri RequestUri
        {
            get { throw new NotImplementedException(); }
        }
    }
}
