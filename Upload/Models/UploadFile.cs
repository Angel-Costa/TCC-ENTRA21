using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upload.Models
{
    public class UploadFile
    {
        public int IDArquivo { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
    }

}
