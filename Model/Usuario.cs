using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet_shop.Models;
public class Usuario
{
    public string Dni { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Foto { get; set; }
    public List<Mascota> Mascotas { get; set; }


    public Usuario(
        string dni,
        string nombre,
        string apellido,
        string telefono,
        string email,
        string foto)
    {
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Email = email;
        Foto = foto;
        Mascotas = new List<Mascota>();
    }

    public void AgregarMascota(Mascota mascota)
    {
        Mascotas.Add(mascota);
    }

    public void EliminarMascota(Mascota mascota)
    {
        Mascotas.Remove(mascota);
    }
}
