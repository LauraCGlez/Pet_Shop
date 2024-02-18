using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using pet_shop.Models;
using pet_shop.Repository;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.VisualBasic;
using Windows.Foundation.Metadata;
using Microsoft.Windows.ApplicationModel.DynamicDependency;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace pet_shop.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ListadoProductos : Page
{
    public ObservableCollection<Producto> Productos { get; set; }
    private ProductoDAO ProductoDAO { get; set; }
    public ListadoProductos()
    {
        this.InitializeComponent();
        ProductoDAO = ProductoDAO.Instance;
        Productos = new ObservableCollection<Producto>(ProductoDAO.ListarProductos());
        listaProductos.ItemsSource = Productos;
    }

    private async void collection_Loaded(object sender, RoutedEventArgs e)
    {
        if (Productos != null)
        {
            // If the connected item appears outside the viewport, scroll it into view.
            listaProductos.ScrollIntoView(Productos, ScrollIntoViewAlignment.Default);
            listaProductos.UpdateLayout();

            // Play the second connected animation.
            ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
            if (animation != null)
            {
                // Setup the "back" configuration if the API is present.
                if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                {
                    animation.Configuration = new DirectConnectedAnimationConfiguration();
                }

                await listaProductos.TryStartConnectedAnimationAsync(animation, Productos, "connectedElement");
            }

            // Set focus on the list
            listaProductos.Focus(FocusState.Programmatic);
        }
    }

    private void collection_ItemClick(object sender, ItemClickEventArgs e)
    {
        Producto productoSeleccionado = null;
        if (listaProductos.ContainerFromItem(e.ClickedItem) is ListViewItem container)
        {
            productoSeleccionado = container.Content as Producto;
            var animation = listaProductos.PrepareConnectedAnimation("ForwardConnectedAnimation", productoSeleccionado, "connectedElement");

        }
        Frame.Navigate(typeof(ListadoUsuariosForm), productoSeleccionado, new SuppressNavigationTransitionInfo());
    }

    private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
    {
        // Aquí podrías agregar lógica para abrir una ventana de agregar producto
        // Después de agregar el producto, actualiza la lista y la vista
        Producto nuevoProducto = ObtenerNuevoProducto(); // Debes implementar esta función
        ProductoDAO.IncluirProducto(nuevoProducto);

        

        ActualizarListaProductos();
    }

    private void ActualizarListaProductos()
    {
        // Limpiar la lista y cargar los productos actualizados
        Productos.Clear();
        foreach (var producto in ProductoDAO.ListarProductos())
        {
            Productos.Add(producto);
        }
    }

    // Llamado cuando se hace clic en el botón de eliminar producto (por ejemplo)
    private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
    {
        // Aquí podrías agregar lógica para eliminar un producto
        // Después de eliminar el producto, actualiza la lista y la vista
        Producto productoAEliminar = ObtenerProductoSeleccionado(); // Debes implementar esta función
        ProductoDAO.EliminarProducto(productoAEliminar);
        ActualizarListaProductos();
    }

    private Producto ObtenerNuevoProducto()
    {
        

        return null; // Puedes devolver null o algo más según tus necesidades
    }

    // Método para obtener el producto seleccionado en la lista
    private Producto ObtenerProductoSeleccionado()
    {
        if (listaProductos.SelectedItem is Producto productoSeleccionado)
        {
            return productoSeleccionado;
        }
        else
        {
            return null;
        }
    }


}
