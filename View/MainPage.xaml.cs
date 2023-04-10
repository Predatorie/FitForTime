namespace FitForTime.View;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		var vm = ServiceProvider.GetService<MainPageViewModel>();
        this.BindingContext = vm;

        _ = vm.GetWorkoutAsync();
    }
}

