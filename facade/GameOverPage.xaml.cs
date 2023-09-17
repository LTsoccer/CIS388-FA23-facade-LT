namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
	private int guessnumber;

	private bool didWin;
	public bool DidWin
	{
		get => didWin;
		set
		{
			didWin = value;
			if (didWin) { ResultLabel.Text = $"you won!\nit took you {guessnumber} guesses"; }
			else
			{
                { ResultLabel.Text = "you lost..."; }
            }
	}
	}
	public GameOverPage()
	{
		InitializeComponent();
        guessnumber = 4;

    }

    async void Restart_Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
