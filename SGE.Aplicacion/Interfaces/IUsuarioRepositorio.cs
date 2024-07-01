
namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public interface IUsuarioRepositorio
{
    List<Usuario> GetUsuarios();
    Usuario? GetUsuario(int id);
    List<Permiso> GetPermisos(Usuario usuario);
    void ModificarUsuario(Usuario usuario);
    void EliminarUsuario(Usuario usuario);
    void AgregarUsuario(Usuario usuario);
    void AgregarPermisoUsuario(int usuarioId, Permiso permiso); //se tiene que implementar asi xq Modificar permisos lo hicimos para q borre todos los permisos que se tiene y de ahi agregar
    void ModificarPermisos(int idUsuario, Permiso permisos);
}
