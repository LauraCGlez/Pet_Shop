using Microsoft.UI.Xaml;

namespace pet_shop;
public partial class App : Application
{
    private Window window;
    public App()
    {
        this.InitializeComponent();
    }
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        window = new MainWindow();
        window.Activate();
    }
    
}
