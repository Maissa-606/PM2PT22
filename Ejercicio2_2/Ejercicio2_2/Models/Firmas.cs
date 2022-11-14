using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_2.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String imageencripted { get; set; }
        [MaxLength(45)]
        public String nombre { get; set; }
        [MaxLength(100)]
        public String desc { get; set; }
        public byte[] img2
        {
            get { return Convert.FromBase64String(imageencripted); }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public string nombreToString { get { return $"Nombre: {nombre}"; } }
        public string DescripToString { get { return $"Descripcion: {desc}"; } }
    }
}
