using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiFi.Api.paged
{
    public class PaginationHelper
    {
       
        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, int pageNumber,int pageSize, int totalRecords)
        {
            UriService uriService = new UriService();
            var respose = new PagedResponse<List<T>>(pagedData, pageNumber, pageSize);
            var totalPages = ((double)totalRecords / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                pageNumber >= 1 && pageNumber < roundedTotalPages
                ? uriService.GetPageUri(pageNumber + 1, pageSize)
                : null;
            respose.PreviousPage =
                pageNumber - 1 >= 1 && pageNumber <= roundedTotalPages
                ? uriService.GetPageUri(pageNumber - 1, pageSize)
                : null;
            respose.FirstPage = uriService.GetPageUri(1, pageSize);
            respose.LastPage = uriService.GetPageUri(roundedTotalPages, pageSize);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}