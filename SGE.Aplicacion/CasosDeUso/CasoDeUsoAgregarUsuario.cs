namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;

public class CasoDeUsoAgregarUsuario : CasoDeUsoUsuario
{
    private readonly IUsuarioRepositorio _repositorio;

    public CasoDeUsoAgregarUsuario(IUsuarioRepositorio repositorio) : base(repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario)
    {
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
}