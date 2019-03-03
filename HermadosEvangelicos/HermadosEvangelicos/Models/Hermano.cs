using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermadosEvangelicos
{
    public class Hermano
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string IdSexo { set; get; }
        public DateTime Fecha_Nac { get; set; }
        public string IdProvincia { get; set; }
        public string IdCiudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono{ get; set; }
        public string IdEstadoCivil { get; set;}
        public string TipoSangre { get; set; }
        public bool Bautizo { get; set; }
        public DateTime Fecha_Bautizo { get; set; }
        public bool activo {get; set;}
    }
}
