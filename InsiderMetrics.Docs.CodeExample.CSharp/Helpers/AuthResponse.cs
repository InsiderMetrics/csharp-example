using InsiderMetrics.Docs.CodeExample.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InsiderMetrics.Docs.CodeExample.CSharp.Helpers
{
    public class AuthResponse<T> where T : IModel
    {
        public AuthResponse()
        {
        }

        public HttpStatusCode Status { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
