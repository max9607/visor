using PLVISORTELERIK.DTOs;
using Microsoft.JSInterop;
using System.Text.Json;

namespace PLVISORTELERIK.Helpers
{
    public class DataTable : IDataTable
    {
        private readonly IJSRuntime js;

        public DataTable(IJSRuntime js)
        {
            this.js = js;
        }
     
        public async Task Init(string tableId, List<Columdef>? columnDefs = null, bool? responsive = true, bool? paging = true, bool? searching = true, bool? ordering = true, bool? info = true, bool? roworder = false)
        {

            await js.InvokeVoidAsync("ReadyDataTable", tableId, responsive, paging, searching, ordering, info, columnDefs,roworder);

        }
        public async Task Destroy(string tableId)
        {
            await js.InvokeVoidAsync("RemoveDataTable", tableId);
        }
        public async Task Refresh(string tableId, List<DimensionesPrimariaDTO>? list = null)
        {
            await js.InvokeVoidAsync("UpdateDataTables", tableId, "ds");
        }
    }
    public class Columdef
    {
        public int responsivePriority { get; set; }
        public int targets { get; set; }

        public bool orderable { get; set; } = false;
        public string className { get; set; }
    }
}
