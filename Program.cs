using System;
using System.Collections.Generic;
using API.FileHandling;
using API.Models;
using API.Utilities;
using API.Database;

namespace PA4
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            bool keepGoing;
            // ReadFromFile readFromFile = new ReadFromFile();
            // List<Song> playlist = readFromFile.GetAll();
            // //Menu programMenu = new Menu(){SongUtilities = new SongUtil(), Playlist = playlist};
            // Menu programMenu = new Menu(){SongUtilities = new SongUtilDatabase(), Playlist = playlist};

             DeleteSong.DropSongTable();
             UpdateSong.CreateSongTable();

            // do {
            //     userChoice = programMenu.DisplayMainMenu(); 
            //     keepGoing = programMenu.RouteMainMenu(userChoice);
                
            // } while (keepGoing);

        }
    }
}
