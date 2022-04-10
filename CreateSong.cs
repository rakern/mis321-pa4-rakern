using System.Runtime.InteropServices;
using PA3.Interfaces;
using MySql.Data.MySqlClient;
using PA3.Models;

namespace PA3.Database
{
    public class CreateSong : ICreateSongs
    {
        public static void CreateSongTable() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, time DATETIME, deleted TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public static void Create(Song song) { // insert song object into songs table
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(title, time, deleted) VALUES(@title, @time, @deleted)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@time", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);

           // cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }
        void ICreateSongs.Create(Song song) {
            throw new System.NotImplementedException();
        }
    }
}