﻿namespace ECommerceProjectWithWebAPI.Core.Utilities.Responses
{
    public class ApiDataResponse<T>:ApiResponse
    {
        public ApiDataResponse()
        {

        }
        public ApiDataResponse(bool success):base(success)
        {

        }

        public ApiDataResponse(bool success,string message) : base(success,message)
        {

        }

        public T Data { get; set; }
    }
}
