using AlgoritmosPlanificacion.Escenarios;
using AlgoritmosPlanificacion.Metricas;
using AlgoritmosPlanificacion.Models;


namespace AlgoritmosPlanificacion;

class Program
{
    static void Main(string[] args)
    {
        // Seleccionar el escenario a simular
        Console.WriteLine("ESCENARIO 3");
        var procesos = GeneradorEscenarios.Escenario3(); // Aquí se cambia por Escenario 1 - 2 - 3

        Console.WriteLine("\n--- PROCESOS INICIALES ---");
        foreach (var p in procesos)
            Console.WriteLine($"{p.Id} | Llegada: {p.TiempoLlegada} | Rafaga: {p.TiempoRafaga} | Prioridad: {p.Prioridad}");

        // Simulación de Round Robin (Quantum = 2)
        Console.WriteLine("\nSIMULANDO ROUND ROBIN (Quantum = 2)");
        var copiaRR = CopiarProcesos(procesos);
        var resultadosRR = Algoritmos.RoundRobin.SimularRoundRobin(copiaRR, 2);
        CalculadorMetricas.MostrarMetricas(resultadosRR);

        // Simulación de Prioridad Preemptiva
        Console.WriteLine("\nSIMULANDO PRIORIDAD PREEMPTIVA");
        var copiaPP = CopiarProcesos(procesos);
        var resultadosPP = Algoritmos.PrioridadPreemptiva.SimularPrioridadPreemptiva(copiaPP);
        CalculadorMetricas.MostrarMetricas(resultadosPP);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Método para clonar la lista de procesos
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
}
