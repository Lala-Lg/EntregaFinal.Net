
namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;
public class ServicioActualizacionEstado (IEspecificacionCambioEstado _especificacion, ITramiteRepositorio _tramiteRepositorio, IExpedienteRepositorio _expedienteRepositorio)
{
    public void ActualizarEstado(int id)
    {
        Expediente? expediente = _expedienteRepositorio.ObtenerPorId(id);
        if (expediente != null)
        {
            expediente.Tramites = _tramiteRepositorio.ListarPorIdExpediente(id);

            if (expediente.Tramites.Count > 0)
            {
                Tramite ultimoTramite = expediente.Tramites[expediente.Tramites.Count - 1];
                expediente.Estado = _especificacion.ObtenerNuevoEstado(ultimoTramite.Etiqueta, expediente.Estado);
                Console.WriteLine("tramite a eliminar etiqueta:" + ultimoTramite.Etiqueta);
                Console.WriteLine("nuevo estado del expediente :" + expediente.Estado);
                _expedienteRepositorio.Modificar(expediente);
            }
            else
                // Manejar el caso cuando el expediente no se encuentra
            Console.WriteLine("tramites son = o menor a 0 " + id);
        }
        else
        {
            // Manejar el caso cuando el expediente no se encuentra
            Console.WriteLine("Expediente no encontrado para el ID: " + id);
        }
    }

}
