using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFlexSite.Services;
using Microsoft.AspNetCore.Components;
using DataFlex.Shared;
using Radzen;

namespace DataFlexSite.Pages
{
    public partial class GrillaTablas
    {


        [Inject]
        public iTableDataService TableDataServicex { get; set; }

        IEnumerable<Table> xTable;


        protected override async Task OnInitializedAsync()
        {
            
            //xTable = await(TableDataServicex.GetAllTables());

        }
        //return base.OnInitializedAsync();

        int count;

        async Task LoadData(LoadDataArgs args)
        {
            xTable = await (TableDataServicex.GetAllTables());

            count = xTable.Count();

            await InvokeAsync(StateHasChanged);
        }
    }
}
