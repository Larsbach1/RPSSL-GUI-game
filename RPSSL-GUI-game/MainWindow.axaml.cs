// Gør GUI-klasser synlige
using Avalonia.Controls;
// Til RoutedEventArgs
using Avalonia.Interactivity;
// Til Random og Enum
using System;

namespace RPSSL_GUI_game
{
    // partial fordi XAML-genereringen leverer resten
    public partial class MainWindow : Window
    {
        // Enum med de 5 mulige valg
        private enum Choice { Rock, Paper, Scissors, Lizard, Spock }

        // Random generator
        private readonly Random _rnd = new();

        // UI felter
        private TextBlock _computerValg;
        private TextBlock _resultat;
        private TextBlock _status;
        private TextBlock _point;
        private TextBlock _emoji;

        // Score felter
        private int _playerScore = 0;
        private int _computerScore = 0;
        private int _ties = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Find kontroller fra XAML
            _computerValg = this.FindControl<TextBlock>("ComputerValg");
            _resultat = this.FindControl<TextBlock>("Resultat");
            _status = this.FindControl<TextBlock>("Status");
            _point = this.FindControl<TextBlock>("Point");
            _emoji = this.FindControl<TextBlock>("Emoji");

            // Velkomst
            _status.Text = "Klik på en knap for at spille en runde.";
        }

        // Eventhandler for alle knapper
        private void OnChoiceClick(object? sender, RoutedEventArgs e)
        {
            if (sender is not Button btn || btn.Content is null)
            {
                _status.Text = "Kunne ikke aflæse knappen.";
                return;
            }

            // Fjern emoji så Enum.Parse virker
            string buttonText = btn.Content.ToString().Split(' ')[^1]; // tager sidste ord
            if (!Enum.TryParse(buttonText, ignoreCase: true, out Choice player))
            {
                _status.Text = "Ukendt valg – prøv igen.";
                return;
            }

            // Computer vælger tilfældigt
            Choice computer = (Choice)_rnd.Next(0, 5);
            _computerValg.Text = $"Computer valgte: {computer}";

            // Afgør resultat
            string result = DetermineWinner(player, computer);
            _resultat.Text = result;

            // Opdater scoreboard + emoji
            if (result == "Tillykke!")
            {
                _playerScore++;
                _emoji.Text = "😀";
            }
            else if (result == "Desværre!")
            {
                _computerScore++;
                _emoji.Text = "😢";
            }
            else
            {
                _ties++;
                _emoji.Text = "😐";
            }

            _point.Text = $"Score: Spiller {_playerScore} – Computer {_computerScore} – Uafgjort {_ties}";
            _status.Text = $"Du valgte {player}. Tryk igen for ny runde.";
        }

        // Afgørelseslogik
        private string DetermineWinner(Choice player, Choice computer)
        {
            if (player == computer) return "Uafgjort!";

            switch (player)
            {
                case Choice.Rock:
                    if (computer == Choice.Scissors || computer == Choice.Lizard) return "Tillykke!";
                    break;
                case Choice.Paper:
                    if (computer == Choice.Rock || computer == Choice.Spock) return "Tillykke!";
                    break;
                case Choice.Scissors:
                    if (computer == Choice.Paper || computer == Choice.Lizard) return "Tillykke!";
                    break;
                case Choice.Lizard:
                    if (computer == Choice.Spock || computer == Choice.Paper) return "Tillykke!";
                    break;
                case Choice.Spock:
                    if (computer == Choice.Scissors || computer == Choice.Rock) return "Tillykke!";
                    break;
            }
            return "Du tabte!";
        }
    }
}
