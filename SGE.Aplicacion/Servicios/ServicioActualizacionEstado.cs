﻿
namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ServicioActualizacionEstado (IEspecificacionCambioEstado _especificacion, ITramiteRepositorio _tramiteRepositorio, IExpedienteRepositorio _expedienteRepositorio)
{
    public void ActualizarEstado(int id)
    {

        Expediente? expediente = _expedienteRepositorio.ObtenerPorId(id);
        if (expediente!=null){  
        expediente.Tramites = _tramiteRepositorio.ListarPorIdExpediente(id);
        Tramite ultimoTramite = expediente.Tramites[expediente.Tramites.Count - 1];
        expediente.Estado = _especificacion.ObtenerNuevoEstado(ultimoTramite.Etiqueta, expediente.Estado);
        _expedienteRepositorio.Modificar(expediente);
        }
    }

}
