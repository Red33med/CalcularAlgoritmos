using AlgoritmosPlanificacion.Models;

namespace AlgoritmosPlanificacion.Escenarios;

public static class GeneradorEscenarios
{
    public static List<Proceso> Escenario1()
    {
        return new List<Proceso>
        {
            new Proceso { Id = "P1", TiempoLlegada = 0, TiempoRafaga = 2, Prioridad = 2 },
            new Proceso { Id = "P2", TiempoLlegada = 0, TiempoRafaga = 3, Prioridad = 1 },
            new Proceso { Id = "P3", TiempoLlegada = 1, TiempoRafaga = 2, Prioridad = 3 },
            new Proceso { Id = "P4", TiempoLlegada = 1, TiempoRafaga = 1, Prioridad = 2 }
        };
    }

    public static List<Proceso> Escenario2()
    {
        return new List<Proceso>
        {
            new Proceso { Id = "P1", TiempoLlegada = 0, TiempoRafaga = 15, Prioridad = 2 },
            new Proceso { Id = "P2", TiempoLlegada = 5, TiempoRafaga = 10, Prioridad = 1 },
            new Proceso { Id = "P3", TiempoLlegada = 10, TiempoRafaga = 20, Prioridad = 3 },
            new Proceso { Id = "P4", TiempoLlegada = 15, TiempoRafaga = 8, Prioridad = 2 }
        };
    }

    public static List<Proceso> Escenario3()
    {
        return new List<Proceso>
        {
            new Proceso { Id = "P1", TiempoLlegada = 0, TiempoRafaga = 6, Prioridad = 2 },
            new Proceso { Id = "P2", TiempoLlegada = 2, TiempoRafaga = 4, Prioridad = 1 },
            new Proceso { Id = "P3", TiempoLlegada = 3, TiempoRafaga = 5, Prioridad = 3 },
            new Proceso { Id = "P4", TiempoLlegada = 7, TiempoRafaga = 2, Prioridad = 1 },
            new Proceso { Id = "P5", TiempoLlegada = 9, TiempoRafaga = 3, Prioridad = 2 }
        };
    }
}