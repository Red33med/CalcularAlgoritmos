using AlgoritmosPlanificacion.Models;

namespace AlgoritmosPlanificacion.Algoritmos;

public class PrioridadPreemptiva
{
    public static List<Proceso> SimularPrioridadPreemptiva(List<Proceso> procesos)
    {
        // Inicializamos correctamente TiempoRestante si no se ha hecho antes
        foreach (var p in procesos)
        {
            p.TiempoRestante = p.TiempoRafaga;
            p.TiempoInicio = -1;
        }

        var procesosPendientes = new List<Proceso>(procesos);
        var resultados = new List<Proceso>();
        Proceso ejecutando = null;
        int tiempoActual = 0;

        while (procesosPendientes.Count > 0 || ejecutando != null)
        {
            // Filtramos los procesos que ya llegaron
            var disponibles = procesosPendientes
                .Where(p => p.TiempoLlegada <= tiempoActual)
                .OrderBy(p => p.Prioridad)
                .ThenBy(p => p.TiempoLlegada)
                .ToList();

            if (disponibles.Count > 0)
            {
                var mejor = disponibles.First();

                if (ejecutando == null || mejor.Prioridad < ejecutando.Prioridad)
                {
                    if (ejecutando != null && ejecutando.TiempoRestante > 0)
                        procesosPendientes.Add(ejecutando); // Reencolar el anterior

                    ejecutando = mejor;
                    procesosPendientes.Remove(mejor);

                    if (ejecutando.TiempoInicio == -1)
                        ejecutando.TiempoInicio = tiempoActual;
                }
            }

            if (ejecutando != null)
            {
                ejecutando.TiempoRestante--;
                tiempoActual++;

                if (ejecutando.TiempoRestante == 0)
                {
                    ejecutando.TiempoFinalizacion = tiempoActual;
                    resultados.Add(ejecutando);
                    ejecutando = null;
                }
            }
            else
            {
                tiempoActual++; // Avanza el tiempo aunque no haya proceso ejecutando
            }
        }

        return resultados;
    }
}