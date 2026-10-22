
using MauiApp3.Commands;
using MauiApp3.Model;
using MauiApp3.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace MauiApp3.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly GetPlayerByIdQueryHandler _getPlayerByIdQueryHandler;
        private readonly GetPlayersQueryHandler _getPlayersQueryHandler;
        private readonly AddPlayerCommandHandler _addPlayerCommandHandler;
        private readonly DeletePlayerCommandHandler _deletePlayerCommandHandler;
        private readonly EditPlayerCommandHandler _editPlayerCommandHandler;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Player> Players { get; } = new();
        public string PlayerName { get; set; } = "";
        public string PlayerLevel { get; set; } = "";
        public string PlayerId { get; set; } = "";
        public string EditPlayerId { get; set; } = "";
        public string EditPlayerName { get; set; } = "";
        public string EditPlayerLevel { get; set; } = "";
        private string _searchResult = "";

        public string SearchResult
        {
            get
            {
                return _searchResult;
            }

            set
            {
                _searchResult = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddPlayerCommandButton { get; }
        public ICommand FindPlayerCommandButton { get; }
        public ICommand DeletePlayerCommandButton { get; }
        public ICommand EditPlayerCommandButton { get; }
        public MainViewModel(
            GetPlayerByIdQueryHandler getPlayerByIdQueryHandler,
            GetPlayersQueryHandler getPlayersQueryHandler,
            AddPlayerCommandHandler addPlayerCommandHandler,
            DeletePlayerCommandHandler deletePlayerCommandHandler,
            EditPlayerCommandHandler editPlayerCommandHandler)
        {
            _getPlayerByIdQueryHandler = getPlayerByIdQueryHandler;
            _getPlayersQueryHandler = getPlayersQueryHandler;
            _addPlayerCommandHandler = addPlayerCommandHandler;
            _deletePlayerCommandHandler = deletePlayerCommandHandler;
            _editPlayerCommandHandler = editPlayerCommandHandler;

            AddPlayerCommandButton = new Command(AddPlayer);
            FindPlayerCommandButton = new Command(FindPlayer);
            DeletePlayerCommandButton = new Command(DeletePlayer);
            EditPlayerCommandButton = new Command(EditPlayer);

            LoadPlayers();
        }
        private void AddPlayer()
        {
            if (!int.TryParse(PlayerLevel, out int playerLevel))
            {
                return;
            }
            AddPlayerCommand command = new AddPlayerCommand(PlayerName, playerLevel);
            _addPlayerCommandHandler.Handle(command);

            LoadPlayers();
        }
        private void FindPlayer()
        {
            if (!int.TryParse(PlayerId, out int playerId))
            {
                SearchResult = "Niepoprawne ID";
                return;
            }

            GetPlayerByIdQuery query =
                new GetPlayerByIdQuery(playerId);

            Player? player =
                _getPlayerByIdQueryHandler.Handle(query);

            if (player == null)
            {
                SearchResult = "Nie znaleziono gracza";
                return;
            }

            SearchResult =
                $"{player.Name} - poziom {player.Level}";
        }

        private void LoadPlayers()
        {
            GetPlayersQuery query = new GetPlayersQuery();
            List<Player> players = _getPlayersQueryHandler.Handle(query);

            Players.Clear();

            foreach (Player player in players)
            {
                Players.Add(player);
            }
        }
        
        /*************************************************************************
        * nazwa funkcji:
        * DeletePlayer
        *
        * parametry wejściowe:
        * brak
        *
        * wartość zwracana:
        * brak
        *
        * opis funkcji:
        * Metoda obsługuje usunięcie gracza.
        * Odczytuje i weryfikuje Id gracza podane w polu PlayerId.
        * Jeżeli Id jest nieprawidłowe, kończy działanie metody.
        * W przeciwnym razie tworzy polecenie DeletePlayerCommand,
        * przekazuje je do odpowiedniego handlera, a następnie
        * odświeża listę graczy.
        *
        * autor:
        * Miłosz Szczypior
        *************************************************************************/
        private void DeletePlayer()
        {
            if (!int.TryParse(PlayerId, out int playerId))
            {
                return;
            }
            DeletePlayerCommand command = new DeletePlayerCommand(playerId);
            _deletePlayerCommandHandler.Handle(command);
            LoadPlayers();
        }


        /*************************************************************************
        * nazwa funkcji:
        * EditPlayer
        *
        * parametry wejściowe:
        * brak
        *
        * wartość zwracana:
        * brak
        *
        * opis funkcji:
        * Metoda obsługuje edycję danych gracza.
        * Weryfikuje poprawność Id gracza, jego nazwy oraz poziomu.
        * W przypadku nieprawidłowych danych ustawia odpowiedni
        * komunikat w polu SearchResult i kończy działanie metody.
        * Następnie tworzy polecenie EditPlayerCommand i przekazuje
        * je do odpowiedniego handlera.
        * Jeżeli gracz o podanym Id nie zostanie znaleziony,
        * wyświetla odpowiedni komunikat.
        * W przypadku pomyślnej edycji odświeża listę graczy
        * i wyświetla komunikat o aktualizacji danych.
        *
        * autor:
        * Miłosz Szczypior
        *************************************************************************/
        private void EditPlayer()
        {
            if (!int.TryParse(EditPlayerId, out int playerId))
            {
                SearchResult = "Podaj poprawne ID gracza.";
                return;
            }

            if (string.IsNullOrWhiteSpace(EditPlayerName))
            {
                SearchResult = "Podaj nazwę gracza.";
                return;
            }

            if (!int.TryParse(EditPlayerLevel, out int playerLevel))
            {
                SearchResult = "Podaj poprawny poziom.";
                return;
            }

            var command = new EditPlayerCommand(
                playerId,
                EditPlayerName.Trim(),
                playerLevel
            );

            bool edited = _editPlayerCommandHandler.Handle(command);

            if (!edited)
            {
                SearchResult = $"Nie znaleziono gracza o ID {playerId}.";
                return;
            }


            LoadPlayers();
            SearchResult = "Gracz został zaktualizowany.";
        }



        protected void OnPropertyChanged(
            [CallerMemberName] string?  propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
