using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp3.Commands
{
    /*************************************************************************
     * nazwa klasy:
     * DeletePlayerCommand
     *
     * opis klasy:
     * Klasa reprezentuje polecenie (Command) odpowiedzialne za przenoszenie
     * danych niezbędnych do operacji usunięcia gracza z systemu. Działa jako
     * struktura typu immutable (niezmienna).
     *
     * autor:
     * Miłosz Szczypior
     *************************************************************************/
    public class DeletePlayerCommand
    {
        public int Id { get; }

        /*************************************************************************
         * nazwa funkcji:
         * DeletePlayerCommand
         *
         * parametry wejściowe:
         * id, int, identyfikator gracza przeznaczonego do usunięcia
         *
         * wartość zwracana:
         * brak
         *
         * opis funkcji:
         * Konstruktor inicjalizuje obiekt klasy DeletePlayerCommand.
         * Przypisuje przekazany identyfikator gracza do właściwości Id,
         * która określa gracza przeznaczonego do usunięcia.
         *
         * autor:
         * Miłosz Szczypior
         *************************************************************************/
        public DeletePlayerCommand(int id)
        {
            Id = id;
        }
    }
}
