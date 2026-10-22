using System;
using System.Collections.Generic;
using System.Text;
using MauiApp3.Data;
using System.Linq;

namespace MauiApp3.Commands
{
    /*************************************************************************
     * nazwa klasy:
     * EditPlayerCommandHandler
     *
     * opis klasy:
     * Klasa pełni rolę handlera (procesora) odpowiedzialnego za obsługę
     * polecenia EditPlayerCommand. Odpowiada za wyszukanie gracza w repozytorium
     * i aktualizację jego danych, takich jak nazwa oraz poziom.
     *
     * autor:
     * Miłosz Szczypior
     *************************************************************************/
    public class EditPlayerCommandHandler
    {
        private readonly PlayerRepository _playerRepository;
        /*************************************************************************
        * nazwa funkcji:
        * EditPlayerCommandHandler
        *
        * parametry wejściowe:
        * playerRepository, PlayerRepository, repozytorium przechowujące
        * listę graczy
        *
        * wartość zwracana:
        * brak
        *
        * opis funkcji:
        * Konstruktor inicjalizuje obiekt klasy EditPlayerCommandHandler.
        * Przypisuje przekazane repozytorium graczy do pola
        * _playerRepository, które jest wykorzystywane podczas edycji
        * danych gracza.
        *
        * autor:
        * Miłosz Szczypior
        *************************************************************************/
        public EditPlayerCommandHandler(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        /*************************************************************************
        * nazwa funkcji:
        * Handle
        *
        * parametry wejściowe:
        * command, EditPlayerCommand, polecenie zawierające Id gracza,
        * jego nazwę oraz poziom
        *
        * wartość zwracana:
        * bool, wartość true, jeżeli gracz został znaleziony i jego dane
        * zostały zaktualizowane; w przeciwnym razie false
        *
        * opis funkcji:
        * Metoda obsługuje polecenie edycji danych gracza.
        * Wyszukuje gracza o Id podanym w poleceniu.
        * Jeżeli gracz nie zostanie znaleziony, zwraca false.
        * W przeciwnym razie aktualizuje jego nazwę oraz poziom,
        * a następnie zwraca true.
        *
        * autor:
        * Miłosz Szczypior
        *************************************************************************/
        public bool Handle(EditPlayerCommand command)
        {
            var player = _playerRepository.Players
                .FirstOrDefault(p => p.Id == command.Id);

            if (player == null)
                return false;

            player.Name = command.Name;
            player.Level = command.Level;

            return true;
        }
    }
}
