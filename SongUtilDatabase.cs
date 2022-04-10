using System;
using System.IO;
using System.Collections.Generic;
using PA3.Models;
using PA3.FileHandleing;
using PA3.Interfaces;
using PA3.Database;

namespace PA3.Utilities
{
    public class SongUtilDatabase : ISongUtilities
    {
        public List<Song> playlist { get; set; }
         public void PrintPlaylist() { // display all items in the playlist to the console
            playlist = ReadSong.GetAll(); // set playlist to list of records from songs table

            Console.Clear();
            foreach (Song song in playlist) { // for every song in the playlist, write the song's ToString to the console
                if(song.Deleted != "y"){
                    Console.WriteLine(song.ToString());
                }
            }
            Console.WriteLine();
        }

        public void AddSong() { // allow the user to add a new song to the songs table
            Song mySong = new Song(){SongTitle = PromptSongDetails(), SongTimestamp = DateTime.Now, Deleted = "n"};
            CreateSong.Create(mySong);            
        }

        public string PromptSongDetails() { // Ask user for title of the song to add
            Console.Clear();
            Console.WriteLine("What is the title of your song?");
            return Console.ReadLine();
        }

        public void DeleteSong() { // remove a song from the playlist given the SongID
            int index;
            int IDToDelete;
            playlist = ReadSong.GetAll();
            
            do {
                // find index
                IDToDelete = PromptSongToDelete(playlist);
            
                index = playlist.FindIndex(currentSong => currentSong.SongID == IDToDelete); // iterate through songs in playlist and compare their IDs to the ID the user wants to delete 

            } while (!CheckValidIndex(index)); // make sure the song ID exists - if playlist.FindIndex returns -1, the ID was not found in the list


            // remove song because we know id exists
            Database.DeleteSong.Delete(IDToDelete);
            Console.Clear();
            Console.WriteLine("The record has been deleted.\n");
            
        }

        public int PromptSongToDelete(List<Song> playlist) { // ask the user the ID of the song they want to delete
            
            string userInput;
            
            do {

                Console.Clear();
                PrintPlaylist();
                Console.WriteLine("What is the ID of the song you want to delete?");
                userInput = Console.ReadLine();

            } while (!CheckValidInput(userInput)); // ID entered must be an integer
            
            return int.Parse(userInput);
        }

        public bool CheckValidIndex(int index) {
            if (index == -1) { // if playlist.FindAt returns -1, the ID was not found in the list
                Console.WriteLine("\nID does not exist in the current playlist. Press any key to continue");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool CheckValidInput(string userInput) { // check to see if user's input is an integer
            int parsedInput;

            if (!int.TryParse(userInput, out parsedInput)) {
                Console.WriteLine("Invalid input. Try again.");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        public int PromptSongToUpdate() { // ask the user the ID of the song they want to delete
            
            string userInput;
            
            do {

                Console.Clear();
                PrintPlaylist();
                Console.WriteLine("What is the ID of the song you want to update?");
                userInput = Console.ReadLine();

            } while (!CheckValidInput(userInput)); // ID entered must be an integer
            
            return int.Parse(userInput);
        }

        public void EditSong()
        {
            int index;
            int idToEdit;
            playlist = ReadSong.GetAll();
            
            do {
                // find index
                idToEdit = PromptSongToUpdate();
            
                index = playlist.FindIndex(currentSong => currentSong.SongID == idToEdit); // iterate through songs in playlist and compare their IDs to the ID the user wants to delete 

            } while (!CheckValidIndex(index)); // make sure the song ID exists - if playlist.FindIndex returns -1, the ID was not found in the list

            Console.Clear();
            Console.WriteLine(ReadSong.GetOne(idToEdit).ToString());
            Console.WriteLine("\nWhat is the updated title of this song?");
            string newTitle = Console.ReadLine();
            
            Song updatedSong = new Song(){SongID = idToEdit, SongTitle = newTitle}; // only need to set id and title because you aren't editing anything besides title
            UpdateSong.Update(updatedSong);

            Console.Clear();
            Console.WriteLine("The record has been updated:\n");            
            Console.WriteLine(ReadSong.GetOne(idToEdit).ToString()); // displays updated record in console

        }
    }
}