﻿#pragma checksum "C:\Users\l.campuzano.gonzalez\Desktop\gitVersion\Views\UsuarioForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C05548F15F990EE5741F4CE786A3D7F36C2FB63E27C3FFB50A3890A5F0E22286"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pet_shop.Views
{
    partial class UsuarioForm : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\UsuarioForm.xaml line 24
                {
                    this.btnVolver = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.btnVolver).Click += this.BtnAtras;
                }
                break;
            case 3: // Views\UsuarioForm.xaml line 34
                {
                    this.titulo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 4: // Views\UsuarioForm.xaml line 44
                {
                    this.alert = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.InfoBar>(target);
                }
                break;
            case 5: // Views\UsuarioForm.xaml line 50
                {
                    this.txtDni = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtDni).GotFocus += this.DniSeleccionado;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtDni).TextChanged += this.DniCambiarTexto;
                }
                break;
            case 6: // Views\UsuarioForm.xaml line 58
                {
                    this.dniErroneo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 7: // Views\UsuarioForm.xaml line 67
                {
                    this.txtNombre = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtNombre).GotFocus += this.NombreSeleccionado;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtNombre).TextChanged += this.NombreCambiadarTexto;
                }
                break;
            case 8: // Views\UsuarioForm.xaml line 75
                {
                    this.nombreErroneo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 9: // Views\UsuarioForm.xaml line 84
                {
                    this.txtApellido = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtApellido).GotFocus += this.ApellidoSeleccionado;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtApellido).TextChanged += this.ApellidoCambiarTexto;
                }
                break;
            case 10: // Views\UsuarioForm.xaml line 92
                {
                    this.apellidoErroneo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 11: // Views\UsuarioForm.xaml line 101
                {
                    this.txtEmail = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtEmail).GotFocus += this.EmailSeleccionado;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtEmail).TextChanged += this.EmailCambiarTexto;
                }
                break;
            case 12: // Views\UsuarioForm.xaml line 109
                {
                    this.emailErroneo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 13: // Views\UsuarioForm.xaml line 118
                {
                    this.txtTelefono = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtTelefono).GotFocus += this.TelefonoSeleccionado;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.txtTelefono).TextChanged += this.TelefonoCambiarTexto;
                }
                break;
            case 14: // Views\UsuarioForm.xaml line 126
                {
                    this.telefonoErroneo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 15: // Views\UsuarioForm.xaml line 134
                {
                    this.btnGuardar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.btnGuardar).Click += this.BtnRegistrar;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
