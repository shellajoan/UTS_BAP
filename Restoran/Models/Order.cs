using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Models
{
    public class Order
    {
        public string no_meja { get; set; }
        public int id_order { get; set; }
        public int id_menu { get; set; }
        public string nama_menu { get; set; }
        public int qty { get; set; }
        public decimal harga_satuan { get; set; }
        public decimal harga_total { get; set; }
    }
}
