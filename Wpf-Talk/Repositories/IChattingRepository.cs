using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Talk.Models;

namespace Wpf_Talk.Repositories
{
    public interface IChattingRepository
    {
        ChattingListItem[] GetLastChattings(int myUid); // SELECT * FROM TABLE ORDER BY ID DESC LIMIT 1
        ChattingItem[] GetChattings(int myUid, int opUid);
    }
}
