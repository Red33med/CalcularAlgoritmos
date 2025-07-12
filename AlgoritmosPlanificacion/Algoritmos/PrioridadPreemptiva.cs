using AlgoritmosPlanificacion.Models;

namespace AlgoritmosPlanificacion.Algoritmos;

public class PrioridadPreemptiva
{
    public static List<Proceso> SimularPrioridadPreemptiva(List<Proceso> procesos)
    {
        var eventos = new List<(int tiempo, Proceso proceso)>();
        var procesosActivos = new List<Proceso>(procesos);
        int tiempoActual = 0;
        Proceso ejecutando = null;

        while (procesosActivos.Count > 0 || ejecutando != null)
        {
            // Añadir procesos que ya llegaron
            var nuevos = procesosActivos.Where(p => p.TiempoLlegada == tiempoActual).ToList();
            foreach (var p in nuevos)
            {
                if (ejecutando == null || p.Prioridad < ejecutando.Prioridad) // Menor número = mayor prioridad
                {
                    if (ejecutando != null)
                        procesosActivos.Add(ejecutando);
                    ejecutando = p;
                }
                else
                {
                    procesosActivos.Add(p);
                }
            }
            procesosActivos.RemoveAll(p => p.TiempoLlegada == tiempoActual);

            if (ejecutando != null)
            {
                if (ejecutando.TiempoInicio == -1)
                    ejecutando.TiempoInicio = tiempoActual;

                ejecutando.TiempoRestante--;
                tiempoActual++;

                if (ejecutando.TiempoRestante == 0)
                {
                    ejecutando.TiempoFinalizacion = tiempoActual;
                    eventos.Add((tiempoActual, ejecutando));
                    ejecutando = null;
                }
            }
            else
            {
                tiempoActual++;
            }
        }

        return procesos;
    } 
}