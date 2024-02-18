using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using pet_shop.Models;
using pet_shop.Repository;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace pet_shop.Views;
/// <summary>
/// Display Producto details data 
/// </summary>
public sealed partial class ListadoUsuariosForm : Page
{
    public Usuario Usuario { get; set; }
    private UsuarioDAO UsuarioDAO { get; set; }

    public ListadoUsuariosForm()
    {
        InitializeComponent();
        BtnAtras.Loaded += CargarBtnAtras;
        UsuarioDAO = UsuarioDAO.Instance;
    }

    private void CargarBtnAtras(object sender, RoutedEventArgs e)
    {
        BtnAtras.Focus(FocusState.Programmatic);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        Usuario = e.Parameter as Usuario;

        if (Usuario.Mascotas.LongCount() > 0)
        {
            listaMascotas.ItemsSource = Usuario.Mascotas;
        }
        else
        {
            tituloMascotas.Text = "No hay mascotas registradas";
            tituloMascotas.Style = (Style)Application.Current.Resources["BodyStrongTextBlockStyle"];
        }


        ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
        if (imageAnimation != null)
        {
            imageAnimation.TryStart(detailedImage, new UIElement[] { coordinatedPanel });

        }
    }


    private void BtnAtrasAction(object sender, RoutedEventArgs e)
    {
        Frame.GoBack();
    }

    private void BtnEliminarUsuario(object sender, RoutedEventArgs e)
    {
        UsuarioDAO.EliminarUsuario(Usuario);
        Frame.GoBack();
    }

    private void BtnEditarUsuario(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(UsuarioForm), Usuario, new SuppressNavigationTransitionInfo());
    }


}
