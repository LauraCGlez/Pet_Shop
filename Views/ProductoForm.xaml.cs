using CommunityToolkit.Common;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using pet_shop.Models;
using pet_shop.Repository;
using System;
using Windows.Management;

namespace pet_shop.Views;

public sealed partial class ProductoForm : Page
{
    private ProductoDAO ProductoDAO { get; set; }
    private bool NombreValido { get; set; }
    private bool CantidadValida { get; set; }
    public ProductoForm()
    {
        this.InitializeComponent();
        NombreValido = false;
        CantidadValida = false;
        btnVolver.Visibility.Collapse;
        ProductoDAO = ProductoDAO.Instance;
    }

    //MÉTODO AUXILIAR
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Parameter is Producto producto)
        {
            CargarDatosForm(producto);
        }
    }

    private void BtnAnhadirProducto(object o, RoutedEvent routedEvent)
    {
        Random rnd = new Random();
        int random = rnd.Next(1, 100);

        Producto producto = new Producto(
            txtNombre.Text,
            txtDescripcion.Text,
            txtCantidad.Text,
            "C:\\Users\\l.campuzano.gonzalez\\Desktop\\pet_shop\\Assets\\") + random + ".jpg"
            );
        if (ProductoEditado)
        {
            ProductoDAO.ActualizarProducto(producto);
            Frame.Navigate(typeof(ProductoForm), null, new SuppressNavigationTransitionInfo());
        }
        else
        {
            ProductoDAO.ActualizarProducto(producto);
            alert.IsOpen = true;
            alert.Title = "¡Enhorabuena!";
            alert.Severity = InfoBarSeverity.Success;
            alert.Message = "EL producto " + producto.Nombre + " registrado con exito!";
        }
    }
    private void CargarDatosForm(Producto producto)
    {
        //VERIFICADORES
        ProductoEditado = true;
        titulo.Text = "Actualizar Producto";

        //CAMPOS A RELLENAR
        txtNombre.Text = producto.Nombre;
        txtDescripcion.Text = producto.Descripcion;
        textCantidad.Text = producto.Cantidad.ToString();

        //BOTONES
        btnGuardar.Content = "Actualizar";
        btnVolver.Visibility = Visibility.Visible;
    }

    //NOMBRE
    private void ValidadorNombre()
    {
        string VNombre = txtNombre.Text;

        if (string.IsNullOrEmpty(VNombre) || string.IsNullOrWhiteSpace(VNombre))
        {
            nombreErroneo.Visibility = Visibility.Visible;
            nombreErroneo.Text = "Campo obligatorio";
            NombreValido = false;
        }
        else if (VNombre.IsNumeric())
        {
            nombreErroneo.Visibility = Visibility.Visible;
            nombreErroneo.Text = "Debe ingresar un nombre válido";
            NombreValido = false;
        }
        else
        {
            nombreErroneo.Visibility = Visibility.Collapsed;
            NombreValido = true;
            ValidacionNuevoProducto();
        }
    }

    private void ValidadorCantidad()
    {
        string VCantidad = intCantidad.Text;

        if (string.IsNullOrWhiteSpace(VCantidad))
        {
            cantidadErronea.Visibility = Visibility.Visible;
            cantidadErronea.Text = "Campo obligatorio";
            CantidadValida = false;
        }
        else if (!int.TryParse(VCantidad, out int cantidad) || cantidad <= 0)
        {
            cantidadErronea.Visibility = Visibility.Visible;
            cantidadErronea.Text = "Debe ingresar una cantidad válida (número entero positivo)";
            CantidadValida = false;
        }
        else
        {
            cantidadErronea.Visibility = Visibility.Collapsed;
            CantidadValida = true;
            ValidacionNuevoProducto();
        }
    }


    private void NombreSeleccionado(object o, RoutedEventArgs routedEvent)
    {
        ValidadorNombre();
    }
    private void NombreCambiadarTexto(object o, TextChangedEventArgs textChangedEvent)
    {
        ValidadorNombre();
    }
    private void CantidadSeleccionada(object o, RoutedEventArgs routedEvent)
    {
        ValidadorCantidad();
    }
    private void CantidadCambiarTexto(object o, TextChangedEventArgs textChangedEvent)
    {
        ValidadorCantidad();
    }


    private void ValidacionNuevoProducto()
    {
        if (NombreValido && CantidadValida)
        {
            btnGuardar.IsEnable = true;
            alert.IsOpen = false;
        }
        else
        {
            btnGuardar.IsEnable = false;
            alert.IsOpen = true;
            alert.Title = "Error";
            alert.Severity = InfoBarSeverity.Error;
            alert.Message = "Los datos del producto no son correctos";
        }
    }

    private void ResetearCampo()
    {
        txtNombre.Text = string.Empty;
        txtCantidad.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
    }

    private void ResetearValidaciones()
    {
        nombreErroneo.Visibility = Visibility.Collapsed;
        NombreValido = false;
        CantidadValida = false;
    }

    private void BtnAtras(object sender, RoutedEventArgs e)
    {
        Frame.GoBack();
    }
}

