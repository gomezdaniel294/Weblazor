namespace TodoApi.Models;
using System.ComponentModel.DataAnnotations;

public class Clientes
{
    [Key]
    public Int32 Id_cliente { get; set; }
    public string? CUI { get; set; }

    public string? nit { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? direccion { get; set; }
    public string? Telefono { get; set; }
    public DateTime? fecha_nacimiento { get; set; }
}
