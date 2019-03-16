using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.Models;

namespace RentACarService
{
   public class VehicleService : IVehicleService
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader reader;
        private static readonly log4net.ILog Logger = new log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddNewCar(Car car)
        {
            using (sqlConnection = new SqlConnection(Helper.CONNECTION_STRING))
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "Insert into Car(Type, Available, Image, TotalRentals, Id_Model, CubicCapacity, Fuel," +
                    "FuelConsuption, Power, Kilometers) values(@Type, @Available, @Image, @TotalRentals, @Id_Model, @CubicCapacity, @Fuel, @FuelConsuption, @Power, @Kilometers, @Town)";
                sqlCommand.Parameters.AddWithValue("@Type", car.Type);
                sqlCommand.Parameters.AddWithValue("@Available", car.Available);
                sqlCommand.Parameters.Add("@Image", SqlDbType.Image).Value = (car.Image == null) ? (object)DBNull.Value : car.Image;
                sqlCommand.Parameters.AddWithValue("@TotalRentals", car.TotalRentals);
                sqlCommand.Parameters.AddWithValue("@Id_Model", car.IdModel);
                sqlCommand.Parameters.AddWithValue("@CubicCapacity", car.CubicCapacity);
                sqlCommand.Parameters.AddWithValue("@Fuel", car.Fuel);
                sqlCommand.Parameters.AddWithValue("@FuelConsuption", car.FuelConsuption);
                sqlCommand.Parameters.AddWithValue("@Power", car.Power);
                sqlCommand.Parameters.AddWithValue("@Kilometers", car.Kilometers);
                sqlCommand.Parameters.AddWithValue("@Town", car.Town);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteReader();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public int DeleteCar(Car car)
        {
            int carDelete = 0;
            using (sqlConnection = new SqlConnection(Helper.CONNECTION_STRING))
            {
                sqlCommand = new SqlCommand("DELETE FROM Car WHERE Id = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", car.Id);
                sqlConnection.Open();
                carDelete = sqlCommand.ExecuteNonQuery();
            }
            return carDelete;  
        }

        public List<Car> GetCarByManufacturer(Manufacturer manufacturer)
        {
            sqlCommand = new SqlCommand("SELECT * FROM Car c LEFT JOIN Model m ON c.Id_Model = m.Id LEFT JOIN Manufacturer man ON man.Id = m.Id_Manufacturer WHERE man.Id = @id")
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@id", manufacturer.Id);
            return GetSQLCommand(sqlCommand);
        }

        public List<Car> GetCarByModel(CarModel model)
        {
            sqlCommand = new SqlCommand("SELECT * from Car c WHERE c.Id_Model = @model")
            {
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.AddWithValue("@model", model.Id);
            return GetSQLCommand(sqlCommand);
        }

        public List<Car> GetCars()
        {
            SqlCommand sqlComamnd = new SqlCommand("SELECT * from Car")
            {
                CommandType = CommandType.Text
            };
            return GetSQLCommand(sqlComamnd);
        }

        private List<Car> GetSQLCommand(SqlCommand sqlCommand)
        {
            using (sqlConnection = new SqlConnection(Helper.CONNECTION_STRING))
            {
                List<Car> cars = new List<Car>();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.Id = (int)reader["Id"];
                    car.Available = (bool)reader["Available"];
                    car.CubicCapacity = (int)reader["CubicCapacity"];
                    car.Fuel = (string)reader["Fuel"];
                    car.FuelConsuption = (double)reader["FuelConsuption"];
                    car.IdModel = (int)reader["Id_Model"];
                    car.Image = reader.IsDBNull(reader.GetOrdinal("Image")) ? null : (byte[])reader["Image"];
                    car.Kilometers = (int)reader["Kilometers"];
                    car.Power = (int)reader["Power"];
                    car.TotalRentals = (int)reader["TotalRentals"];
                    car.Type = (string)reader["Type"];
                    car.Town = (string)reader["Town"];
                    cars.Add(car);
                }
                return cars;

            }
        }

        public int UpdateCar(Car car)
        {
            int carUpdate = 0;
            using (sqlConnection = new SqlConnection(Helper.CONNECTION_STRING))
            {
                try
                {
                    sqlCommand = new SqlCommand("UPDATE Car SET CubicCapacity = @cc, Fuel = @fuel, FuelConsuption = @fuelCon, Id_Model = @model, " +
                            " Image = @image, Kilometers = @km, Power = @pwr, Type = @type  WHERE Id = @id", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@cc", car.CubicCapacity);
                    sqlCommand.Parameters.AddWithValue("@fuel", car.Fuel);
                    sqlCommand.Parameters.AddWithValue("@fuelCon", car.FuelConsuption);
                    sqlCommand.Parameters.AddWithValue("@model", car.IdModel);
                    sqlCommand.Parameters.Add("@image", SqlDbType.Image).Value = car.Image == null ? DBNull.Value : (object)car.Image;
                    sqlCommand.Parameters.AddWithValue("@image", car.Image == null ? DBNull.Value : (object)car.Image);
                    sqlCommand.Parameters.AddWithValue("@km", car.Kilometers);
                    sqlCommand.Parameters.AddWithValue("@pwr", car.Power);
                    sqlCommand.Parameters.AddWithValue("@type", car.Type);
                    sqlCommand.Parameters.AddWithValue("@id", car.Id);
                    sqlCommand.Parameters.AddWithValue("@Town", car.Town);
                    sqlConnection.Open();
                    carUpdate = sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                return carUpdate;
            }
        }
    }
}
