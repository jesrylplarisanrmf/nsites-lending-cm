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
    public class LoanEndOfDayDetail
    {
        public string DetailId { get; set; }
        public string LoanEndOfDayId { get; set; }
        public string CollectorId { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalRunningBalance { get; set; }
        public decimal TotalCollection { get; set; }
        public decimal TotalVariance { get; set; }
        public decimal TotalLoanRelease { get; set; }
        public decimal TotalServiceFee { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getLoanEndOfDayDetails(string pLoanEndOfDayId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanEndOfDayDetails('" + pLoanEndOfDayId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertLoanEndOfDayDetail(LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLoanEndOfDayDetail('" + pLoanEndOfDayDetail.LoanEndOfDayId +
                    "','" + pLoanEndOfDayDetail.CollectorId +
                    "','" + pLoanEndOfDayDetail.TotalAmountDue +
                    "','" + pLoanEndOfDayDetail.TotalRunningBalance +
                    "','" + pLoanEndOfDayDetail.TotalCollection +
                    "','" + pLoanEndOfDayDetail.TotalVariance +
                    "','" + pLoanEndOfDayDetail.TotalLoanRelease +
                    "','" + pLoanEndOfDayDetail.TotalServiceFee +
                    "','" + pLoanEndOfDayDetail.Remarks +
                    "','" + pLoanEndOfDayDetail.UserId + "');", _conn);
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

        public bool updateLoanEndOfDayDetail(LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateLoanEndOfDayDetail('" + pLoanEndOfDayDetail.DetailId +
                    "','" + pLoanEndOfDayDetail.LoanEndOfDayId +
                    "','" + pLoanEndOfDayDetail.CollectorId +
                    "','" + pLoanEndOfDayDetail.TotalAmountDue +
                    "','" + pLoanEndOfDayDetail.TotalRunningBalance +
                    "','" + pLoanEndOfDayDetail.TotalCollection +
                    "','" + pLoanEndOfDayDetail.TotalVariance +
                    "','" + pLoanEndOfDayDetail.TotalLoanRelease +
                    "','" + pLoanEndOfDayDetail.TotalServiceFee +
                    "','" + pLoanEndOfDayDetail.Remarks +
                    "','" + pLoanEndOfDayDetail.UserId + "');", _conn);
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

        public bool removeLoanEndOfDayDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveLoanEndOfDayDetail('" + pDetailId +
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