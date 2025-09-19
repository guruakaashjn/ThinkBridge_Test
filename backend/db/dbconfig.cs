namespace SQLiteConfigs
{
    class Data
    {
        private SQLiteConnection sqliteLink;

        public DataClass()
        {
            sqliteLink = new SQLiteConnection("Data Source=/backend/db/init.sql");
        } 
    }
}