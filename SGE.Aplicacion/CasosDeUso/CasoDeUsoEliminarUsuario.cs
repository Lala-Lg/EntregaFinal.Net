namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
public class CasoDeUsoEliminarUsuario(IServicioAutorizacion servicioAutorizacion, IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(Usuario usuario,int IdUsuario)
    {
        if(servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.EliminarUsuario))
        {
            Repositorio.EliminarUsuario(usuario);
        }
        else 
        {
            throw new AutorizacionException();
        }

    }
}
