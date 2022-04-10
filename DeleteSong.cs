using PA3.Interfaces;
using MySql.Data.MySqlClient;
using PA3.Models;

namespace PA3.Database
{
    public class DeleteSong : IDeleteSongs
    {
        public static void DropSongTable() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS songs";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void Delete(int id) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM songs WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            //cmd.Prepare();

            cmd.ExecuteNonQuery();
            

            con.Close();
        }
        void IDeleteSongs.Delete(int id) {
            throw new System.NotImplementedException();
        }
    }
}