using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using pet_shop.Models;
using pet_shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet_shop.Views;

public sealed partial class ListadoProductosForm : Page
{
    public Producto Producto { get; set; }
    private UsuarioDAO UsuarioDAO { get; set; }

    public ListadoProductosForm()
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

        Producto = e.Parameter as Producto;
        if(Producto != null) 
        { 
            lis
        }
    }
}
