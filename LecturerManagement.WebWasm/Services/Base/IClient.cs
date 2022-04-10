using System.Net.Http;

namespace LecturerManagement.Server.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}