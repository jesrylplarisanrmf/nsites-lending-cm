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
    public class LoanApplicationDetail
    {
        public string DetailId { get; set; }
        public string LoanApplicationId { get; set; }
        public int SeqNo { get; set; }
        public DateTime Date { get; set; }
        public decimal AmountDue { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal RunningBalance { get; set; }
        public decimal NewBalance { get; set; }
        public decimal Variance { get; set; }
        public string PastDueReason { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getLoanApplicationDetails(string pLoanApplicationId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplicationDetails('" + pLoanApplicationId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLoanApplicationDetail(string pDetailId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplicationDetail('" + pDetailId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getDailyCollectionSheet(DateTime pCollectionDate,string pCollectorId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetDailyCollectionSheet('" + String.Format("{0:yyyy-MM-dd}", pCollectionDate) + "','" + pCollectorId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getUploadCollectionList(DateTime pCollectionDate, string pCollectorId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetUploadCollectionList('" + String.Format("{0:yyyy-MM-dd}", pCollectionDate) + "','" + pCollectorId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getEODLoanApplicationDetail(DateTime pDate, string pBranchId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetEODLoanApplicationDetail('" + String.Format("{0:yyyy-MM-dd}", pDate) + "','" + pBranchId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getEODLoanApplicationDetailList(DateTime pDate, string pBranchId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetEODLoanApplicationDetailList('" + String.Format("{0:yyyy-MM-dd}", pDate) + "','" + pBranchId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertLoanApplicationDetail(LoanApplicationDetail pLoanApplicationDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLoanApplicationDetail('" + pLoanApplicationDetail.LoanApplicationId +
                    "','" + pLoanApplicationDetail.SeqNo +
                    "','" + String.Format("{0:yyyy-MM-dd}", pLoanApplicationDetail.Date) +
                    "','" + pLoanApplicationDetail.AmountDue +
                    "','" + pLoanApplicationDetail.InstallmentAmount +
                    "','" + pLoanApplicationDetail.PaymentAmount +
                    "','" + pLoanApplicationDetail.RunningBalance +
                    "','" + pLoanApplicationDetail.NewBalance +
                    "','" + pLoanApplicationDetail.Variance +
                    "','" + pLoanApplicationDetail.PastDueReason +
                    "','" + pLoanApplicationDetail.Remarks +
                    "','" + pLoanApplicationDetail.UserId + "');", _conn);
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

        public bool updateLoanApplicationDetail(LoanApplicationDetail pLoanApplicationDetail)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateLoanApplicationDetail('" + pLoanApplicationDetail.DetailId +
                    "','" + pLoanApplicationDetail.LoanApplicationId +
                    "','" + pLoanApplicationDetail.SeqNo +
                    "','" + pLoanApplicationDetail.Date +
                    "','" + pLoanApplicationDetail.AmountDue +
                    "','" + pLoanApplicationDetail.InstallmentAmount +
                    "','" + pLoanApplicationDetail.PaymentAmount +
                    "','" + pLoanApplicationDetail.RunningBalance +
                    "','" + pLoanApplicationDetail.NewBalance +
                    "','" + pLoanApplicationDetail.Variance +
                    "','" + pLoanApplicationDetail.PastDueReason +
                    "','" + pLoanApplicationDetail.Remarks +
                    "','" + pLoanApplicationDetail.UserId + "');", _conn);
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

        public bool removeLoanApplicationDetail(string pDetailId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveLoanApplicationDetail('" + pDetailId +
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

        public bool updatePayment(string pDetailId, decimal pPayment, decimal pNewBalance, decimal pVariance, string pPastDueReason, string pRemarks,string pCollectorId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdatePayment('" + pDetailId +
                    "','" + pPayment +
                    "','" + pNewBalance +
                    "','" + pVariance +
                    "','" + pPastDueReason +
                    "','" + pRemarks +
                    "','" + pCollectorId +
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

        public bool updateEODLoanTransactionDetail(string pDetailId, string pEODId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateEODLoanApplicationDetail('" + pDetailId +
                    "','" + pEODId +
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