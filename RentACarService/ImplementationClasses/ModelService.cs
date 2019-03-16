using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.Models;


namespace RentACarService
{
   public class ModelService : IModelService
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader reader;
        List<CarModel> models;
        CarModel model;
        private static readonly log4net.ILog Logger = new log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddNewModel(CarModel model)
        {
            using (sqlConnection = new SqlConnection(Helper.CONNECTION_STRING))
            {
                try
                {
                    sqlCommand = new SqlCommand() { Connection = sqlConnection, CommandType = CommandType.Text };
                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Model WHERE Id_Manufacturer = @Id";
                    sqlCommand.Parameters.AddWithValue("@Id", model.ManufacturerId);
                    reader = sqlCommand.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        sqlCommand.CommandText = "Insert into Model(Name, Year, Id_Manufacturer) values(@Name, @Year, @Id_Manufacturer)";
                        sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                        sqlCommand.Parameters.AddWithValue("@Year", model.Year);
                        sqlCommand.Parameters.AddWithValue("@Id_Manufacturer", model.ManufacturerId);
                        reader.Close();
                        sqlCommand.ExecuteReader();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CarModel> GetModels(int manufacturerId)
        {
            models = new List<CarModel>();
            model = new CarModel();
            using (sqlConnection = new SqlConnection(Helper.CONNECTION_STRING))
            {
                try
                {
                    sqlCommand = new SqlCommand() { Connection = sqlConnection, CommandType = CommandType.Text };
                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Model WHERE Id_Manufacturer = @Id";
                    sqlCommand.Parameters.AddWithValue("@Id", manufacturerId);
                    reader = sqlCommand.ExecuteReader();
                    if (reader.RecordsAffected > 0 && !reader.HasRows)
                    {
                        model.Id = (int)reader["id"];
                        model.Name = (string)reader["Name"];
                        model.Year = (int)reader["Year"];
                        model.ManufacturerId = (int)reader["Id_Manufacturer"];
                        Lo
                        models.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            return models;
        }
    }
}
