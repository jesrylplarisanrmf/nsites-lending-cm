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
    public class LoanEndOfDay
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string BranchId { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalRunningBalance { get; set; }
        public decimal TotalCollection { get; set; }
        public decimal TotalVariance { get; set; }
        public decimal TotalLoanRelease { get; set; }
        public decimal TotalServiceFee { get; set; }
        public string EndedBy { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getLoanEndOfDays(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanEndOfDays('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLoanEndOfDayByBranch(string pBranchId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanEndOfDayByBranch('" + pBranchId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getMonthlyCollections(string pYear, string pBranchId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetMonthlyCollections('" + pYear + "','" + pBranchId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertLoanEndOfDay(LoanEndOfDay pLoanEndOfDay)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLoanEndOfDay('" + String.Format("{0:yyyy-MM-dd hh:mm:ss}", pLoanEndOfDay.Date) +
                    "','" + pLoanEndOfDay.BranchId +
                    "','" + pLoanEndOfDay.TotalAmountDue +
                    "','" + pLoanEndOfDay.TotalRunningBalance +
                    "','" + pLoanEndOfDay.TotalCollection +
                    "','" + pLoanEndOfDay.TotalVariance +
                    "','" + pLoanEndOfDay.TotalLoanRelease +
                    "','" + pLoanEndOfDay.TotalServiceFee +
                    "','" + pLoanEndOfDay.EndedBy +
                    "','" + pLoanEndOfDay.Remarks +
                    "','" + pLoanEndOfDay.UserId + "');", _conn);
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

        public string updateLoanEndOfDay(LoanEndOfDay pLoanEndOfDay)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateLoanEndOfDay('" + pLoanEndOfDay.Id +
                    "','" + String.Format("{0:yyyy-MM-dd hh:mm:ss}", pLoanEndOfDay.Date) +
                    "','" + pLoanEndOfDay.BranchId +
                    "','" + pLoanEndOfDay.TotalAmountDue +
                    "','" + pLoanEndOfDay.TotalRunningBalance +
                    "','" + pLoanEndOfDay.TotalCollection +
                    "','" + pLoanEndOfDay.TotalVariance +
                    "','" + pLoanEndOfDay.TotalLoanRelease +
                    "','" + pLoanEndOfDay.TotalServiceFee +
                    "','" + pLoanEndOfDay.EndedBy +
                    "','" + pLoanEndOfDay.Remarks +
                    "','" + pLoanEndOfDay.UserId + "');", _conn);
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

        public bool removeLoanEndOfDay(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveLoanEndOfDay('" + pId +
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