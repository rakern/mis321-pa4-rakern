using System;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;

namespace API.Database
{
    public class FavoriteSong
    {
        public void Favorite(int id) { // update existing song record in songs table
            string stm;
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();
            
            if (ReadSong.GetOne(id).Favorited == "n") {
                stm = @"UPDATE songs SET favorited = 'y' WHERE id = @id";
            }
            else { // favorited is "y", so unfavorite it
                stm = @"UPDATE songs SET favorited = 'n' WHERE id = @id";
            }

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            //cmd.Prepare();

            cmd.ExecuteNonQuery();          

            con.Close();
        }
    }
}