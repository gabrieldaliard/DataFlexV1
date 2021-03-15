using DataFlex.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFlex.Api.Models
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _appDbContext;

        public Table AddTable(Table table)
        {
            throw new NotImplementedException();
        }

        public void DeleteTableById(int tableId)
        {
            var foundTable = _appDbContext.Tables.FirstOrDefault(c => c.id == tableId);
            if (foundTable == null) return;

            _appDbContext.Tables.Remove(foundTable);
            _appDbContext.SaveChanges();
        }



        public Table GetTableById(int tableId)
        {
            throw new NotImplementedException();
        }

        public Table GetTableByName(string tableName)
        {
            throw new NotImplementedException();
        }

        public Table UpdateTable(Table table)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> GetAllTables()
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            
            try
            {
                conn = new SqlConnection("Data Source=LAPTOP-4ERJ3BTU\\SQLEXPRESS; Initial Catalog = BikeStore; Integrated Security = True");

                conn.Open();

                SqlCommand Command = new SqlCommand("SELECT name, object_id from sys.tables", conn);

                reader = Command.ExecuteReader();

                List<Table> listaTabla = new List<Table>();

                while (reader.Read())
                {
                    Table tab = new Table();
                    tab.Name = reader[0].ToString();
                    tab.id = (int)reader[1];
                    listaTabla.Add(tab);
                }


                //return new
                //{
                //    current = 1,//current,
                //    rowCount = 1,//rowCount,
                //    rows = listaTabla,
                //    total = listaTabla.Count
                //}

                return listaTabla;

                //jsonData = JsonConvert.SerializeObject(rsp);
                //return rsp;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            
        }

            [HttpGet]
            public List<Table> Get()
            {
                List<Table> empList =
                new List<Table>();
                empList.Add(new Table()
                {
                    id = 1,
                    Name = "Nancy",
                    Description = "Davolio"
                });
                empList.Add(new Table()
                {
                    id = 2,
                    Name = "Nancy",
                    Description = "Davolio"
                });
                return empList;

        }

    }
}
