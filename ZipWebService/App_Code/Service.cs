using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ZipWebService.App_Code
{
    public static class Service // Clean this up and deploy on Github

    {
        public static string ReadZipFromDatabase(string zipcode)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader dataReaderZips = null;
            SqlDataReader dataReaderStates = null;
            string dbCity = "";
            string dbStateCode = "";
            string dbStateName = "";

            var connectionString = "Wouldn't you like to know ;)";

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
                connection.Open();
            }
            catch(InvalidOperationException e)
            {
                return e.Message;
            }
            catch (SqlException e)
            {
                return e.Message;
            }
            catch (ConfigurationErrorsException e)
            {
                return e.Message;
            }

            command = new SqlCommand("SELECT * FROM ZIP_Codes WHERE ZIPcode = " + zipcode , connection);
            dataReaderZips = command.ExecuteReader();

            if(dataReaderZips.Read())
            { 
                dbCity = dataReaderZips["City"].ToString();
                // Make every letter following the first letter of the string lowercase
                dbCity = dbCity.Substring(0, 1) + dbCity.Substring(1, dbCity.Length - 1).ToLower();

                dbStateCode = dataReaderZips["State_Code"].ToString();
            }
            dataReaderZips.Close();

            command = new SqlCommand("SELECT * FROM States WHERE StateCode = " + dbStateCode, connection);
            dataReaderStates = command.ExecuteReader();

            if(dataReaderStates.Read())
            {
                dbStateName = dataReaderStates["StateName"].ToString();
            }

            connection.Close();
            return dbCity + ", " + dbStateName;
        }
    }
}