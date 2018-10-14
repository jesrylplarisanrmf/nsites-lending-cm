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
    public class ClientFamilyMember
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public int Age { get; set; }
        public string CellphoneNo { get; set; }
        public string BusinessWorkSchool { get; set; }
        public decimal Income { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getClientFamilyMembers(string pClientId, string pPrimaryKey)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClientFamilyMembers(" + (pClientId == null ? "0" : pClientId) + "," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ");", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertClientFamilyMember(ClientFamilyMember pClientFamilyMember)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertClientFamilyMember('" + pClientFamilyMember.ClientId +
                    "','" + pClientFamilyMember.Name +
                    "','" + pClientFamilyMember.Relationship +
                    "','" + pClientFamilyMember.Age +
                    "','" + pClientFamilyMember.CellphoneNo +
                    "','" + pClientFamilyMember.BusinessWorkSchool +
                    "','" + pClientFamilyMember.Income +
                    "','" + pClientFamilyMember.Remarks +
                    "','" + pClientFamilyMember.UserId + "');", _conn);
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

        public string updateClientFamilyMember(ClientFamilyMember pClientFamilyMember)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateClientFamilyMember('" + pClientFamilyMember.Id +
                    "','" + pClientFamilyMember.ClientId +
                    "','" + pClientFamilyMember.Name +
                    "','" + pClientFamilyMember.Relationship +
                    "','" + pClientFamilyMember.Age +
                    "','" + pClientFamilyMember.CellphoneNo +
                    "','" + pClientFamilyMember.BusinessWorkSchool +
                    "','" + pClientFamilyMember.Income +
                    "','" + pClientFamilyMember.Remarks +
                    "','" + pClientFamilyMember.UserId + "');", _conn);
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

        public bool removeClientFamilyMember(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveClientFamilyMember('" + pId +
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