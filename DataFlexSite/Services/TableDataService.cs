using DataFlex.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataFlexSite.Services
{
    public class TableDataService : iTableDataService
    {

        private readonly HttpClient _httpClient;

        public TableDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Table iTableDataService.AddTable(Table table)
        {
            throw new NotImplementedException();
        }

        void iTableDataService.DeleteTableById(int tableId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Table>> iTableDataService.GetAllTables()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Table>>
            (await _httpClient.GetStreamAsync($"Api/GetAllTables"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        Table iTableDataService.GetTableById(int tableId)
        {
            throw new NotImplementedException();
        }

        Table iTableDataService.GetTableByName(string tableName)
        {
            throw new NotImplementedException();
        }

        Table iTableDataService.UpdateTable(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
