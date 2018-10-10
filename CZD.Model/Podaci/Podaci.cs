using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Model.Podaci
{
    public class Podaci
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int PostanskiBroj { get; set; }
        public string Grad { get; set; }
    }
}
