using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet_shop.Models;

public class Producto
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Foto { get; set; }
    public int Cantidad { get; set; };
    public List<Producto> Usuarios { get; set; }

    public Producto(
        string id,
        string nombre,
        string descripcion,
        string foto,
        int cantidad)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Foto = foto;
        Usuarios = new List<Producto>();
        Cantidad = cantidad;
    }

    public void AgregarComprador(Producto usuario)
    {
        Usuarios.Add(usuario);
    }
}
