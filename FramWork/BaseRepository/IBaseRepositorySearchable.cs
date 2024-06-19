using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramWork.BaseRepository
{
    public interface IBaseRepositorySearchable<TModel , TKey , TSearchModel , TSearchResult> : IBaseRepository<TModel , TKey>//IBaseRepository<TModel , TKey> in ja model va key ro moshakhas mishe va be class father ham enteghal mideh
    {
        List<TSearchResult> Search(TSearchModel sm, out int RecordCount);//SearchResult = masalan chizi ke mikhahi dar datagrid namaiesh bedi
    }
}
