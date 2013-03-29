using System.Data;
using System.Data.SQLite;
using System.Threading;

namespace MyProduct.Tests
{
    public class MySimpleClass
    {
        private SQLiteConnection connection;

        public MySimpleClass()
        {
            //CreateDB(); //only use this line to initialize a new project with no DB file.
            InitConnection();


            UglyHackToOpenConnectionOnlyOnce();


            //CreateTable(); // only do this once if there is no DB
        }

        private void UglyHackToOpenConnectionOnlyOnce()
        {

            // ugly Hack for demo purposes. SQLite cannot handle multiple connection close/open in same transactionscope.
            // see http://sqlite.phxsoftware.com/forums/p/2200/8903.aspx
            connection.Open();
        }

        private void InitConnection()
        {

            connection = new SQLiteConnection("Data Source=..\\..\\demo.db;Version=3;");
        }

        private static void CreateDB()
        {


            SQLiteConnection.CreateFile("demo.db");
            Thread.Sleep(1000);

        }

        private void CreateTable()
        {
            Execute("Create table Categories (CategoryName varchar(50), CategoryID INTEGER PRIMARY KEY)");
        }

        private long Execute(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            long result = connection.LastInsertRowId;
            
            return result;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
        public long InsertCategoryStandard(string name)
        {
            string SQL = string.Format(
            @"Insert into Categories (CategoryName) Values ('{0}') "
            , name);

           return Execute(SQL);
        }

       
    }


}
