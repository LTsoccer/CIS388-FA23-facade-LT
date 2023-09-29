using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
    [QueryProperty("GuessNumber", "GuessNumber")]

    [QueryProperty("DidWin", "DidWin")]

    [QueryProperty("SecretColor", "SecretColor")]

    [QueryProperty("HexColor", "HexColor")]

    public partial class GameOverPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private bool clean;

        [ObservableProperty]
        private string text;

        private int guessNumber;
        public int GuessNumber
        {
            get => guessNumber;
            set
            {
                guessNumber = value;
            }
        }

        [ObservableProperty]
        private Color colorhex;

        private string hexColor;
        public string HexColor
        {
            get => '#' + hexColor;
            set
            {
                hexColor = '#' + value;
                Colorhex = Color.FromArgb(hexColor);
            }
        }

        [ObservableProperty]
        private string secretColor;
        public string SecretColored
        {
            get => SecretColor;
            set
            {
                SecretColor = value;
                SecretColored = value;
            }
        }



        private bool didWin;
        public bool DidWin
        {
            get => didWin;
            set
            {
                didWin = value;
                if (didWin && guessNumber != 0 && guessNumber < 2)
                {
                    Text = $"you won!\nyou got it on the {guessNumber}st guess!";
                }
                else if (didWin && guessNumber != 0 && guessNumber < 4)
                {
                    Text = $"you won!\ngood job only using {guessNumber} guesses";
                }
                else if (didWin && guessNumber != 0 && guessNumber < 6)
                {
                    Text = $"you won!\nfinally got it with \n{guessNumber} guesses";
                }
                else if (didWin && guessNumber != 0)
                {
                    Text = $"you won!\ncutting it close with {guessNumber} guesses...";
                }
                else
                {
                    { Text = "you lost...\n you could use some more practice"; }
                }
            }
        }
        public GameOverPageViewModel()
        {
        }

        [RelayCommand]
        void Help()
        {
            Shell.Current.DisplayAlert("how to play", "input letters to guess the hex color and press enter to see the result", "ok!");
        }


        [RelayCommand]
        void Restart()
        {
            Clean = true;
            Shell.Current.GoToAsync($"..?Clean={Clean}");
        }


    }
}