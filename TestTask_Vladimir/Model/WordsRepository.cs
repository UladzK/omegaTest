using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace TestTask_Vladimir.Model
{
    public class WordsRepository
    {
        private SQLiteConnection sqlConnection;
        private SQLiteCommand sqlCommand;
        private SQLiteDataAdapter db;
        private readonly string connectionString = @"data source=D:\TestTask\TestTask_Vladimir\DB\WordsLang;Version=3";
        private static WordsRepository instance;

        private WordsRepository() { }

        public static WordsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WordsRepository();    
                }
                return instance;
            }
        }
        private void SetConnection()
        {
            try
            {
                sqlConnection = new SQLiteConnection(connectionString);
            }
            catch (InvalidOperationException ex)
            {
                //todo: log exception    
                //connection failed
            }
        }

        private void ExecuteNonQuery(string query)
        {
            SetConnection();
            sqlConnection.Open();
            
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = query;
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private List<Word> ExecuteSelectQuery(string query)
        {
            List<Word> cachedWords = new List<Word>();

            SetConnection();
            sqlConnection.Open();

            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = query;

            SQLiteDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                cachedWords.Add(new Word()
                {
                    ID = Int32.Parse(reader["ID"].ToString()),
                    Title = (string) reader["Title"],
                    Lang = (string) reader["Lang"],
                    Confidence = (string) reader["Confidence"]
                });

            }

            sqlConnection.Close();

            return cachedWords;
        }

        public void AddWord(string title, string lang, string confidence)
        {
            string addQuery = "INSERT INTO Word(Title, Lang, Confidence) VALUES ('" +
                              title + "','" + lang + "','" + confidence + "');";

            ExecuteNonQuery(addQuery);
        }
        
        public Word GetWord(string word)
        {
            string selectQuery = "SELECT * FROM Word WHERE Title = '" + word + "';";

            return ExecuteSelectQuery(selectQuery).FirstOrDefault();
        }
    }
}