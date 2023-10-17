﻿using PLVISORTELERIK.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PLVISORTELERIK.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        private JsonSerializerOptions OpcionesPorDefectoJSON =>
    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<X?> GetBody<X>()
        {
            try
            {
                string body = await HttpResponseMessage.Content.ReadAsStringAsync();
                var res = JsonSerializer.Deserialize<X>(body, OpcionesPorDefectoJSON);

                return res;
            }
            catch (Exception ex)
            {

                return default;
            }


        }

        public async Task<ResponseDTO<T>> getResponse()
        {
            if (!Error)
            {
                var response = new ResponseDTO<T>()
                {
                    StatusCode = (int)HttpResponseMessage.StatusCode,
                    value = Response,
                    Message = "OK"
                };

                return response;
            }
            else
            {
                var responseError = await GetBody<ResponseErrorDTO>();

                var response = new ResponseDTO<T>()
                {
                    StatusCode = responseError!.StatusCode,
                    value = default,
                    Message = responseError.Message
                };

                return response;
            }
        }

    }
}
