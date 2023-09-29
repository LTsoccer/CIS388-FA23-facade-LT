using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace facade
{

    [QueryProperty("Clean", "Clean")]
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string secretColor;

        [ObservableProperty]
        private string hexColor;

        public ObservableCollection<String> Letters { get; set; }

        [ObservableProperty]
        private Color secretColorHex;

        [ObservableProperty]
        private string currentGuess;

        [ObservableProperty]
        private bool didWin = false;

        [ObservableProperty]
        private int guessNumber;

        public ObservableCollection<ColorGuess> Guesses { get; set; }

        //public string SecretColor { get; set; }

        private bool clean;
        public bool Clean
        {
            get => clean;
            set
            {
                clean = value;
                if (clean)
                {
                    Restart();
                }
            }
        }


        public MainPageViewModel()
        {
            Letters = new ObservableCollection<String>();
            secretColor = "";
            Random rand = new Random(); 
            for (int j = 0; j < 6; j++)
            {
                int number = rand.Next(1,7);
                if (number == 1) { secretColor = secretColor + 'a'; }
                if (number == 2) { secretColor = secretColor + 'b'; }
                if (number == 3) { secretColor = secretColor + 'c'; }
                if (number == 4) { secretColor = secretColor + 'd'; }
                if (number == 5) { secretColor = secretColor + 'e'; }
                if (number == 6) { secretColor = secretColor + 'f'; }
            }
            secretColorHex = Color.FromArgb(secretColor);
            hexColor = secretColor;
            currentGuess = "";
            guessNumber = 0;
        
            Guesses = new ObservableCollection<ColorGuess>();

        }

        [RelayCommand]
        void Help()
        {
            Shell.Current.DisplayAlert("how to play", "input letters to guess the hex color and press enter to see the result", "ok!");
        }


        [RelayCommand]
        void AddLetter(string letter)
        {
            if (CurrentGuess.Length >= 0 & CurrentGuess.Length < 6)
            {
                Letters.Add(letter);
                CurrentGuess += letter;
            }
        }

        [RelayCommand]
        void DeleteLetter()
        {
            if (CurrentGuess.Length > 0)
            {
                Letters.RemoveAt(CurrentGuess.Length - 1);
                CurrentGuess = CurrentGuess.Substring(0, CurrentGuess.Length - 1);
            }
        }

        [RelayCommand]
        void Guess()
        {
            GuessNumber++;
            if (CurrentGuess.Length < 6){
                GuessNumber--;
            }
            else if (CurrentGuess == SecretColor)
            {
                DidWin = true;
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?GuessNumber={GuessNumber}&DidWin={DidWin}&SecretColor={SecretColor}&HexColor={HexColor}");
            }
            // if correct, then go to game over (DidWin=true)

            // else if this is the 6th guess (and it's wrong)
            // then go to game over (DidWin=false)
            else if (GuessNumber == 6)
            {

                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?GuessNumber={GuessNumber}&DidWin={DidWin}&SecretColor={SecretColor}&HexColor={HexColor}");
            }
            else
            {
                // Add this guess to the Guesses
                Guesses.Add(new ColorGuess(CurrentGuess));
                CurrentGuess = "";
                Letters.Clear();
            }

        }


        [RelayCommand]
        void Restart()
        {
            SecretColor = "";
            Random rand = new Random();
            for (int j = 0; j < 6; j++)
            {
                int number = rand.Next(1, 7);
                if (number == 1) { SecretColor = SecretColor + 'a'; }
                if (number == 2) { SecretColor = SecretColor + 'b'; }
                if (number == 3) { SecretColor = SecretColor + 'c'; }
                if (number == 4) { SecretColor = SecretColor + 'd'; }
                if (number == 5) { SecretColor = SecretColor + 'e'; }
                if (number == 6) { SecretColor = SecretColor + 'f'; }
            }
            HexColor = SecretColor;
            SecretColorHex = Color.FromArgb('#' + SecretColor);
            CurrentGuess = "";
            GuessNumber = 0;
            DidWin = false;
            Guesses.Clear();
            clean = false;
            Letters.Clear();
        }



    }
}