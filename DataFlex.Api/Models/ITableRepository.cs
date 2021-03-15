using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFlex.Shared;

namespace DataFlex.Api.Models
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetAllTables();
        Table GetTableById(int tableId);
        Table GetTableByName(string tableName);
        Table AddTable(Table table);
        Table UpdateTable(Table table);
        void DeleteTableById(int tableId);
    }
}
