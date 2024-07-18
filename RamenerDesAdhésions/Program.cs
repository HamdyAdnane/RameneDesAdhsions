using System;
using System.Data;
using System.Data.SqlClient;
class Program
{
    public static void Main()
    { 
        string connectionString = "Data Source=HAMDY-ADNANE\\SQLEXPRESS;Initial Catalog=DatabaseAyoub;Integrated Security=True";
        string query = @"
             SELECT * FROM DIM_ADHESION_15072024
             WHERE NOM IS NOT NULL AND PRENOM IS NOT NULL AND DATE_NAISSANCE IS NOT NULL;"
        ;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader lecteur = command.ExecuteReader();
            while (lecteur.Read())
            {
                Console.WriteLine($"Nom: {lecteur["NOM"]}, Prénom: {lecteur["PRENOM"]}, Date de Naissance: {lecteur["DATE_NAISSANCE"]}");
            }
            lecteur.Close();
        }
    }
}