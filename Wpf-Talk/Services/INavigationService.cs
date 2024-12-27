using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Talk.Services
{
    internal interface INavigationService
    {
        void Navigate(NavType navType);
    }
}
