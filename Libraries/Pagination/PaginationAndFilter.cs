using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApi.Libraries.Pagination
{
    public class PaginationAndFilter
    {
        private readonly Context db = new Context();
        private readonly HttpContext _Context;
        public PaginationAndFilter(HttpContext Context)
        {
            _Context = Context;
        }
        //json pagination
        public PaginationJSON queryPaginationJSON(string tableORview_name)
        {
            var request = GetParamsRequest();
            return queryPaginationAndFilterYourWhereJSON(new Parame
            {
                table_name = tableORview_name,
                search_text = request.filter,
                page = request.startRow,
                limit_page = request.limitRow,
            });
        }
        public PaginationJSON queryPaginationJSON(string tableORview_name, ConditionString where)
        {
            var request = GetParamsRequest();
            return queryPaginationAndFilterYourWhereJSON(new Parame
            {
                table_name = tableORview_name,
                yourwhere = where.EXEC,
                key_where = where.EXEC_KEY,
                search_text = request.filter,
                page = request.startRow,
                limit_page = request.limitRow
            });
        }
        public PaginationJSON queryPaginationJSON(string tableORview_name, string sortByColumn, string sort_type)
        {
            checkSort_type(sort_type);
            var request = GetParamsRequest();
            return queryPaginationAndFilterYourWhereJSON(new Parame
            {
                table_name = tableORview_name,
                search_text = request.filter,
                page = request.startRow,
                limit_page = request.limitRow,
                sortby = sortByColumn,
                sort_type = sort_type
            });
        }
        public PaginationJSON queryPaginationJSON(string tableORview_name, ConditionString where, string sortByColumn, string sort_type)
        {
            checkSort_type(sort_type);
            var request = GetParamsRequest();
            return queryPaginationAndFilterYourWhereJSON(new Parame
            {
                table_name = tableORview_name,
                yourwhere = where.EXEC,
                key_where = where.EXEC_KEY,
                search_text = request.filter,
                page = request.startRow,
                limit_page = request.limitRow,
                sortby = sortByColumn,
                sort_type = sort_type
            });
        }
        public PaginationJSON queryPaginationJSON(string tableORview_name, ConditionString[] where)
        {
            var request = GetParamsRequest();
            string EXEC = "";
            string EXEC_KEY = "";
            foreach (var wheres in where)
            {
                EXEC = EXEC + (EXEC != "" ? " AND " : "") + ("(" + wheres.EXEC + ")");
                EXEC_KEY = EXEC_KEY + (EXEC_KEY != "" ? "," : "") + wheres.EXEC_KEY;
            }
            return queryPaginationAndFilterYourWhereJSON(new Parame
            {
                table_name = tableORview_name,
                yourwhere = EXEC,
                key_where = EXEC_KEY,
                search_text = request.filter,
                page = request.startRow,
                limit_page = request.limitRow
            });
        }
        public PaginationJSON queryPaginationJSON(string tableORview_name, ConditionString[] where, string sortByColumn, string sort_type)
        {
            var request = GetParamsRequest();
            checkSort_type(sort_type);
            string EXEC = "";
            string EXEC_KEY = "";
            foreach (var wheres in where)
            {
                EXEC = EXEC + (EXEC != "" ? " AND " : "") + ("(" + wheres.EXEC + ")");
                EXEC_KEY = EXEC_KEY + (EXEC_KEY != "" ? "," : "") + wheres.EXEC_KEY;
            }
            return queryPaginationAndFilterYourWhereJSON(new Parame
            {
                table_name = tableORview_name,
                yourwhere = EXEC,
                key_where = EXEC_KEY,
                search_text = request.filter,
                page = request.startRow,
                limit_page = request.limitRow,
                sortby = sortByColumn,
                sort_type = sort_type
            });
        }
        //json non pagination
        public object queryNonPaginationJSON(string tableORview_name)
        {
            var request = GetParamsRequest();
            return JsonConvert.DeserializeObject(
                queryPaginationYourWereJSON(new Parame
                {
                    table_name = tableORview_name,
                    search_text = request.filter,
                    page = 0,
                    limit_page = 0,
                }).Item
            );
        }
        public object queryNonPaginationJSON(string tableORview_name, ConditionString where)
        {
            var request = GetParamsRequest();
            return JsonConvert.DeserializeObject(
               queryPaginationYourWereJSON(new Parame
               {
                   table_name = tableORview_name,
                   yourwhere = where.EXEC,
                   key_where = where.EXEC_KEY,
                   search_text = request.filter,
                   page = 0,
                   limit_page = 0
               }).Item
           );
        }
        public object queryNonPaginationJSON(string tableORview_name, string sortByColumn, string sort_type)
        {
            var request = GetParamsRequest();
            return JsonConvert.DeserializeObject(
                queryPaginationYourWereJSON(new Parame
                {
                    table_name = tableORview_name,
                    search_text = request.filter,
                    page = 0,
                    limit_page = 0,
                    sortby = sortByColumn,
                    sort_type = sort_type
                }).Item
            );
        }
        public object queryNonPaginationJSON(string tableORview_name, ConditionString where, string sortByColumn, string sort_type)
        {
            var request = GetParamsRequest();
            return JsonConvert.DeserializeObject(
                queryPaginationYourWereJSON(new Parame
                {
                    table_name = tableORview_name,
                    yourwhere = where.EXEC,
                    key_where = where.EXEC_KEY,
                    search_text = request.filter,
                    page = 0,
                    limit_page = 0,
                    sortby = sortByColumn,
                    sort_type = sort_type
                }).Item
            );
        }

        //json
        private PaginationJSON queryPaginationAndFilterYourWhereJSON(Parame input)
        {
            try
            {
                var query = queryPaginationYourWereJSON(input);
                PaginationJSON pagination = new PaginationJSON();
                if (query.Item != null)
                {
                    pagination.items = JsonConvert.DeserializeObject(query.Item);
                }
                else
                {
                    pagination.items = new object[] { };
                }
                pagination.startRow = input.page;
                pagination.limitRow = input.limit_page;
                pagination.resultRow = query.Count_row;
                return pagination;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Query
        private pagination_json queryPaginationYourWereJSON(Parame input)
        {
            var items = db.ReponseJson.FromSql("EXEC [dbo].[s_Pagination] @table_name,@search_text,@yourwhere,@key_where,@page,@limit_page,@sortby,@sort_type",
                new SqlParameter("@table_name", input.table_name),
                new SqlParameter("@search_text", input.search_text),
                new SqlParameter("@yourwhere", input.yourwhere),
                new SqlParameter("@key_where", input.key_where),
                new SqlParameter("@page", input.page),
                new SqlParameter("@limit_page", input.limit_page),
                new SqlParameter("@sortby", input.sortby),
                new SqlParameter("@sort_type", input.sort_type)
                ).FirstOrDefault();
            return items;
        }
        private void checkSort_type(string sort_type)
        {
            if (sort_type.ToUpper().Equals("ASC") || sort_type.ToUpper().Equals("DESC"))
            {
                return;
            }
            throw new Exception("type sort is incorrent");
        }
        private PaginationParamsRequest GetParamsRequest()
        {
            string page = _Context.Request.Query["page"];
            string limitpage = _Context.Request.Query["limitpage"];
            string filter = _Context.Request.Query["filter"];
            return new PaginationParamsRequest
            {
                startRow = Int32.Parse(page==null?"1":page),
                limitRow = Int32.Parse(limitpage==null?"15":limitpage),
                filter = filter==null?"":filter
            };
        }
    }
    public class PaginationParamsRequest
    {
        public int startRow { get; set; }
        public int limitRow { get; set; }
        public string filter { get; set; }
    }
    public class PaginationJSON
    {
        public object items { get; set; }
        public int startRow { get; set; }
        public int limitRow { get; set; }
        public int resultRow { get; set; }
    }
    public class Parame
    {
        public string table_name { get; set; } = "";
        public string search_text { get; set; } = "";
        public string yourwhere { get; set; } = "";
        public string key_where { get; set; } = "";
        public int page { get; set; } = 1;
        public int limit_page { get; set; } = 15;
        public string sortby { get; set; } = "";
        public string sort_type { get; set; } = "";
    }
}
