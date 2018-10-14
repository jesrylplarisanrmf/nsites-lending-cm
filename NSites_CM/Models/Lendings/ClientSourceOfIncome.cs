using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using System.DirectoryServices.AccountManagement;
using MySql.Data.MySqlClient;

namespace NSites_CM.Models.Lendings
{
    public class ClientSourceOfIncome
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string Type { get; set; }
        public string Occupation { get; set; }
        public decimal NetIncome { get; set; }
        public int NoOfYears { get; set; }
        public string Employer { get; set; }
        public string EmployerAddress { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getClientSourceOfIncomes(string pClientId, string pPrimaryKey)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClientSourceOfIncomes(" + (pClientId == null ? "0" : pClientId) + "," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertClientSourceOfIncome(ClientSourceOfIncome pClientSourceOfIncome)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertClientSourceOfIncome('" + pClientSourceOfIncome.ClientId +
                    "','" + pClientSourceOfIncome.Type +
                    "','" + pClientSourceOfIncome.Occupation +
                    "','" + pClientSourceOfIncome.NetIncome +
                    "','" + pClientSourceOfIncome.NoOfYears +
                    "','" + pClientSourceOfIncome.Employer +
                    "','" + pClientSourceOfIncome.EmployerAddress +
                    "','" + pClientSourceOfIncome.Remarks +
                    "','" + pClientSourceOfIncome.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _Id = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch
                {
                    _trans.Rollback();
                    _Id = "";
                }
            }
            return _Id;
        }

        public string updateClientSourceOfIncome(ClientSourceOfIncome pClientSourceOfIncome)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateClientSourceOfIncome('" + pClientSourceOfIncome.Id +
                    "','" + pClientSourceOfIncome.ClientId +
                    "','" + pClientSourceOfIncome.Type +
                    "','" + pClientSourceOfIncome.Occupation +
                    "','" + pClientSourceOfIncome.NetIncome +
                    "','" + pClientSourceOfIncome.NoOfYears +
                    "','" + pClientSourceOfIncome.Employer +
                    "','" + pClientSourceOfIncome.EmployerAddress +
                    "','" + pClientSourceOfIncome.Remarks +
                    "','" + pClientSourceOfIncome.UserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    _Id = _cmd.ExecuteScalar().ToString();
                    _trans.Commit();
                    _conn.Close();
                }
                catch
                {
                    _trans.Rollback();
                    _Id = "";
                }
            }
            return _Id;
        }

        public bool removeClientSourceOfIncome(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveClientSourceOfIncome('" + pId +
                    "','" + pUserId + "');", _conn);
                try
                {
                    _cmd.Transaction = _trans;
                    int _rowsAffected = _cmd.ExecuteNonQuery();
                    _trans.Commit();
                    _conn.Close();
                    if (_rowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _trans.Rollback();
                    _success = false;
                }
            }
            return _success;
        }
    }
}