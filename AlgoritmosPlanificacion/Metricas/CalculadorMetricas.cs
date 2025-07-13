using AlgoritmosPlanificacion.Models;

namespace AlgoritmosPlanificacion.Metricas;

public class CalculadorMetricas
{
    public static void MostrarMetricas(List<Proceso> procesos)
    {
        double esperaProm = procesos.Average(p => p.TiempoEspera);
        double retornoProm = procesos.Average(p => p.TiempoRetorno);
        double respuestaProm = procesos.Average(p => p.TiempoRespuesta);
        int tiempoTotalCPU = procesos.Sum(p => p.TiempoRafaga);
        int tiempoSimulacion = procesos.Max(p => p.TiempoFinalizacion);
        double utilizacionCPU = (double)tiempoTotalCPU / tiempoSimulacion * 100;

        Console.WriteLine($"\nMétricas:");
        Console.WriteLine($"Tiempo de espera promedio: {esperaProm:F2}");
        Console.WriteLine($"Tiempo de retorno promedio: {retornoProm:F2}");
        Console.WriteLine($"Tiempo de respuesta promedio: {respuestaProm:F2}");
        Console.WriteLine($"Utilización de CPU: {utilizacionCPU:F2}%");
    }
}