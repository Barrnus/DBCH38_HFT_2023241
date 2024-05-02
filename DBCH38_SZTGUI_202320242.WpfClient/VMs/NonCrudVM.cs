using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_SZTGUI_202320242.WpfClient.VMs
{
    public class NonCrudVM<T>
    {
        public string Message { get; set; }
        public List<T> Values { get; set; }
    }
}
