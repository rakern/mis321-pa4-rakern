using System.Security.Cryptography;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using API.Models;
using System.Collections.Generic;
using System;
using API.Models.Interfaces;

namespace API.Database
{
    public class ReadSong //: IReadSongs
    {
        public static List<Song> GetAll() { // returns all songs in songs table as a string of song objects
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            List<Song> existingSongs = new List<Song>();

            con.Open();

            string stm  = "SELECT * FROM songs ORDER BY time DESC"; // display in descending timestamp order

            using var cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) {
                Song newSong = new Song(){SongID = rdr.GetInt32("id"), SongTitle = rdr.GetString("title"), SongTimestamp = DateTime.Parse(rdr.GetString("time")), Deleted = rdr.GetString("deleted"), Favorited = rdr.GetString("favorited")};
                existingSongs.Add(newSong);
            }
            con.Close();

            return existingSongs;
        }
        public static Song GetOne(int id) { // return one song object given song id
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            Song foundSong = new Song();
            string stm  = @"SELECT * FROM songs WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
                foundSong = new Song(){SongID = rdr.GetInt32("id"), SongTitle = rdr.GetString("title"), SongTimestamp = rdr.GetDateTime("time") /* DateTime.Parse(rdr.GetString("time")) */, Deleted = rdr.GetString("deleted"), Favorited = rdr.GetString("favorited")};
            }
            con.Close();

            return foundSong;
        }

        
    }
}