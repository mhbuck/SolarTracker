using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using SolarTracker.Models;

namespace SolarTracker
{
    public class DataAccess
    {
        public const string ConnectionString = @"Data Source=dbxxxxxxxdb.1and1.com,1433;Initial Catalog=dbxxxxxxx;User Id=dboxxxxxxx;Password=xxxxxxxxxxx;";

        public CompassDetail GetCurrentDetail()
        {
            // Gets the current location for the triggered update on the web page

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlSelect = @"SELECT Heading, Pitch, Roll, SolarAzimuth, SolarElevation, ImpVoltage FROM ecompass WHERE impid like '234aaaaaaaaaaa'";

                // Using a library called dapper the sql statment will get executed and populated into this object type
                var trackerStatus = connection.Query<CompassDetail>(sqlSelect);
                
                // as a result set it retuned set only one to be returned
                return trackerStatus.SingleOrDefault();
            }
        }

        public void UpdatePosition(CompassDetail currentData)
        {
            // Using parameters as that removes any issues around sql injection which can do bad things
            string updateSql = "UPDATE Ecompass SET Heading=@Heading, Pitch=@Pitch, Roll=@Roll, ImpVoltage=@ImpVoltage, SolarArazimuth=@SolarArazimuth, SolarElevation=@SolarElevation WHERE ImpId=@ImpId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // The dapper library will take the object passed in and create the parameters based on the property names and execute
                connection.Execute(updateSql, currentData);
            }
        }

        public void SaveMoveDetails(MotionDetail motion)
        {
            // Missing code so I am not sure what needed to happen here.
            throw new NotImplementedException();
        }
    }
}