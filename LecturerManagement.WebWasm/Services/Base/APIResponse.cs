﻿namespace LecturerManagement.Server.Services.Base
{
    public class APIResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
    }
}