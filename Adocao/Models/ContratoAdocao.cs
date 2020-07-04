using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adocao.Models
{
    public class ContratoAdocao
    {
        public int ID { get; set; }
        public string NomePet { get; set; }
        public string NomeAdotante { get; set; }
        public int ONGID { get; set; }
        public virtual ONG ONG { get; set; }

    }
}