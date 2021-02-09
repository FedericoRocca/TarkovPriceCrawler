using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovCrawler
{
    class preciosCrawler
    {
        private string Precio;
        private string Edition;

        public preciosCrawler() 
        {
            Precio = "";
            Edition = "";
        }

        public string getPrecio() { return Precio;  }
        public void setPrecio(string newPrecio) { Precio = newPrecio; }
        public string getEdition() { return Edition; }
        public void setEdition(string newEdition) { Edition = newEdition; }
    }
}
