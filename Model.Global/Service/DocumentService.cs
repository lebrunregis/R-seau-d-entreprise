using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    public static class DocumentService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Document doc)
        {
            int? Document_Id = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetFileName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", doc.Name);
                command.Parameters.AddWithValue("@Employee_Id", doc.AuthorEmployee);


                SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = tran;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string path;
                    byte[] transactionContext;
                    while (reader.Read())
                    {
                        // Get the pointer for file   
                        path = (string)reader["filepath"];
                        Document_Id = (int)reader["Document_Id"];
                        transactionContext = (byte[])reader["context"];

                        // Create the SqlFileStream  
                        using (SqlFileStream fileStream = new SqlFileStream(path, transactionContext, FileAccess.Write))
                        {
                            // Write a single byte to the file. This will  
                            // replace any data in the file.  
                            fileStream.Write(doc.Body, 0, doc.Body.Length);
                        }
                    }
                }
                tran.Commit();
            }
            return Document_Id;
        }

        public static Document Get(int Id)
        {
            Command cmd = new Command("DownloadFile", true);
            cmd.AddParameter("DocumentId", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocument()).FirstOrDefault();
        }
    }
}
