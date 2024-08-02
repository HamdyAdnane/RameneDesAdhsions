using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using RamenerDesAdhésions;

class Program
{
    public static void Main()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        string query = @"
             SELECT * FROM DIM_ADHESION_15072024
             WHERE NOM IS NOT NULL AND PRENOM IS NOT NULL AND DATE_NAISSANCE IS NOT NULL;"
        ;
        using (SqlConnection connection = new SqlConnection(configuration.GetSection("ConnectionString").Value))
        {
            connection.Open();
            SqlCommand commande = new SqlCommand(query, connection);
            SqlDataReader lecteur = commande.ExecuteReader();
            DIM_ADHESION_15072024 Dim_Adhesion;
            while (lecteur.Read())
            {
                Dim_Adhesion = new DIM_ADHESION_15072024
                {
                    Nom = lecteur.GetString("NOM"),
                    Prenom = lecteur.GetString("PRENOM"),
                    DateNaissance = lecteur.GetString("DATE_NAISSANCE")
                };
                Console.WriteLine(Dim_Adhesion);
            }
            lecteur.Close();
        }
    }
}