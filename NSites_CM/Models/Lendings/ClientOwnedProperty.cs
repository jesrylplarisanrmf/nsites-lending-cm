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
    public class ClientOwnedProperty
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getClientOwnedPropertys(string pClientId, string pPrimaryKey)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClientOwnedPropertys(" + (pClientId == null ? "0" : pClientId) + "," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertClientOwnedProperty(ClientOwnedProperty pClientOwnedProperty)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertClientOwnedProperty('" + pClientOwnedProperty.ClientId +
                    "','" + pClientOwnedProperty.PropertyType +
                    "','" + pClientOwnedProperty.Location +
                    "','" + pClientOwnedProperty.Model +
                    "','" + pClientOwnedProperty.Value +
                    "','" + pClientOwnedProperty.Remarks +
                    "','" + pClientOwnedProperty.UserId + "');", _conn);
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

        public string updateClientOwnedProperty(ClientOwnedProperty pClientOwnedProperty)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateClientOwnedProperty('" + pClientOwnedProperty.Id +
                    "','" + pClientOwnedProperty.ClientId +
                    "','" + pClientOwnedProperty.PropertyType +
                    "','" + pClientOwnedProperty.Location +
                    "','" + pClientOwnedProperty.Model +
                    "','" + pClientOwnedProperty.Value +
                    "','" + pClientOwnedProperty.Remarks +
                    "','" + pClientOwnedProperty.UserId + "');", _conn);
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

        public bool removeClientOwnedProperty(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveClientOwnedProperty('" + pId +
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