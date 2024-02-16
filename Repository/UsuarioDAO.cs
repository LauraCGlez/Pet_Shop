using System.Collections.Generic;
using System.Linq;
using pet_shop.Exceptions;
using pet_shop.Models;

namespace pet_shop.Repository;
public class UsuarioDAO
{
    private static UsuarioDAO instance;
    private List<Usuario> Usuarios;

    public UsuarioDAO()
    {
        Usuarios = new List<Usuario>();
    }
    public static UsuarioDAO Instance
    {
        get
        {
            instance ??= new UsuarioDAO();
            return instance;
        }
    }

    //CRUD DE USUARIO
    //CREATE
    public void IncluirUsuario(Usuario usuario)
    {
        if (Usuarios.Any(s => s.Dni == usuario.Dni))
        {
            throw new DuplicationException("Usuario con Dni: " + usuario.Dni + " se encuentra registrado.");
        }
        Usuarios.Add(usuario);
    }

    //UPDATE
    public void ActualizarUsuario(Usuario usuarioActualizado)
    {
        int actualizar = Usuarios.FindIndex(usuario => usuario.Dni == usuarioActualizado.Dni);

        if (actualizar != -1)
        {
            Usuarios[actualizar].Nombre = usuarioActualizado.Nombre;
            Usuarios[actualizar].Apellido = usuarioActualizado.Apellido;
            Usuarios[actualizar].Email = usuarioActualizado.Email;
            Usuarios[actualizar].Telefono = usuarioActualizado.Telefono;
        }
    }

    //GET
    public List<Usuario> ObtenerUsuarios()
    {
        return Usuarios;
    }

    //DELETE
    public void EliminarUsuario(Usuario u)
    {
        Usuarios.Remove(u);

    }

    //MÉTODOS AUXILIARES
    public bool ExisteDni(string Dni)
    {
        bool existeDni = false;
        if (Usuarios.Any(s => s.Dni == Dni))
        {
            return existeDni = true;
        }
        return existeDni;
    }

    public void RegistrarMascota(Usuario usuario, Mascota mascota)
    {
        Usuario usuarioExistente = Usuarios.FirstOrDefault(usu => usu.Dni.Equals(usuario.Dni));

        if (usuarioExistente != null)
        {
            usuarioExistente.AgregarMascota(mascota);
        }
    }

    public void EliminarMascota(Usuario usuario, Mascota mascota)
    {
        Usuario usuarioExistente = Usuarios.FirstOrDefault(s => s.Dni.Equals(usuario.Dni));
        if(usuarioExistente != null)
        {
            usuarioExistente.EliminarMascota(mascota);
        }
    }
}
