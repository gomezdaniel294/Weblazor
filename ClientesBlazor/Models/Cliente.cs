using System.ComponentModel.DataAnnotations;

namespace ClientesBlazor.Models;

public class Cliente
{
    public int Id_cliente { get; set; }

    [Required(ErrorMessage = "El CUI es obligatorio.")]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "El CUI debe tener 13 dígitos.")]
    public string? CUI { get; set; }

    [Required(ErrorMessage = "El NIT es obligatorio.")]
    [StringLength(15, ErrorMessage = "El NIT no puede superar 15 caracteres.")]
    public string? nit { get; set; }

    [Required(ErrorMessage = "Los nombres son obligatorios.")]
    [StringLength(100)]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "Los apellidos son obligatorios.")]
    [StringLength(100)]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    [StringLength(200)]
    public string? direccion { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 dígitos.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    public DateTime? fecha_nacimiento { get; set; }
}
