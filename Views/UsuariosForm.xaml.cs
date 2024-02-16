using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using pet_shop.Models;
using pet_shop.Repository;
using pet_shop.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace pet_shop.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class UsuariosForm : Page
{
    public ObservableCollection<Usuario> Usuarios { get; set; }
    private UsuarioDAO UsuarioDAO { get; set; }

    public UsuariosForm()
    {
        this.InitializeComponent();
        UsuarioDAO = UsuarioDAO.Instance;
        Usuarios = new ObservableCollection<Usuario>(UsuarioDAO.ObtenerUsuarios());
        collection.ItemsSource = Usuarios;
    }

    private async void collection_Loaded(object sender, RoutedEventArgs e)
    {
        if (Usuarios != null)
        {
            collection.ScrollIntoView(Usuarios, ScrollIntoViewAlignment.Default);
            collection.UpdateLayout();

            ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
            if (animation != null)
            {
                if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                {
                    animation.Configuration = new DirectConnectedAnimationConfiguration();
                }

                await collection.TryStartConnectedAnimationAsync(animation, Usuarios, "connectedElement");
            }
            collection.Focus(FocusState.Programmatic);
        }
    }

    private void collection_ItemClick(object sender, ItemClickEventArgs e)
    {
        Usuario usuarioSeleccionado = null;
        if (collection.ContainerFromItem(e.ClickedItem) is ListViewItem container)
        {
            usuarioSeleccionado = container.Content as Usuario;
            var animation = collection.PrepareConnectedAnimation("ForwardConnectedAnimation", usuarioSeleccionado, "connectedElement");

        }
        Frame.Navigate(typeof(ListadoUsuarios), usuarioSeleccionado, new SuppressNavigationTransitionInfo());
    }

}
