﻿using System.Net.Http;

namespace LecturerManagement.Server.UI.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}