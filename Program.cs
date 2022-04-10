﻿using System;
using System.Collections.Generic;
using PA3.FileHandleing;
using PA3.Models;
using PA3.Utilities;

using PA3.Database;

namespace PA3
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            bool keepGoing;
            ReadFromFile readFromFile = new ReadFromFile();
            List<Song> playlist = readFromFile.GetAll();
            //Menu programMenu = new Menu(){SongUtilities = new SongUtil(), Playlist = playlist};
            Menu programMenu = new Menu(){SongUtilities = new SongUtilDatabase(), Playlist = playlist};

            // DeleteSong.DropSongTable();
            // UpdateSong.CreateSongTable();

            do {
                userChoice = programMenu.DisplayMainMenu(); 
                keepGoing = programMenu.RouteMainMenu(userChoice);
                
            } while (keepGoing);

        }
    }
}
