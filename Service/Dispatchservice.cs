using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.DynamicData;

namespace PackSlipApp.Service
{
    public class Dispatchservice
    {


        public List<SelectListItem> GetJobNum()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                string _connectionString = "Server=Erpgcc-read00.epicorsaas.com,63424; Initial Catalog=SaaS1143_62653; User Id=C62653RO; Password=4Tf~Qc0%6URLrz; TrustServerCertificate=True; MultipleActiveResultSets=true";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT JobNum FROM [erp].[Jobhead] WHERE Company = 'SN' AND JobClosed != 1 AND JobComplete != 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                selectListItems.Add(new SelectListItem
                                {
                                    Value = reader["JobNum"].ToString(),
                                    Text = reader["JobNum"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return selectListItems;
        }

        public List<SelectListItem> GetPONum()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                string _connectionString = "Server=Erpgcc-read00.epicorsaas.com,63424; Initial Catalog=SaaS1143_62653; User Id=C62653RO; Password=4Tf~Qc0%6URLrz; TrustServerCertificate=True; MultipleActiveResultSets=true";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT PoNum FROM [erp].[POHeader] WHERE Company = 'SN' and  OpenOrder = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                selectListItems.Add(new SelectListItem
                                {
                                    Value = reader["PoNum"].ToString(),
                                    Text = reader["PoNum"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return selectListItems;
        }
        public DataTable GetPartNum(string jobno)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            DataTable dataTable = new DataTable();
            try
            {
                string _connectionString = "Server=Erpgcc-read00.epicorsaas.com,63424; Initial Catalog=SaaS1143_62653; User Id=C62653RO; Password=4Tf~Qc0%6URLrz; TrustServerCertificate=True; MultipleActiveResultSets=true";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT PartNum FROM [erp].[Jobhead] WHERE Company = 'SN' AND JobClosed != 1 AND JobComplete != 1 and JobNum = @jobno";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@jobno", jobno);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return dataTable;
        }

        public DataTable GetPOlineno(string partnum)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            DataTable dataTable = new DataTable();

            try
            {
                string _connectionString = "Server=Erpgcc-read00.epicorsaas.com,63424; Initial Catalog=SaaS1143_62653; User Id=C62653RO; Password=4Tf~Qc0%6URLrz; TrustServerCertificate=True; MultipleActiveResultSets=true";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT DISTINCT PONUM,POLine FROM [erp].[PODetail] where Company='SSW' and PartNum = @partnum";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@partnum", partnum);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        { 
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            
            return dataTable;

        }
    }
}