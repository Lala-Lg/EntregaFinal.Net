namespace SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;
public static class UsuarioValidador
{
    public static bool Validar(Usuario u, out string mensajeError){
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(u.Nombre)){
            mensajeError = "El contenido no puede estar vacío.";
        }
        if (string.IsNullOrWhiteSpace(u.Apellido)){
            mensajeError += "El contenido no puede estar vacío.";
        }
        if (string.IsNullOrWhiteSpace(u.CorreoElectronico)){
            mensajeError += "El contenido no puede estar vacío.";
        }
        if(!u.CorreoElectronico.Contains("@"))
        {
            mensajeError += "El correo electrónico debe contener un '@'.";

        }
        if (string.IsNullOrWhiteSpace(u.Apellido)){
            mensajeError +="El contenido no puede estar vacío.";
        }
        return (mensajeError == "");
    }

}