using AlgoritmosPlanificacion.Models;

namespace AlgoritmosPlanificacion.Algoritmos;

public class RoundRobin
{
   public static List<Proceso> SimularRoundRobin(List<Proceso> procesos, int quantum)
    {
        var cola = new Queue<Proceso>(procesos.OrderBy(p => p.TiempoLlegada));
        var resultados = new List<Proceso>();
        int tiempoActual = 0;
        Queue<Proceso> colaReady = new Queue<Proceso>();

        while (cola.Count > 0 || colaReady.Count > 0)
        {
            // Agregar procesos que ya llegaron a la cola ready
            while (cola.Count > 0 && cola.Peek().TiempoLlegada <= tiempoActual)
                colaReady.Enqueue(cola.Dequeue());

            if (colaReady.Count == 0 && cola.Count > 0)
            {
                tiempoActual = cola.Peek().TiempoLlegada;
                continue;
            }

            var procesoActual = colaReady.Dequeue();
            if (procesoActual.TiempoInicio == -1)
                procesoActual.TiempoInicio = tiempoActual;

            int tiempoEjecutar = Math.Min(quantum, procesoActual.TiempoRestante);
            procesoActual.TiempoRestante -= tiempoEjecutar;
            tiempoActual += tiempoEjecutar;

            if (procesoActual.TiempoRestante == 0)
            {
                procesoActual.TiempoFinalizacion = tiempoActual;
                resultados.Add(procesoActual);
            }
            else
            {
                colaReady.Enqueue(procesoActual);
            }
        }

        return resultados;
    } 
    
}