using pet_shop.Models;
using System.Collections.Generic;
using System.Linq;
using pet_shop.Exceptions;

namespace pet_shop.Repository;

public class ProductoDAO
{
    private static ProductoDAO instance;
    public List<Producto> Producto;

    public ProductoDAO() 
    {
        Producto = new List<Producto>();
    }

    public static ProductoDAO Instance
    {
        get
        {
            instance ??= new ProductoDAO();
            return instance;
        }
    }

    //CRUD DE PRODUCTOS
    //CREATE
    public void IncluirProducto(Producto productos)
    {
        if(Producto.Any(p => p.Id == productos.Id)) 
        {
            throw new DuplicationException("El producto con ese identificador no se encuentra registrado");
        }
        Producto.Add(productos);
    }

    //UPDATE
    public void ActualizarProducto(Producto productoActualizado)
    {
        int actualizar = Producto.FindIndex(producto => producto.Id == productoActualizado.Id);

        if(actualizar > -1)
        {
            Producto[actualizar].Nombre = productoActualizado.Nombre;
            Producto[actualizar].Descripcion = productoActualizado.Descripcion;
            Producto[actualizar].Cantidad = productoActualizado.Cantidad;
        }
    }

    //GET
    public List<Producto> ListarProductos()
    {
        return Producto;
    }

    //DELETE
    public void EliminarProducto(Producto p)
    {
        Producto.Remove(p);
    }

    //MÉTODOS AUXILIARES
    public bool ExisteId(string Id)
    {
        bool existeId = false;
        if (Producto.Any(producto => producto.Id == Id))
        {
            return existeId = true;
        }
        return existeId;
    }

    public void RegistrarComprador(Producto productos, Producto usuario)
    {
        Producto productoExistente = Producto.FirstOrDefault(producto => producto.Id.Equals(productos.Id));
    
        if (productoExistente != null) 
        {
            productoExistente.AgregarComprador(usuario);
        }
    }

}
