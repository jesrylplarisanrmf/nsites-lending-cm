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
    public class Client
    {
        public string Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Nickname { get; set; }
        public string CellphoneNo { get; set; }
        public DateTime Birthday { get; set; }
        public string SitioPurokStreet { get; set; }
        public string Barangay { get; set; }
        public string TownCity { get; set; }
        public string Province { get; set; }
        public int YearsOfStay { get; set; }
        public string HomeType { get; set; }
        public string Picture { get; set; }
        public string ID1 { get; set; }
        public string ID2 { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getClients(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClients('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getClientNames(string pDisplayType, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClientNames('" + pDisplayType + "','" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getClientLists()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetClientLists();", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertClient(Client pClient)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertClient('" + pClient.Lastname +
                    "','" + pClient.Firstname +
                    "','" + pClient.Middlename +
                    "','" + pClient.Nickname +
                    "','" + pClient.CellphoneNo +
                    "','" + String.Format("{0:yyyy-MM-dd}", pClient.Birthday) +
                    "','" + pClient.SitioPurokStreet +
                    "','" + pClient.Barangay +
                    "','" + pClient.TownCity +
                    "','" + pClient.Province +
                    "','" + pClient.YearsOfStay +
                    "','" + pClient.HomeType +
                    "','" + pClient.Picture +
                    "','" + pClient.ID1 +
                    "','" + pClient.ID2 +
                    "','" + pClient.Remarks +
                    "','" + pClient.UserId + "');", _conn);
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

        public string updateClient(Client pClient)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateClient('" + pClient.Id +
                    "','" + pClient.Lastname +
                    "','" + pClient.Firstname +
                    "','" + pClient.Middlename +
                    "','" + pClient.Nickname +
                    "','" + pClient.CellphoneNo +
                    "','" + String.Format("{0:yyyy-MM-dd}", pClient.Birthday) +
                    "','" + pClient.SitioPurokStreet +
                    "','" + pClient.Barangay +
                    "','" + pClient.TownCity +
                    "','" + pClient.Province +
                    "','" + pClient.YearsOfStay +
                    "','" + pClient.HomeType +
                    "','" + pClient.Picture +
                    "','" + pClient.ID1 +
                    "','" + pClient.ID2 +
                    "','" + pClient.Remarks +
                    "','" + pClient.UserId + "');", _conn);
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

        public bool removeClient(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveClient('" + pId +
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