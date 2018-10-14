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
    public class ClientPersonalReference
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string CompleteAddress { get; set; }
        public string SourceOfIncome { get; set; }
        public string CellphoneNo { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getClientPersonalReferences(string pClientId, string pPrimaryKey)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClientPersonalReferences(" + (pClientId == null ? "0" : pClientId) + "," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertClientPersonalReference(ClientPersonalReference pClientPersonalReference)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertClientPersonalReference('" + pClientPersonalReference.ClientId +
                    "','" + pClientPersonalReference.Name +
                    "','" + pClientPersonalReference.Relationship +
                    "','" + pClientPersonalReference.CompleteAddress +
                    "','" + pClientPersonalReference.SourceOfIncome +
                    "','" + pClientPersonalReference.CellphoneNo +
                    "','" + pClientPersonalReference.Remarks +
                    "','" + pClientPersonalReference.UserId + "');", _conn);
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

        public string updateClientPersonalReference(ClientPersonalReference pClientPersonalReference)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateClientPersonalReference('" + pClientPersonalReference.Id +
                    "','" + pClientPersonalReference.ClientId +
                    "','" + pClientPersonalReference.Name +
                    "','" + pClientPersonalReference.Relationship +
                    "','" + pClientPersonalReference.CompleteAddress +
                    "','" + pClientPersonalReference.SourceOfIncome +
                    "','" + pClientPersonalReference.CellphoneNo +
                    "','" + pClientPersonalReference.Remarks +
                    "','" + pClientPersonalReference.UserId + "');", _conn);
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

        public bool removeClientPersonalReference(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveClientPersonalReference('" + pId +
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