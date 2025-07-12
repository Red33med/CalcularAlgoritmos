namespace AlgoritmosPlanificacion.Models;

public class Proceso
{
    public string Id { get; set; }
    public int TiempoLlegada { get; set; }
    public int TiempoRafaga { get; set; }
    public int Prioridad { get; set; } // Solo usado en Prioridad Preemptiva
    public int TiempoRestante { get; set; }
    
    public int TiempoInicio { get; set; } = -1;
    public int TiempoFinalizacion { get; set; }

    public double TiempoEspera => TiempoFinalizacion - TiempoLlegada - TiempoRafaga;
    public double TiempoRetorno => TiempoFinalizacion - TiempoLlegada;
    public double TiempoRespuesta => TiempoInicio == -1 ? 0 : TiempoInicio - TiempoLlegada; 
}