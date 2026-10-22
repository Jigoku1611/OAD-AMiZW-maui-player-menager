using System;
using System.Collections.Generic;
using System.Text;


namespace MauiApp3.Commands
{
    /*************************************************************************
     * nazwa klasy:
     * EditPlayerCommand
     *
     * opis klasy:
     * Klasa reprezentuje polecenie (Command) służące do przenoszenia nowych
     * danych (identyfikatora, nazwy oraz poziomu) wymaganych do zmodyfikowania
     * istniejącego profilu gracza w aplikacji.
     *
     * autor:
     * Miłosz Szczypior
     *************************************************************************/
    public class EditPlayerCommand
    {
        public int Id { get; }
        public string Name { get; }
        public int Level { get; }

        /*************************************************************************
        * nazwa funkcji:
        * EditPlayerCommand
        *
        * parametry wejściowe:
        * id, int, identyfikator edytowanego gracza
        * name, string, nowa nazwa gracza
        * level, int, nowy poziom gracza
        *
        * wartość zwracana:
        * brak
        *
        * opis funkcji:
        * Konstruktor inicjalizuje obiekt klasy EditPlayerCommand.
        * Przypisuje przekazane wartości do właściwości Id, Name oraz
        * Level, które zawierają dane niezbędne do aktualizacji gracza.
        *
        * autor:
        * Miłosz Szczypior
        *************************************************************************/
        public EditPlayerCommand(int id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
        }
    }
}
