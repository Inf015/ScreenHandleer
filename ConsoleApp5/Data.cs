using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Data
    {
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

        public Data()
        {
        }

        public Data(string pregunta, string respuesta)
        {
            Pregunta = pregunta;
            Respuesta = respuesta;
        }
    }
}
