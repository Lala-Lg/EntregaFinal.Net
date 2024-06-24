
namespace SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class Usuario
{
    public int Id { get; set;}
    public string Nombre { get; set;}="";

    public string Apellido{ get; set;}="";
    public string CorreoElectronico { get; set;}="";

    // Nuevos campos para almacenar el hash y la sal de la contraseña
    public string Contraseña { get; set; } = "";
    /*Sal se refiere a una cadena de datos aleatoria que se añade a la contraseña antes de calcular su hash
    La sal se genera de manera aleatoria y se combina con la contraseña antes de calcular su hash*/
    public string SalContraseña { get; set; } = "";

    public List<Permiso> ListaPermisos{ get; set;} = new List<Permiso>();
}