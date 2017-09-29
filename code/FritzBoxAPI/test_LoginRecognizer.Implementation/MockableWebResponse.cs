using System;
using System.IO;
using System.Net;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    internal class MockableWebResponse : WebResponse
    {
        public MockableWebResponse()
        {
            this.GetResponseStreamInt = () => { throw new NotImplementedException(); };
        }


        public override long ContentLength
        {
            get { throw new NotImplementedException(); }
        }


        public override string ContentType
        {
            get { throw new NotImplementedException(); }
        }


        public override Stream GetResponseStream()
        {
            return this.GetResponseStreamInt();
        }

        internal Func<Stream> GetResponseStreamInt;


        public override Uri ResponseUri
        {
            get { throw new NotImplementedException(); }
        }
    }
}
