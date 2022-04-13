namespace API
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString() {
            string server = "ik1eybdutgxsm0lo.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "vxvhxjmn4kshg7xp";
            string port = "3306";
            string userName = "owfevgmwrp8me94h";
            string password = "bxwas8qr0k7ajwuv";

            cs = $@"server = {server};userName = {userName};database = {database};port = {port};password = {password};";
        }
    }
}