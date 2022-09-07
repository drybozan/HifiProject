using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiFi.Api.paged
{
    public class UriService 
    {
        private readonly string _baseUri = "http://localhost:51075/api/LogApi/get/";


        public Uri GetPageUri(int pageNumber,int pageSize)
        {
            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}