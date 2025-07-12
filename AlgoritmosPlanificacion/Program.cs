using AlgoritmosPlanificacion.Models;
using static AlgoritmosPlanificacion.Algoritmos.RoundRobin;
using static AlgoritmosPlanificacion.Algoritmos.PrioridadPreemptiva;
using static AlgoritmosPlanificacion.Metricas.CalculadorMetricas;

namespace AlgoritmosPlanificacion;

class Program
{
    static void Main(string[] args)
    {
        var escenario = EscenarioA(); // Cambiar por EscenarioB o EscenarioC

        Console.WriteLine("Simulando Round Robin (Quantum = 2)");
        var copiaRR = CopiarProcesos(escenario);
        var resultadoRR = SimularRoundRobin(copiaRR, 2);
        MostrarMetricas(resultadoRR);

        Console.WriteLine("\nSimulando Prioridad Preemptiva");
        var copiaPP = CopiarProcesos(escenario);
        var resultadoPP = SimularPrioridadPreemptiva(copiaPP);
        MostrarMetricas(resultadoPP); 
        
    }
    
    static List<Proceso> CopiarProcesos(List<Proceso> procesos)
    {
        return procesos.Select(p => new Proceso
        {
            Id = p.Id,
            TiempoLlegada = p.TiempoLlegada,
            TiempoRafaga = p.TiempoRafaga,
            Prioridad = p.Prioridad,
            TiempoRestante = p.TiempoRafaga
        }).ToList();
    }

    static List<Proceso> EscenarioA() => new List<Proceso>
    {
        new Proceso { Id = "P1", TiempoLlegada = 0, TiempoRafaga = 8, Prioridad = 2 },
        new Proceso { Id = "P2", TiempoLlegada = 0, TiempoRafaga = 4, Prioridad = 1 },
        new Proceso { Id = "P3", TiempoLlegada = 0, TiempoRafaga = 9, Prioridad = 3 }
    }; 
    
}
