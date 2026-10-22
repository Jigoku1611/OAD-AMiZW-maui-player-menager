using MauiApp3.Data;
using MauiApp3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp3.Commands
{
    /*************************************************************************
     * nazwa klasy:
     * DeletePlayerCommandHandler
     *
     * opis klasy:
     * Klasa pełni rolę handlera (procesora) odpowiedzialnego za obsługę
     * polecenia DeletePlayerCommand. Odpowiada za wykonanie właściwej logiki
     * biznesowej, czyli usunięcie wskazanego gracza z repozytorium danych.
     *
     * autor:
     * Miłosz Szczypior
     *************************************************************************/
    public class DeletePlayerCommandHandler
    {
        private readonly PlayerRepository _playerRepository;

        /*************************************************************************
        * nazwa funkcji:
        * DeletePlayerCommandHandler
        *
        * parametry wejściowe:
        * playerRepository, PlayerRepository, repozytorium przechowujące
        * listę graczy
        *
        * wartość zwracana:
        * brak
        *
        * opis funkcji:
        * Konstruktor inicjalizuje obiekt klasy DeletePlayerCommandHandler.
        * Przypisuje przekazane repozytorium graczy do pola
        * _playerRepository, które jest wykorzystywane podczas
        * usuwania gracza.
        *
        * autor:
        * Miłosz Szczypior
        *************************************************************************/
        public DeletePlayerCommandHandler(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        /*************************************************************************
         * nazwa funkcji:
         * Handle
         *
         * parametry wejściowe:
         * command, DeletePlayerCommand, polecenie zawierające Id gracza
         * przeznaczonego do usunięcia
         *
         * wartość zwracana:
         * brak
         *
         * opis funkcji:
         * Metoda obsługuje polecenie usunięcia gracza.
         * Wyszukuje gracza o Id podanym w poleceniu.
         * Jeżeli gracz zostanie znaleziony, usuwa go z listy graczy
         * przechowywanej w repozytorium.
         * Jeżeli gracz nie istnieje, metoda kończy działanie
         * bez wprowadzania zmian.
         *
         * autor:
         * Miłosz Szczypior
         *************************************************************************/
        public void Handle(DeletePlayerCommand command)
        {
            var player = _playerRepository.Players.FirstOrDefault(p => p.Id == command.Id);

            if (player != null) { _playerRepository.Players.Remove(player); }
        }
    }
}
