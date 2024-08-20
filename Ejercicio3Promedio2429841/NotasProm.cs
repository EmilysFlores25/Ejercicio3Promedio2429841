using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Ejercicio3Promedio2429841
{
    [SQLite.Table("promedio")]
    public  class NotasProm
    {
            [PrimaryKey]
            [AutoIncrement]
            [SQLite.Column("id")]
            public int Id { get; set; }
             [SQLite.Column("nombre")]
            public string? Nombre { get; set; }
        [SQLite.Column("nota1")]
            public string? nota1 { get; set; }
            [SQLite.Column("nota2")]
            public string? nota2 { get; set; }
            [SQLite.Column("nota3")]
            public string? nota3 { get; set; }
            [SQLite.Column("nota4")]
            public string? nota4 { get; set; }
            [SQLite.Column("nota5")]
            public string? nota5 { get; set; }
            [SQLite.Column("promedio")]
            public string? Promedio { get; set; }  
    }
}
