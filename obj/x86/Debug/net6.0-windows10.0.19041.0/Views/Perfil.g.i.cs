// Updated by XamlIntelliSenseFileGenerator 23/02/2024 3:33:22
#pragma checksum "C:\Users\l.campuzano.gonzalez\Desktop\gitVersion\Views\Perfil.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E00562568F8671806DB79520DA996676991B26D98A8DAB4BE331B626021FE416"
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
    partial class Perfil : global::Microsoft.UI.Xaml.Controls.Page
    {
#pragma warning restore 0649
#pragma warning restore 0169
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2309")]
        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;

            global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///Views/Perfil.xaml");
            global::Microsoft.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Microsoft.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }

        partial void UnloadObject(global::Microsoft.UI.Xaml.DependencyObject unloadableObject);

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2309")]
        private interface IPerfil_Bindings
        {
            void Initialize();
            void Update();
            void StopTracking();
            void DisconnectUnloadedObject(int connectionId);
        }

        private interface IPerfil_BindingsScopeConnector
        {
            global::System.WeakReference Parent { get; set; }
            bool ContainsElement(int connectionId);
            void RegisterForElementConnection(int connectionId, global::Microsoft.UI.Xaml.Markup.IComponentConnector connector);
        }

        internal global::Microsoft.UI.Xaml.Controls.Grid headerBackground;
        internal global::Microsoft.UI.Xaml.Controls.Button GoBackButton;
        internal global::Microsoft.UI.Xaml.Controls.Button EditButton;
        internal global::Microsoft.UI.Xaml.Controls.Button DeleteButton;
        internal global::Microsoft.UI.Xaml.Controls.Grid headerContent;
        internal global::Microsoft.UI.Xaml.Controls.Image detailedImage;
        internal global::Microsoft.UI.Xaml.Controls.StackPanel coordinatedPanel;
        internal global::Microsoft.UI.Xaml.Controls.TextBlock mascotas;
        internal global::Microsoft.UI.Xaml.Controls.ListView listaMascotas;
#pragma warning restore 0649
#pragma warning restore 0169
    }
}


