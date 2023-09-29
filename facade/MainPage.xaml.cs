using CommunityToolkit.Mvvm.ComponentModel;
using System;
namespace facade;

public partial class MainPage : ContentPage
{

    public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();

    }
        //async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
        //}
    }


