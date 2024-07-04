namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Excepciones;

public class CasosDeUsoModificarPermisos(IServicioAutorizacion servicioAutorizacion, IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(int idUsuario, List<Permiso> permisos, int usuarioModificador)
    {
        if(servicioAutorizacion.PoseeElPermiso(usuarioModificador,Permiso.ModificarPermisos))
        {
            Repositorio.ModificarPermisos(idUsuario, permisos); 
        }
        else
        {
            throw new AutorizacionException();
        } 
    }
}