using CommunityToolkit.Common;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using pet_shop.Models;
using pet_shop.Repository;
using System;
using System.Text.RegularExpressions;

namespace pet_shop.Views;
public sealed partial class UsuarioForm : Page
{
    private bool DniValido { get; set; }
    private bool NombreValido { get; set; }
    private bool ApellidoValido { get; set; }
    private bool EmailValido { get; set; }
    private bool TelefonoValido { get; set; }
    private bool UsuarioEditado { get; set; }
    private UsuarioDAO UsuarioDAO { get; set; }

    public UsuarioForm()
    {
        this.InitializeComponent();
        UsuarioDAO = UsuarioDAO.Instance;
        NombreValido = false;
        ApellidoValido = false;
        EmailValido = false;
        TelefonoValido = false;   
        DniValido = false;
        UsuarioEditado = false;
        btnVolver.Visibility = Visibility.Collapsed; 
    }

    //Método Auxiliar
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Parameter is Usuario usuario) 
        {
            CargarDatosForm(usuario);
        }
    }

    private void CargarDatosForm(Usuario usuario)
    {
        //VERIFICADORES
        UsuarioEditado = true;
        txtDni.IsEnabled = false;
        DniValido = true;
        titulo.Text = "Actualizar Usuario";

        //CAMPOS A RELLENAR
        txtDni.Text = usuario.Dni;
        txtNombre.Text = usuario.Nombre;
        txtApellido.Text = usuario.Apellido;
        txtTelefono.Text = usuario.Telefono;
        txtEmail.Text = usuario.Email;
        
        //BOTONES
        btnGuardar.Content = "Actualizar";
        btnVolver.Visibility = Visibility.Visible;
    }

    //MANEJADORES DE LAS VALIDACIONES AL SELECCIONAR LOS CAMPOS O CAMBIAR EL TEXTO
    private void NombreSeleccionado(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorNombre();
    }
    private void NombreCambiadarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorNombre();
    }
    private void ApellidoSeleccionado(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorApellido();
    }
    private void ApellidoCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorApellido();
    }
    private void EmailSeleccionado(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorEmail();
    }
    private void EmailCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorEmail();
    }
    private void TelefonoSeleccionado(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorTelefono();
    }
    private void TelefonoCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorTelefono();
    }
    private void BtnRegistrar(object sender, RoutedEventArgs routedEvent)
    {
        Random random = new Random();
        int numeroRandom = random.Next(1, 100);

        Usuario usuario = new Usuario(
                txtDni.Text,
                txtNombre.Text,
                txtApellido.Text,
                txtTelefono.Text,
                txtEmail.Text,
                "https://randomuser.me/api/portraits/women/" + numeroRandom + ".jpg"
            );
        if (UsuarioEditado)
        {
            UsuarioDAO.ActualizarUsuario(usuario);
            Frame.Navigate(typeof(UsuariosForm),null, new SuppressNavigationTransitionInfo());
        }
        else
        {
            UsuarioDAO.IncluirUsuario(usuario);
            alert.IsOpen = true;
            alert.Title = "¡Enhorabuena!";
            alert.Severity = InfoBarSeverity.Success;
            alert.Message = "Usuario " + usuario.Nombre + " registrado con exito!";
        }
        ResetearCampos();
        ResetearValidaciones();
    }
    private void DniSeleccionado(object sender, RoutedEventArgs routedEvent)
    {
        ValidadorDni();
    }
    private void DniCambiarTexto(object sender, TextChangedEventArgs textChangedEvent)
    {
        ValidadorDni();
    }

    //VALIDACIONES DE LOS CAMPOS
    //DNI
    private void ValidadorDni()
    {
        string Dni = txtDni.Text;
        string ComprobarDni = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,9}[A-Za-z]$";

        if (string.IsNullOrEmpty(Dni) || string.IsNullOrWhiteSpace(Dni))
        {
            dniErroneo.Visibility = Visibility.Visible;
            dniErroneo.Text = "Campo obligatorio";
            DniValido = false;
        }
        else if (!Regex.IsMatch(Dni, ComprobarDni))
        {
            dniErroneo.Visibility = Visibility.Visible;
            dniErroneo.Text = "Debe ingresar un Dni válido";
            DniValido = false;
        }
        else if (UsuarioDAO.ExisteDni(Dni))
        {
            dniErroneo.Visibility = Visibility.Visible;
            dniErroneo.Text = "Ya hay un usuario registrado con ese DNI/NIE";
            DniValido = false;
        }
        else
        {
            dniErroneo.Visibility = Visibility.Collapsed;
            DniValido = true;
            ValidacionNuevoUsuario();
        }
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
            ValidacionNuevoUsuario();
        }
    }

    //APELLIDO
    private void ValidadorApellido()
    {
        string LastName = txtApellido.Text;

        if (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName))
        {
            apellidoErroneo.Visibility = Visibility.Visible;
            apellidoErroneo.Text = "Campo obligatorio";
            ApellidoValido = false;
        }
        else if (LastName.IsNumeric())
        {
            apellidoErroneo.Visibility = Visibility.Visible;
            apellidoErroneo.Text = "Debe ingresar un apellido válido";
            ApellidoValido = false;
        }
        else
        {
            apellidoErroneo.Visibility = Visibility.Collapsed;
            ApellidoValido = true;
            ValidacionNuevoUsuario();
        }
    }

    //EMAIL
    private void ValidadorEmail()
    {
        string Email = txtEmail.Text;
        string ComprobarEmail = ".*@petshoppin\\.com";

        if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email) || !Regex.IsMatch(Email, ComprobarEmail))
        {
            emailErroneo.Visibility = Visibility.Visible;
            emailErroneo.Text = "Campo obligatorio: ****@petshoppin.com";
            EmailValido = false;
        }
        else if (!Email.IsEmail())
        {
            emailErroneo.Visibility = Visibility.Visible;
            emailErroneo.Text = "Debe ingresar un email válido";
            EmailValido = false;
        }
        else
        {
            emailErroneo.Visibility = Visibility.Collapsed;
            EmailValido = true;
            ValidacionNuevoUsuario();
        }
    }

    //TELÉFONO
    private void ValidadorTelefono()
    {
        string VTelefono = txtTelefono.Text;

        if (string.IsNullOrEmpty(VTelefono) || string.IsNullOrWhiteSpace(VTelefono))
        {
            telefonoErroneo.Visibility = Visibility.Visible;
            telefonoErroneo.Text = "Campo obligatorio";
            TelefonoValido = false;
        }
        else if (!VTelefono.IsNumeric())
        {
            telefonoErroneo.Visibility = Visibility.Visible;
            telefonoErroneo.Text = "El teléfono solo puede contener números";
            TelefonoValido = false;
        }
        else if (VTelefono.Length < 9 || VTelefono.Length > 9)
        {
            telefonoErroneo.Visibility = Visibility.Visible;
            telefonoErroneo.Text = "Debe tener 9 dígitos";
            TelefonoValido = false;
        }
        else
        {
            telefonoErroneo.Visibility = Visibility.Collapsed;
            TelefonoValido = true;
            ValidacionNuevoUsuario();
        }
    }

    //NUEVO USUARIO
    private void ValidacionNuevoUsuario()
    {   
        if (NombreValido && ApellidoValido && DniValido && EmailValido && TelefonoValido)
        {   
            btnGuardar.IsEnabled = true;
            alert.IsOpen = false;
        }
        else 
        {
            btnGuardar.IsEnabled = false;
            alert.IsOpen = true;
            alert.Title = "Error";
            alert.Severity = InfoBarSeverity.Error;
            alert.Message = "Los datos del usuario no son correctos";
        }
    }

    private void ResetearCampos()
    {
        txtDni.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtEmail.Text = string.Empty;
    }

    private void ResetearValidaciones()
    {
        dniErroneo.Visibility = Visibility.Collapsed;
        nombreErroneo.Visibility = Visibility.Collapsed;
        apellidoErroneo.Visibility = Visibility.Collapsed;
        telefonoErroneo.Visibility = Visibility.Collapsed;
        emailErroneo.Visibility = Visibility.Collapsed;
        NombreValido = false;
        ApellidoValido = false;
        EmailValido = false;
        TelefonoValido = false;
        DniValido = false;
    }

    private void BtnAtras(object sender, RoutedEventArgs e)
    {
        Frame.GoBack();
    }
}
