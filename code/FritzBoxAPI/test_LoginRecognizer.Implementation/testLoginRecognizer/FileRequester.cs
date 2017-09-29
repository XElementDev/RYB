using AngleSharp.Network;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    internal class FileRequester : IRequester
    {
        public FileRequester() { }


        private string GetFileContent( Uri uri )
        {
            string fileContent = null;

            string filePath = uri.LocalPath;
            fileContent = File.ReadAllText( filePath );

            return fileContent;
        }


        public Task<IResponse> /*IRequester.*/RequestAsync( IRequest angleSharpRequest, 
                                                            CancellationToken cancel )
        {
            var task = Task.Run( () => this.Request( angleSharpRequest, cancel ) );
            return task;
        }

        private IResponse Request( IRequest angleSharpRequest, CancellationToken cancel )
        {
            IResponse angleSharpResponse = null;

            string content = this.GetFileContent( angleSharpRequest.Address );
            angleSharpResponse = VirtualResponse.Create( r => r 
                .Address( angleSharpRequest.Address ) 
                .Content( content )
            );

            return angleSharpResponse;
        }


        public bool /*IRequester.*/SupportsProtocol( string protocol )
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            bool isSupported = SUPPORTED_PROTOCOLS.ToList().Contains( protocol, comparer );
            return isSupported;
        }


        private static string[] SUPPORTED_PROTOCOLS = { ProtocolNames.File };
    }
}
