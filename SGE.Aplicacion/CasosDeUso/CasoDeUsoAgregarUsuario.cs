namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Excepciones;

public class CasoDeUsoAgregarUsuario : CasoDeUsoUsuario
{
    private readonly IUsuarioRepositorio _repositorio;

    public CasoDeUsoAgregarUsuario(IUsuarioRepositorio repositorio) : base(repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario)
    {
        string mensajeError;
        if(UsuarioValidador.Validar(usuario,out mensajeError))
        {
             Console.WriteLine($"UsuarioValidador.Validar(usuario,out mensajeError)");
            _repositorio.AgregarUsuario(usuario);

            // Verificar el ID del usuario y otorgar permisos según corresponda
            if (usuario.Id == 1)
            {
                // Otorgar todos los permisos
                foreach (Permiso permiso in Enum.GetValues(typeof(Permiso)))
                {
                    _repositorio.AgregarPermisoUsuario(usuario.Id, permiso);
                }
            }
            else
            {
                // Otorgar permiso básico de lectura
                _repositorio.AgregarPermisoUsuario(usuario.Id, Permiso.ListarUsuarios);
                _repositorio.AgregarPermisoUsuario(usuario.Id, Permiso.ListarExpedientes);
                _repositorio.AgregarPermisoUsuario(usuario.Id, Permiso.ListarTramites);
            }
        }
        else
        {
            throw new ValidacionException(mensajeError);
        }
    }
}