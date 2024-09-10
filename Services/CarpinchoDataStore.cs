using CarpinchoAPI.Models;

namespace CarpinchoAPI.Services;

public class CarpinchoDataStore
{
    public List<Carpincho> Carpinchos { get; set; }

    public static CarpinchoDataStore Current { get; } = new CarpinchoDataStore();

    public CarpinchoDataStore()
    {
        Carpinchos = new List<Carpincho>() {
            new Carpincho() {
                Id = 1,
                Nombre = "Minicarpincho",
                Apellido = "Rodriguez",
                Habilidades = new List<Habilidad>{
                    new Habilidad() {
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.EPotencia.Moderado
                    }
                }
            },
            new Carpincho() {
                Id = 2,
                Nombre = "Supercarpincho",
                Apellido = "Gomez",
                Habilidades = new List<Habilidad>{
                    new Habilidad() {
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.EPotencia.Moderado
                    },
                    new Habilidad() {
                        Id = 2,
                        Nombre = "Caminar",
                        Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad() {
                        Id = 3,
                        Nombre = "Gritar",
                        Potencia = Habilidad.EPotencia.Repotente
                    }
                }
            },
            new Carpincho() {
                Id = 3,
                Nombre = "Megacarpincho",
                Apellido = "Legrand",
                Habilidades = new List<Habilidad>{
                    new Habilidad() {
                        Id = 1,
                        Nombre = "Nadar",
                        Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad() {
                        Id = 2,
                        Nombre = "Correr",
                        Potencia = Habilidad.EPotencia.Extremo
                    },
                    new Habilidad() {
                        Id = 3,
                        Nombre = "Vomitar",
                        Potencia = Habilidad.EPotencia.Repotente
                    }
                }
            },
        };
    }
}