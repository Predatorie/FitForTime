namespace FitForTime.View;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = ServiceProvider.GetService<MainPageViewModel>();
    }
}

