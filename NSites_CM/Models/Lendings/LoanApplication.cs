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
    public class LoanApplication
    {
        public string LoanApplicationId { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationStatus { get; set; }
        public int LoanCycle { get; set; }
        public string ClientId { get; set; }
        public string BranchId { get; set; }
        public string ZoneId { get; set; }
        public string CollectorId { get; set; }
        public string ProductId { get; set; }
        public string PaymentFrequency { get; set; }
        public int Terms { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal ServiceFeeRate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal InstallmentAmountDue { get; set; }
        public decimal ServiceFeeAmount { get; set; }
        public decimal LoanReleaseAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Penalty { get; set; }
        public decimal RunningBalance { get; set; }
        public decimal PastDueAmount { get; set; }
        public decimal AdvancePayment { get; set; }
        public decimal TotalDaysPastDue { get; set; }
        public string PreparedBy { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime DateApproved { get; set; }
        public string DisapprovedBy { get; set; }
        public DateTime DateDisapproved { get; set; }
        public string DisapprovedReason { get; set; }
        public string DisbursedBy { get; set; }
        public DateTime DateDisbursed { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }

        public DataTable getLoanApplications(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplications('" + pDisplayType + "'," + (pPrimaryKey == null ? "0" : pPrimaryKey) + ",'" + pSearchString + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLoanApplicationPastDueAccounts()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplicationPastDueAccounts();", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLoanApplicationByClient(string pClientId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplicationByClient('" + pClientId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLoanApplicationByClientLedger(string pClientId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplicationByClientLedger('" + pClientId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLoanApplicationStatus(string pApplicationLoanId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLoanApplicationStatus('" + pApplicationLoanId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getForReleaseSheet(DateTime pReleaseDate, string pCollectorId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetForReleaseSheet('" + String.Format("{0:yyyy-MM-dd}", pReleaseDate) + "','" + pCollectorId + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getMonthlyProjectionByBranch(string pBranchId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetMonthlyProjectionByBranch('" + pBranchId + "','" + String.Format("{0:MM-yyyy}", DateTime.Now.AddMonths(1)) + "');", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public string insertLoanApplication(LoanApplication pLoanApplication)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLoanApplication('" + String.Format("{0:yyyy-MM-dd}", pLoanApplication.Date) +
                    "','" + pLoanApplication.LoanCycle +
                    "','" + pLoanApplication.ClientId +
                    "','" + pLoanApplication.BranchId +
                    "','" + pLoanApplication.ZoneId +
                    "','" + pLoanApplication.CollectorId +
                    "','" + pLoanApplication.ProductId +
                    "','" + pLoanApplication.PaymentFrequency +
                    "','" + pLoanApplication.Terms +
                    "','" + String.Format("{0:yyyy-MM-dd}", pLoanApplication.StartDate) +
                    "','" + String.Format("{0:yyyy-MM-dd}", pLoanApplication.MaturityDate) +
                    "','" + pLoanApplication.InterestRate +
                    "','" + pLoanApplication.ServiceFeeRate +
                    "','" + pLoanApplication.LoanAmount +
                    "','" + pLoanApplication.InterestAmount +
                    "','" + pLoanApplication.TotalAmountDue +
                    "','" + pLoanApplication.InstallmentAmountDue +
                    "','" + pLoanApplication.ServiceFeeAmount +
                    "','" + pLoanApplication.LoanReleaseAmount +
                    "','" + pLoanApplication.Remarks +
                    "','" + pLoanApplication.UserId + "');", _conn);
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

        public string updateLoanApplication(LoanApplication pLoanApplication)
        {
            string _Id = "";
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateLoanApplication('" + pLoanApplication.LoanApplicationId +
                    "','" + String.Format("{0:yyyy-MM-dd}", pLoanApplication.Date) +
                    "','" + pLoanApplication.LoanCycle +
                    "','" + pLoanApplication.ClientId +
                    "','" + pLoanApplication.BranchId +
                    "','" + pLoanApplication.ZoneId +
                    "','" + pLoanApplication.CollectorId +
                    "','" + pLoanApplication.ProductId +
                    "','" + pLoanApplication.PaymentFrequency +
                    "','" + pLoanApplication.Terms +
                    "','" + String.Format("{0:yyyy-MM-dd}", pLoanApplication.StartDate) +
                    "','" + String.Format("{0:yyyy-MM-dd}", pLoanApplication.MaturityDate) +
                    "','" + pLoanApplication.InterestRate +
                    "','" + pLoanApplication.ServiceFeeRate +
                    "','" + pLoanApplication.LoanAmount +
                    "','" + pLoanApplication.InterestAmount +
                    "','" + pLoanApplication.TotalAmountDue +
                    "','" + pLoanApplication.InstallmentAmountDue +
                    "','" + pLoanApplication.ServiceFeeAmount +
                    "','" + pLoanApplication.LoanReleaseAmount +
                    "','" + pLoanApplication.Remarks +
                    "','" + pLoanApplication.UserId + "');", _conn);
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

        public bool removeLoanApplication(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveLoanApplication('" + pId +
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

        public bool approveLoanApplication(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spApproveLoanApplication('" + pId +
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

        public bool cancelLoanApplication(string pId,string pReason, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spCancelLoanApplication('" + pId +
                    "','" + pReason +
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

        public bool postLoanApplication(string pId, string pUserId)
        {
            bool _success = false;
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlTransaction _trans = _conn.BeginTransaction();
                MySqlCommand _cmd = new MySqlCommand("call spPostLoanApplication('" + pId +
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