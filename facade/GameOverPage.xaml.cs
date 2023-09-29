namespace facade;

public partial class GameOverPage : ContentPage
{
	public GameOverPage()
	{
		InitializeComponent();
        BindingContext = new GameOverPageViewModel();

    }

}
