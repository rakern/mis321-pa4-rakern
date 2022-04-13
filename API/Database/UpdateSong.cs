using System;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;

namespace API.Database
{
    public class UpdateSong : IUpdateSongs
    {
        public static void Update(Song song) { // update existing song record in songs table
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET title = @title WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@id", song.SongID);

            //cmd.Prepare();

            cmd.ExecuteNonQuery();          

            con.Close();
        }
        void IUpdateSongs.Update(Song song) {
            throw new System.NotImplementedException();
        }
    }
}