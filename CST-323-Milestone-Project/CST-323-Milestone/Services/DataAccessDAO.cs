using CST_323_Milestone.Models;
using MySqlConnector;
using System.Data.SqlClient;

namespace CST_323_Milestone.Services
{
    public class DataAccessDAO
    {
        string connectionString = "Server=localhost;Database=cst323;Uid=root;Pwd=root";

        /// <summary>
        /// Read all superheroes from the database
        /// </summary>
        /// <returns></returns>
        public List<SuperheroModel> Read()
        {
            // List to hold entries in
            List<SuperheroModel> foundSuperheroes = new List<SuperheroModel>();

            // Select statement
            string sqlStatement = "SELECT * FROM Superheroes";

            // Creating a connection to the database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundSuperheroes.Add(new SuperheroModel((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (float)reader[4], (string)reader[5], (float)reader[6], (int)reader[7]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundSuperheroes;
        }

        /// <summary>
        /// Create a new superhero in the database
        /// </summary>
        /// <param name="superhero"></param>
        /// <returns></returns>
        public bool Create(SuperheroModel superhero)
        {
            // Insert statment
            string sqlStatment = "INSERT INTO Superheroes (alias, name, powers, powerRating, alignment, price, qty) VALUES (@alias, @name, @powers, @powerRating, @alignment, @price, @qty)";

            // Creating a connection to the database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Making a command and adding the properties to the parameters
                MySqlCommand command = new MySqlCommand(sqlStatment, connection);

                command.Parameters.AddWithValue("@alias", superhero.Alias);
                command.Parameters.AddWithValue("@name", superhero.Name);
                command.Parameters.AddWithValue("@powers", superhero.Powers);
                command.Parameters.AddWithValue("@powerRating", superhero.PowerRating);
                command.Parameters.AddWithValue("@alignment", superhero.Alignment);
                command.Parameters.AddWithValue("@price", superhero.Price);
                command.Parameters.AddWithValue("@qty", superhero.Qty);

                try
                {
                    connection.Open(); // Opening the connection
                    var result = command.ExecuteNonQuery(); // Trying the insert

                    return result > 0; // Success!
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString()); ;
                }

                return false; // Failure!
            }
        }

        /// <summary>
        /// Update a superhero from the database
        /// </summary>
        /// <param name="superhero"></param>
        /// <returns></returns>
        public int Update(SuperheroModel superhero)
        {
            int newIdNumber = 9;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sqlStatement = "UPDATE Superheroes SET Alias = @Alias, Name = @Name, Powers = @Powers, PowerRating = @PowerRating, Alignment = @Alignment, Price = @Price, Qty = @Qty WHERE Superhero_ID = @Id";
                
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", superhero.SuperheroID);
                command.Parameters.AddWithValue("@Alias", superhero.Alias);
                command.Parameters.AddWithValue("@Name", superhero.Name);
                command.Parameters.AddWithValue("@Powers", superhero.Powers);
                command.Parameters.AddWithValue("@PowerRating", superhero.PowerRating);
                command.Parameters.AddWithValue("@Alignment", superhero.Alignment);
                command.Parameters.AddWithValue("@Price", superhero.Price);
                command.Parameters.AddWithValue("@Qty", superhero.Qty);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
                return newIdNumber;
            }
        }

        /// <summary>
        /// Delete a superhero from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            // Delete statment
            string sqlStatment = "DELETE FROM superheroes WHERE superhero_id = @id";

            // Creating a connection to the database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Making a command and adding the properties to the parameters
                MySqlCommand command = new MySqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open(); // Opening the connection
                    var result = command.ExecuteNonQuery(); // Trying the delete

                    return result > 0; // Success!
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString()); // Failure!
                }

                return false;
            }
        }
    }
}