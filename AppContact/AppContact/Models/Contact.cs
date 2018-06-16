using System;
using System.Collections.Generic;
using System.Text;

namespace AppContact.Models
{
    using SQLite;

    public class Contact
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Notas { get; set; }

    }
}
