using PLVISORTELERIK.DTOs;

namespace PLVISORTELERIK.Helpers
{
    public interface IDataTable
    {
        Task Init(string tableId, List<Columdef>? columnDefs = null, bool? responsive = true, bool? paging = true, bool? searching = true, bool? ordering = true, bool? info = true,bool? roworder= false);
        Task Destroy(string tableId);
        Task Refresh(string tableId, List<DimensionesPrimariaDTO> list);
    }
}
