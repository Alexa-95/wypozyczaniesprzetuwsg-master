using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczanieSprzetuWSG
{
    class JDevice
    {
        public int device_id { get; set; }
        public String device_name { get; set; }
        public String device_type { get; set; }
        public int device_istaken { get; set; }
    }
}
