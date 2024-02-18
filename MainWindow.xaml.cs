using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using pet_shop.Views;

namespace pet_shop;
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.Title = "Pet Shop";
        AppWindow.SetIcon("C:\\Users\\l.campuzano.gonzalez\\Desktop\\pet_shop\\Assets\\pet_shoppin.ico");
        this.AppWindow.MoveAndResize(new Windows.Graphics.RectInt32(1000, 100, 600, 900));   
   }

    private void OnNavigationItemSelected(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        string cases = args.InvokedItemContainer?.Tag?.ToString();

        switch (cases)
        {
            case "listadoUsuario":
                ContentFrame.Navigate(typeof(UsuariosForm), null, new DrillInNavigationTransitionInfo());
                break;
            case "listarProductos":
                ContentFrame.Navigate(typeof(ListadoProductos), null, new DrillInNavigationTransitionInfo()); break;
            case "registrarUsuario":
                ContentFrame.Navigate(typeof(UsuarioForm), null, new DrillInNavigationTransitionInfo());
                break;
            case "registrarMascota":
                ContentFrame.Navigate(typeof(MascotaForm), null, new DrillInNavigationTransitionInfo());
                break;
        }
    }
}
