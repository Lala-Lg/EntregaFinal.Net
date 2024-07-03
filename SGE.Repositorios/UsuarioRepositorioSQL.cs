namespace SGE.Repositorios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Enumerativos;
using System.Collections.ObjectModel;
public class UsuarioRepositorioSQL: IUsuarioRepositorio
{
    static UsuarioRepositorioSQL(){
        using(var context = new EntidadesContext()){
            context.Database.EnsureCreated();
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }

    public void AgregarUsuario(Usuario usuario){
        using(var db = new EntidadesContext()){
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
    }


    public void EliminarUsuario(Usuario usuario){
        using(var db = new EntidadesContext()){
            /*
            var usuario = _listaUsuarios.SingleOrDefault(u => u.Id == id);
            if (usuario!= null){
            _listaUsuarios.Remove(usuario);
            }
            */
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }
    }

    /*public Usuario? GetUsuario(int id){
    Usuario? u = _listaUsuarios.SingleOrDefault(u => u.Id == id);
    if (u != null){
        return Clonar(u);
    }
    return null;
    }*/

    public Usuario? GetUsuario(int id){
        Usuario? us = null;
        using(var db = new EntidadesContext()){
            //Según un ID que ingresa por parametro, busco entre todos los usuarios el primero que coincida con tal. Y lo retorna.
            us = db.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }
        return us;
    }

    /*public List<Usuario> GetUsuarios(){
    return _listaUsuarios.Select(u => Clonar(u)).ToList();
    }*/

    public List<Usuario> GetUsuarios(){
        using(var db = new EntidadesContext()){
            return db.Usuarios.ToList();
        }
    }

    public List<Permiso> GetPermisos(Usuario usuario){
        using (var db = new EntidadesContext())
    {
        // Recupera el usuario desde el contexto para asegurar que se obtienen los permisos desde la base de datos
       var usuarioDb = db.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
    

        // Si el usuario no se encuentra en la base de datos, devuelve una lista vacía
      
        if (usuarioDb == null)
        {
            return new List<Permiso>(); // Retorna una lista vacía si el usuario no existe
        }

        return usuarioDb.ListaPermisos; // Retorna la lista de permisos del usuario
    }
    }

    /*public void ModificarUsuario(Usuario usuario){
    var usu = _listaUsuarios.SingleOrDefault(u => u.Id == usuario.Id);
    if (usu != null){
        usu.Apellido = usuario.Apellido;
        usu.Nombre = usuario.Nombre;
    }
    }*/

    public void ModificarUsuario(Usuario usuario){
        using(var db = new EntidadesContext()){
            db.Usuarios.Update(usuario);
            db.SaveChanges();
        }
    }

    public void ModificarPermisos(int idUsuario, Permiso permisos){
        using (var db = new EntidadesContext())
    {
        // Cargar el usuario junto con sus permisos actuales
        var usuario = db.Usuarios
                        .Include(u => u.ListaPermisos)
                        .FirstOrDefault(us => us.Id == idUsuario);

        if (usuario != null)
        {
            // Eliminar los permisos actuales
            usuario.ListaPermisos.Clear();

            // Agregar los nuevos permisos
            foreach (var permiso in usuario.ListaPermisos)
            {
                usuario.ListaPermisos.Add(permiso);
            }

            // Guardar los cambios en la base de datos
            db.SaveChanges();
        }
        else
        {
            // Manejar el caso en que el usuario no se encuentra
            Console.WriteLine($"Usuario con ID {idUsuario} no encontrado.");
        }
    }
    }
    public void AgregarPermisoUsuario(int usuarioId, Permiso permiso)
    {
        using (var db = new EntidadesContext()){
        var usuario = db.Set<Usuario>().Find(usuarioId);
        if (usuario != null)
        {
            // Asignar el permiso al usuario
            usuario.ListaPermisos.Add(permiso);

            // Guardar los cambios en la base de datos
            db.SaveChanges();
        }
        }
    }
}
