using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Common;
using Microsoft.UI.Xaml.Media.Animation;
using pet_shop.Repository;
using pet_shop.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace pet_shop.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MascotaForm : Page
{
    public bool NombreValido { get; set; }
    public bool RazaValida { get; set; }
    public bool EdadValida { get; set; }
    public List<Usuario> Usuarios { get; set; }
    public Usuario Usuario { get; set; }
    private UsuarioDAO UsuarioDAO { get; set; }

    public MascotaForm()
    {
        this.InitializeComponent();
        UsuarioDAO = UsuarioDAO.Instance;
        Usuarios = UsuarioDAO.ObtenerUsuarios();
        cmbUsuarios.ItemsSource = Usuarios;
        NombreValido = false;
        RazaValida = false;
        EdadValida = false;  
    }

    private void CmbUsuarios(object sender, SelectionChangedEventArgs e)
    {
        Usuario = cmbUsuarios.SelectedItem as Usuario;
    }

    private void btn_RegistrarMascota(object sender, RoutedEventArgs e)
    {
        Mascota mascota = new Mascota(
                txtNombre.Text,
                txtRaza.Text,
                txtEdad.Text
            );

        UsuarioDAO.RegistrarMascota(Usuario, mascota);
        alert.IsOpen = true;
        alert.Title = "Registro completado";
        alert.Severity = InfoBarSeverity.Success;
        alert.Message = "La mascota " + mascota.Nombre + " ha sido registrada con exito!";
        alert.IsOpen = false;
        Frame.Navigate(typeof(UsuariosForm), Usuario, new SuppressNavigationTransitionInfo());
    }

    //MANEJADORES DE LAS VALIDACIONES AL SELECCIONAR LOS CAMPOS O CAMBIAR EL TEXTO
    private void NombreSeleccionado(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorNombre();
    }
    private void NombreCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorNombre();
    }
    private void RazaSeleccionada(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorRaza();
    }
    private void RazaCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorRaza();
    }
    private void EdadSeleccionada(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorEdad();
    }
    private void EdadCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorEdad();
    }

    //VALIDACIONES DE LOS CAMPOS

    //NOMBRE
    private void ValidadorNombre()
    {
        var Name = txtNombre.Text;

        if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
        {
            errorNombre.Visibility = Visibility.Visible;
            errorNombre.Text = "Ingresar un nombre";
            NombreValido = false;
        }
        else if (Name.IsNumeric())
        {
            errorNombre.Visibility = Visibility.Visible;
            errorNombre.Text = "Ingresar un nombre valido";
            NombreValido = false;
        }
        else
        {
            errorNombre.Visibility = Visibility.Collapsed;
            NombreValido = true;
            ValidacionNuevaMascota();
        }
    }

    //RAZA
    private void ValidadorRaza()
    {
        var VRaza = txtRaza.Text;

        if (string.IsNullOrEmpty(VRaza) || string.IsNullOrWhiteSpace(VRaza))
        {
            errorRaza.Visibility = Visibility.Visible;
            errorRaza.Text = "Ingresar la raza de la mascota";
            RazaValida = false;
        }
        else if (VRaza.IsNumeric())
        {
            errorRaza.Visibility = Visibility.Visible;
            errorRaza.Text = "Ingresar una raza válida";
            RazaValida = false;
        }
        else
        {
            errorRaza.Visibility = Visibility.Collapsed;
            RazaValida = true;
            ValidacionNuevaMascota();
        }
    }

    //EDAD
    private void ValidadorEdad()
    {
        var VEdad = txtEdad.Text;

        if (string.IsNullOrEmpty(VEdad) || string.IsNullOrWhiteSpace(VEdad))
        {
            errorEdad.Visibility = Visibility.Visible;
            errorEdad.Text = "Ingresar edad";
            EdadValida = false;
        }
        else if (!VEdad.IsNumeric())
        {
            errorEdad.Visibility = Visibility.Visible;
            errorEdad.Text = "Ingresar edad válida";
            EdadValida = false;
        }
        else
        {
            errorEdad.Visibility = Visibility.Collapsed;
            EdadValida = true;
            ValidacionNuevaMascota();
        }
    }

    //NUEVA MASCOTA
    private void ValidacionNuevaMascota()
    {
        if (NombreValido && RazaValida && EdadValida)
        {
            btnGuardar.IsEnabled = true;
            alert.IsOpen = false;
        }
        else
        {
            btnGuardar.IsEnabled = false;
            alert.IsOpen = true;
            alert.Height = 60;
            alert.FontSize = 12;
            alert.Width = 200;
            alert.Severity = InfoBarSeverity.Error;
            alert.Message = "Los datos de la mascota invalidos";
        }
    }
}
