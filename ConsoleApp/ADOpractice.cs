using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

public static class ADOpractice{

    static string connectionString = "Server=localhost;Database=master;Uid=sa;Pwd=reallyStrongPwd123;";

    public static void CheckConnection(){
        using (SqlConnection connection = new SqlConnection(connectionString)){
            connection.Open();

            Console.WriteLine("Connection is successful");

            connection.Close();
        }
    }

    //Getting all the data from the table 
    public static void GetData(){
        Console.WriteLine("Feting all the Books");
        Console.WriteLine("--------------------------------");

        using (SqlConnection connection = new SqlConnection(connectionString)){
            
            using (SqlCommand command = connection.CreateCommand()){

                command.CommandText = "SELECT * FROM BOOKS";

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()){
                    if (reader.HasRows){
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetInt32(reader.GetOrdinal("BookID"))}. "  +
                            $"{reader.GetString(reader.GetOrdinal("BookName"))}  "  +
                            $"{reader.GetString(reader.GetOrdinal("AuthorName"))}   "  +
                            $"{reader.GetDateTime(reader.GetOrdinal("PublishedDate"))}");
                            
                        }
                    }
                }
                connection.Close();
            }
        }
    }


    
    public static void InsertNewBook(){
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("Adding new book...");
    Console.WriteLine("--------------------------------");

    using (SqlConnection connection = new SqlConnection(connectionString)){

        using (SqlCommand command = connection.CreateCommand()){
            command.CommandText = "INSERT INTO BOOKS(BookID,BookName,AuthorName,PublishedDate)" +
            // "SELECT 7,'Let us dream','Pope Francis','2020-03-03' " + 
            // "UNION" +
            // "SELECT 8,'My Life in Design','Gauri Khan','2023-01-01' ";
            "VALUES(8, 'Let us dream','Pope Francis','2020-03-03') ";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
        
    }

        public static void AfterAddingData(){
        Console.WriteLine("After Adding New Book");
        Console.WriteLine("--------------------------------");

        using (SqlConnection connection = new SqlConnection(connectionString)){
            
            using (SqlCommand command = connection.CreateCommand()){

                command.CommandText = "SELECT * FROM BOOKS";

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()){
                    if (reader.HasRows){
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetInt32(reader.GetOrdinal("BookID"))}. "  +
                            $"{reader.GetString(reader.GetOrdinal("BookName"))}  "  +
                            $"{reader.GetString(reader.GetOrdinal("AuthorName"))}   "  +
                            $"{reader.GetDateTime(reader.GetOrdinal("PublishedDate"))}");
                            
                        }
                    }
                }
                connection.Close();
            }
        }
        
    }

    public static void UpdateBook(){
        Console.WriteLine("Updating book....");
        Console.WriteLine("--------------------------------");

        using (SqlConnection connection = new SqlConnection(connectionString)){
            
            using(SqlCommand command = connection.CreateCommand()){

                command.CommandText = "UPDATE BOOKS SET AuthorName = 'Saugat Neupane' WHERE BookID = 1 ";

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("The book with ID 1 was upadte succefully... ");
                connection.Close();

            }
        }
    }

    public static void DeleteBook(){
        Console.WriteLine("Deleting book...");
        Console.WriteLine("--------------------------------");

        using (SqlConnection connection = new SqlConnection(connectionString)){

            using(SqlCommand command = connection.CreateCommand()){

                command.CommandText = "DELETE FROM BOOKS WHERE BookID = 2";

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("The book with ID 2 was deleted successfully");
                connection.Close();
            }
        }
            
    }

    public static void AddnewBooksData(){

        Console.WriteLine("Enter Book ID:");
        string BookID = Console.ReadLine(); 

        Console.WriteLine("Enter Book Name:");
        string BookName = Console.ReadLine(); 

        Console.WriteLine("Enter Author Nmae:");
        string AuthorName = Console.ReadLine(); 

        Console.WriteLine("Enter publication date:");
        string PublishedDate = Console.ReadLine(); 

        using (SqlConnection connection = new SqlConnection(connectionString)){
            using (SqlCommand command = connection.CreateCommand()){

                command.CommandText = "INSERT INTO BOOKS (BookID, BookName, AuthorName,PublishedDate)" +
                "VALUES (@bookid,@bookname,@authorname,@publisheddate)";

                command.Parameters.AddWithValue("@bookid",BookID);
                command.Parameters.AddWithValue("@bookname",BookName);
                command.Parameters.AddWithValue("@authorname",AuthorName);
                command.Parameters.AddWithValue("@publisheddate",PublishedDate);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("New book added successfully by the user");
                Console.WriteLine("----------------------------------------------------");

            }
        }
    }

}


