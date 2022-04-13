using System;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;

namespace API.Database
{
    public class CreateSong : ICreateSongs
    {
        public static void CreateSongTable() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, time DATETIME, deleted TEXT, favorited TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public static void Create(Song song) { // insert song object into songs table
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(title, time, deleted, favorited) VALUES(@title, @time, @deleted, @favorited)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@time", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@favorited", song.Favorited);

           // cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }
        void ICreateSongs.Create(Song song) {
            throw new System.NotImplementedException();
        }
    }
}