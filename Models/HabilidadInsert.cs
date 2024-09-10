using static CarpinchoAPI.Models.Habilidad;

namespace CarpinchoAPI.Models;

public class HabilidadInsert
{
    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }
}