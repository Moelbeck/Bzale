using System;
using System.Threading;
using System.Web;

namespace App.Web
{
    public static class AppHttpContext
    {

        [ThreadStatic]
        static HttpContextHolder contextHolder;

        public static HttpContext Current
        {
            get { return contextHolder?.HttpContext; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Null value not allowed.  Call Clear method instead.");
                }

                contextHolder = new HttpContextHolder
                {
                    HttpContext = value,
                    ManagedThreadId = Thread.CurrentThread.ManagedThreadId
                };

                //Place the context holder in the httpContext's items dictionary where
                //we can get to it later when we need to clear it
                value.Items["HttpContextHolder"] = contextHolder;
            }
        }


        /// <summary>
        /// Clears the Internal HttpContext
        /// </summary>
        /// <param name="httpContext"></param>
        public static void Clear(HttpContext httpContext)
        {
            HttpContextHolder holder = (HttpContextHolder)httpContext.Items["HttpContextHolder"];
            httpContext.Items.Remove("HttpContextHolder");

            holder.HttpContext = null;
            holder.ManagedThreadId = null;
        }


        private class HttpContextHolder
        {
            public HttpContext HttpContext { get; set; }
            public int? ManagedThreadId { get; set; }
        }
    }
}
