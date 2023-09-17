using System;
namespace facade;

public partial class MainPage : ContentPage
{
    public bool DidWin { get; set; } = true;

	public MainPage()
	{
		InitializeComponent();

	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
    }
}


