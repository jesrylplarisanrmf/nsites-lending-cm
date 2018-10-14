using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

using NSites_CM.Models.Generics;
using NSites_CM.Models.Lendings;
using NSites_CM.Models.Systems;

using System.Data;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace NSites_CM.Controllers
{
    public class MainController : ApiController
    {
        #region "INITIALIZATION"
        //Generics
        Common loCommon = new Common();
       
        //Lendings
        Client loClient = new Client();
        ClientFamilyMember loClientFamilyMember = new ClientFamilyMember();
        ClientPersonalReference loClientPersonalReference = new ClientPersonalReference();
        ClientSourceOfIncome loClientSourceOfIncome = new ClientSourceOfIncome();
        ClientOwnedProperty loClientOwnedProperty = new ClientOwnedProperty();
        ClientCreditExperience loClientCreditExperience = new ClientCreditExperience();
        Area loArea = new Area();
        Branch loBranch = new Branch();
        Zone loZone = new Zone();
        Collector loCollector = new Collector();
        Product loProduct = new Product();
        LoanApplication loLoanApplication = new LoanApplication();
        LoanApplicationDetail loLoanApplicationDetail = new LoanApplicationDetail();
        LoanEndOfDay loLoanEndOfDay = new LoanEndOfDay();
        LoanEndOfDayDetail loLoanEndOfDayDetail = new LoanEndOfDayDetail();
       
        //Systems
        User loUser = new User();
        UserGroup loUserGroup = new UserGroup();
        SystemConfiguration loSystemConfigurations = new SystemConfiguration();
        AuditTrail loAuditTrail = new AuditTrail();
        #endregion

        #region "GENERICS"
        [HttpGet]
        public string test()
        {
            return "Test Successful!";
        }

        [HttpGet]
        public DataTable getDataFromSearch(string pQueryString)
        {
            return loCommon.getDataFromSearch(pQueryString);
        }

        [HttpGet]
        public DataTable getUserGroupMenuItems(string pUsername)
        {
            return loCommon.getUserGroupMenuItems(pUsername);
        }

        [HttpGet]
        public DataTable getUserGroupRights(string pUsername)
        {
            return loCommon.getUserGroupRights(pUsername);
        }

        [HttpGet]
        public DataTable getMenuItems()
        {
            return loCommon.getMenuItems();
        }

        [HttpGet]
        public DataTable getAllMenuItems()
        {
            return loCommon.getAllMenuItems();
        }

        [HttpGet]
        public DataTable getAllRights(string pItemName)
        {
            return loCommon.getAllRights(pItemName);
        }

        [HttpGet]
        public DataTable getMenuItemsByGroup(string pUserGroupId)
        {
            return loCommon.getMenuItemsByGroup(pUserGroupId);
        }

        [HttpGet]
        public DataTable getEnableRights(string pItemName, string pUserGroupId)
        {
            return loCommon.getEnableRights(pItemName, pUserGroupId);
        }

        [HttpGet]
        public DataTable getEnableCompanys(string pUserGroupId)
        {
            return loCommon.getEnableCompanys(pUserGroupId);
        }

        [HttpGet]
        public bool sendEmail(string pFrom, string pTo, string pCC, string pSubject, string pBody, string pUsername, string pUserPassword)
        {
            return loCommon.sendEmail(pFrom, pTo, pCC, pSubject, pBody, pUsername, pUserPassword);
        }

        [HttpGet]
        public DataTable getTemplateNames(string pMenuName, string pUserId)
        {
            return loCommon.getTemplateNames(pMenuName, pUserId);
        }

        [HttpGet]
        public DataTable getTemplateName(string pId)
        {
            return loCommon.getTemplateName(pId);
        }

        [HttpGet]
        public DataTable getSearchFilters(string pTemplateId)
        {
            return loCommon.getSearchFilters(pTemplateId);
        }

        [HttpGet]
        public string insertSearchTemplate(string pTemplateName, string pItemName, string pPrivate, string pUserId)
        {
            return loCommon.insertSearchTemplate(pTemplateName, pItemName, pPrivate, pUserId);
        }

        [HttpGet]
        public bool removeSearchFilter(string pTemplateId)
        {
            return loCommon.removeSearchFilter(pTemplateId);
        }

        [HttpGet]
        public bool removeSearchTemplate(string pId)
        {
            return loCommon.removeSearchTemplate(pId);
        }

        [HttpGet]
        public bool renameSearchTemplate(string pId, string pTemplateName)
        {
            return loCommon.renameSearchTemplate(pId, pTemplateName);
        }

        [HttpGet]
        public bool updateSearchTemplate(string pId, string pTemplateName, string pItemName, string pPrivate)
        {
            return loCommon.updateSearchTemplate(pId, pTemplateName, pItemName, pPrivate);
        }

        [HttpGet]
        public bool insertSearchFilter(string pTemplateId, string pField, string pOperator, string pValue, string pCheckAnd, string pCheckOr, int pSequence)
        {
            return loCommon.insertSearchFilter(pTemplateId, pField, pOperator, pValue, pCheckAnd, pCheckOr,pSequence);
        }

        [HttpGet]
        public DataTable getViewDetails()
        {
            return loCommon.getViewDetails();
        }

        [HttpGet]
        public DataTable getStoredProcedureDetails(string pDatabaseName)
        {
            return loCommon.getStoredProcedureDetails(pDatabaseName);
        }

        [HttpGet]
        public DataTable getFunctionDetails(string pDatabaseName)
        {
            return loCommon.getFunctionDetails(pDatabaseName);
        }

        [HttpGet]
        public DataTable getTableDetails()
        {
            return loCommon.getTableDetails();
        }

        [HttpGet]
        public DataTable getMenuItemDetails()
        {
            return loCommon.getMenuItemDetails();
        }

        [HttpGet]
        public DataTable getItemRightDetails()
        {
            return loCommon.getItemRightDetails();
        }

        [HttpGet]
        public DataTable getSystemConfigurationDetails()
        {
            return loCommon.getSystemConfigurationDetails();
        }

        [HttpGet]
        public DataTable getNextTabelSequenceId(string pDescription)
        {
            return loCommon.getNextTabelSequenceId(pDescription);
        }
        #endregion "END OF GLOBAL"

        #region "LENDINGS"
        #region "Client"
        [HttpGet]
        public DataTable getClients(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loClient.getClients(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getClientNames(string pDisplayType, string pSearchString)
        {
            return loClient.getClientNames(pDisplayType, pSearchString);
        }

        [HttpGet]
        public DataTable getClientLists()
        {
            return loClient.getClientLists();
        }

        [HttpPost]
        public string insertClient([FromBody]Client pClient)
        {
            return loClient.insertClient(pClient);
        }

        [HttpPost]
        public string updateClient([FromBody]Client pClient)
        {
            return loClient.updateClient(pClient);
        }

        [HttpGet]
        public bool removeClient(string pId, string pUserId)
        {
            return loClient.removeClient(pId, pUserId);
        }
        #endregion

        #region "Client Family Member"
        [HttpGet]
        public DataTable getClientFamilyMembers(string pClientId, string pPrimaryKey)
        {
            return loClientFamilyMember.getClientFamilyMembers(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientFamilyMember([FromBody]ClientFamilyMember pClientFamilyMember)
        {
            return loClientFamilyMember.insertClientFamilyMember(pClientFamilyMember);
        }

        [HttpPost]
        public string updateClientFamilyMember([FromBody]ClientFamilyMember pClientFamilyMember)
        {
            return loClientFamilyMember.updateClientFamilyMember(pClientFamilyMember);
        }

        [HttpGet]
        public bool removeClientFamilyMember(string pId, string pUserId)
        {
            return loClientFamilyMember.removeClientFamilyMember(pId, pUserId);
        }
        #endregion

        #region "Client Personal Reference"
        [HttpGet]
        public DataTable getClientPersonalReferences(string pClientId, string pPrimaryKey)
        {
            return loClientPersonalReference.getClientPersonalReferences(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientPersonalReference([FromBody]ClientPersonalReference pClientPersonalReference)
        {
            return loClientPersonalReference.insertClientPersonalReference(pClientPersonalReference);
        }

        [HttpPost]
        public string updateClientPersonalReference([FromBody]ClientPersonalReference pClientPersonalReference)
        {
            return loClientPersonalReference.updateClientPersonalReference(pClientPersonalReference);
        }

        [HttpGet]
        public bool removeClientPersonalReference(string pId, string pUserId)
        {
            return loClientPersonalReference.removeClientPersonalReference(pId, pUserId);
        }
        #endregion

        #region "Client Source Of Income"
        [HttpGet]
        public DataTable getClientSourceOfIncomes(string pClientId, string pPrimaryKey)
        {
            return loClientSourceOfIncome.getClientSourceOfIncomes(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientSourceOfIncome([FromBody]ClientSourceOfIncome pClientSourceOfIncome)
        {
            return loClientSourceOfIncome.insertClientSourceOfIncome(pClientSourceOfIncome);
        }

        [HttpPost]
        public string updateClientSourceOfIncome([FromBody]ClientSourceOfIncome pClientSourceOfIncome)
        {
            return loClientSourceOfIncome.updateClientSourceOfIncome(pClientSourceOfIncome);
        }

        [HttpGet]
        public bool removeClientSourceOfIncome(string pId, string pUserId)
        {
            return loClientSourceOfIncome.removeClientSourceOfIncome(pId, pUserId);
        }
        #endregion

        #region "Client Owned Property"
        [HttpGet]
        public DataTable getClientOwnedPropertys(string pClientId, string pPrimaryKey)
        {
            return loClientOwnedProperty.getClientOwnedPropertys(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientOwnedProperty([FromBody]ClientOwnedProperty pClientOwnedProperty)
        {
            return loClientOwnedProperty.insertClientOwnedProperty(pClientOwnedProperty);
        }

        [HttpPost]
        public string updateClientOwnedProperty([FromBody]ClientOwnedProperty pClientOwnedProperty)
        {
            return loClientOwnedProperty.updateClientOwnedProperty(pClientOwnedProperty);
        }

        [HttpGet]
        public bool removeClientOwnedProperty(string pId, string pUserId)
        {
            return loClientOwnedProperty.removeClientOwnedProperty(pId, pUserId);
        }
        #endregion

        #region "Client Credit Experience"
        [HttpGet]
        public DataTable getClientCreditExperiences(string pClientId, string pPrimaryKey)
        {
            return loClientCreditExperience.getClientCreditExperiences(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientCreditExperience([FromBody]ClientCreditExperience pClientCreditExperience)
        {
            return loClientCreditExperience.insertClientCreditExperience(pClientCreditExperience);
        }

        [HttpPost]
        public string updateClientCreditExperience([FromBody]ClientCreditExperience pClientCreditExperience)
        {
            return loClientCreditExperience.updateClientCreditExperience(pClientCreditExperience);
        }

        [HttpGet]
        public bool removeClientCreditExperience(string pId, string pUserId)
        {
            return loClientCreditExperience.removeClientCreditExperience(pId, pUserId);
        }
        #endregion

        #region "Area"
        [HttpGet]
        public DataTable getAreas(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loArea.getAreas(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertArea([FromBody]Area pArea)
        {
            return loArea.insertArea(pArea);
        }

        [HttpPost]
        public string updateArea([FromBody]Area pArea)
        {
            return loArea.updateArea(pArea);
        }

        [HttpGet]
        public bool removeArea(string pId, string pUserId)
        {
            return loArea.removeArea(pId, pUserId);
        }
        #endregion ""

        #region "Branch"
        [HttpGet]
        public DataTable getBranchs(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loBranch.getBranchs(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertBranch([FromBody]Branch pBranch)
        {
            return loBranch.insertBranch(pBranch);
        }

        [HttpPost]
        public string updateBranch([FromBody]Branch pBranch)
        {
            return loBranch.updateBranch(pBranch);
        }

        [HttpGet]
        public bool removeBranch(string pId, string pUserId)
        {
            return loBranch.removeBranch(pId, pUserId);
        }
        #endregion ""

        #region "Zone"
        [HttpGet]
        public DataTable getZones(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loZone.getZones(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertZone([FromBody]Zone pZone)
        {
            return loZone.insertZone(pZone);
        }

        [HttpPost]
        public string updateZone([FromBody]Zone pZone)
        {
            return loZone.updateZone(pZone);
        }

        [HttpGet]
        public bool removeZone(string pId, string pUserId)
        {
            return loZone.removeZone(pId, pUserId);
        }
        #endregion ""

        #region "Collector"
        [HttpGet]
        public DataTable getCollectors(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCollector.getCollectors(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertCollector([FromBody]Collector pCollector)
        {
            return loCollector.insertCollector(pCollector);
        }

        [HttpPost]
        public string updateCollector([FromBody]Collector pCollector)
        {
            return loCollector.updateCollector(pCollector);
        }

        [HttpGet]
        public bool removeCollector(string pId, string pUserId)
        {
            return loCollector.removeCollector(pId, pUserId);
        }
        #endregion ""

        #region "Product"
        [HttpGet]
        public DataTable getProducts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loProduct.getProducts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertProduct([FromBody]Product pProduct)
        {
            return loProduct.insertProduct(pProduct);
        }

        [HttpPost]
        public string updateProduct([FromBody]Product pProduct)
        {
            return loProduct.updateProduct(pProduct);
        }

        [HttpGet]
        public bool removeProduct(string pId, string pUserId)
        {
            return loProduct.removeProduct(pId, pUserId);
        }
        #endregion ""

        #region "Loan Application"
        [HttpGet]
        public DataTable getLoanApplications(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLoanApplication.getLoanApplications(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getLoanApplicationPastDueAccounts()
        {
            return loLoanApplication.getLoanApplicationPastDueAccounts();
        }

        [HttpGet]
        public DataTable getLoanApplicationByClient(string pClientId)
        {
            return loLoanApplication.getLoanApplicationByClient(pClientId);
        }

        [HttpGet]
        public DataTable getLoanApplicationByClientLedger(string pClientId)
        {
            return loLoanApplication.getLoanApplicationByClientLedger(pClientId);
        }

        [HttpGet]
        public DataTable getLoanApplicationStatus(string pLoanApplicationId)
        {
            return loLoanApplication.getLoanApplicationStatus(pLoanApplicationId);
        }

        [HttpGet]
        public DataTable getForReleaseSheet(DateTime pReleaseDate, string pCollectorId)
        {
            return loLoanApplication.getForReleaseSheet(pReleaseDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getMonthlyProjectionByBranch(string pBranchId)
        {
            return loLoanApplication.getMonthlyProjectionByBranch(pBranchId);
        }

        [HttpPost]
        public string insertLoanApplication([FromBody]LoanApplication pLoanApplication)
        {
            return loLoanApplication.insertLoanApplication(pLoanApplication);
        }

        [HttpPost]
        public string updateLoanApplication([FromBody]LoanApplication pLoanApplication)
        {
            return loLoanApplication.updateLoanApplication(pLoanApplication);
        }

        [HttpGet]
        public bool removeLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.removeLoanApplication(pId, pUserId);
        }

        [HttpGet]
        public bool approveLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.approveLoanApplication(pId, pUserId);
        }

        [HttpGet]
        public bool cancelLoanApplication(string pId, string pReason, string pUserId)
        {
            return loLoanApplication.cancelLoanApplication(pId, pReason, pUserId);
        }

        [HttpGet]
        public bool postLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.postLoanApplication(pId, pUserId);
        }
        #endregion ""

        #region "Loan Application Detail"
        [HttpGet]
        public DataTable getLoanApplicationDetails(string pLoanApplicationId)
        {
            return loLoanApplicationDetail.getLoanApplicationDetails(pLoanApplicationId);
        }

        [HttpGet]
        public DataTable getLoanApplicationDetail(string pDetailId)
        {
            return loLoanApplicationDetail.getLoanApplicationDetail(pDetailId);
        }

        [HttpGet]
        public DataTable getDailyCollectionSheet(DateTime pCollectionDate, string pCollectorId)
        {
            return loLoanApplicationDetail.getDailyCollectionSheet(pCollectionDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getUploadCollectionList(DateTime pCollectionDate, string pCollectorId)
        {
            return loLoanApplicationDetail.getUploadCollectionList(pCollectionDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getEODLoanApplicationDetail(DateTime pDate, string pBranchId)
        {
            return loLoanApplicationDetail.getEODLoanApplicationDetail(pDate, pBranchId);
        }

        [HttpGet]
        public DataTable getEODLoanApplicationDetailList(DateTime pDate, string pBranchId)
        {
            return loLoanApplicationDetail.getEODLoanApplicationDetailList(pDate, pBranchId);
        }

        [HttpPost]
        public bool insertLoanApplicationDetail([FromBody]LoanApplicationDetail pLoanApplicationDetail)
        {
            return loLoanApplicationDetail.insertLoanApplicationDetail(pLoanApplicationDetail);
        }

        [HttpPost]
        public bool updateLoanApplicationDetail([FromBody]LoanApplicationDetail pLoanApplicationDetail)
        {
            return loLoanApplicationDetail.updateLoanApplicationDetail(pLoanApplicationDetail);
        }

        [HttpGet]
        public bool removeLoanApplicationDetail(string pDetailId, string pUserId)
        {
            return loLoanApplicationDetail.removeLoanApplicationDetail(pDetailId, pUserId);
        }

        [HttpGet]
        public bool updatePayment(string pDetailId, decimal pPayment, decimal pNewBalance, decimal pVariance,
            string pPastDueReason, string pRemarks,string pCollectorId, string pUserId)
        {
            return loLoanApplicationDetail.updatePayment(pDetailId, pPayment, pNewBalance, pVariance, pPastDueReason, pRemarks,pCollectorId, pUserId);
        }

        [HttpGet]
        public bool updateEODLoanTransactionDetail(string pDetailId, string pEODId, string pUserId)
        {
            return loLoanApplicationDetail.updateEODLoanTransactionDetail(pDetailId, pEODId, pUserId);
        }
        #endregion ""

        #region "Loan End of Day"
        [HttpGet]
        public DataTable getLoanEndOfDays(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLoanEndOfDay.getLoanEndOfDays(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getLoanEndOfDayByBranch(string pBranchId)
        {
            return loLoanEndOfDay.getLoanEndOfDayByBranch(pBranchId);
        }

        [HttpGet]
        public DataTable getMonthlyCollections(string pYear, string pBranchId)
        {
            return loLoanEndOfDay.getMonthlyCollections(pYear, pBranchId);
        }
        
        [HttpPost]
        public string insertLoanEndOfDay([FromBody]LoanEndOfDay pLoanEndOfDay)
        {
            return loLoanEndOfDay.insertLoanEndOfDay(pLoanEndOfDay);
        }

        [HttpPost]
        public string updateLoanEndOfDay([FromBody]LoanEndOfDay pLoanEndOfDay)
        {
            return loLoanEndOfDay.updateLoanEndOfDay(pLoanEndOfDay);
        }

        [HttpGet]
        public bool removeLoanEndOfDay(string pId, string pUserId)
        {
            return loLoanEndOfDay.removeLoanEndOfDay(pId, pUserId);
        }
        #endregion ""

        #region "Loan End of Day Detail"
        [HttpGet]
        public DataTable getLoanEndOfDayDetails(string pLoanEndOfDayId)
        {
            return loLoanEndOfDayDetail.getLoanEndOfDayDetails(pLoanEndOfDayId);
        }

        [HttpPost]
        public bool insertLoanEndOfDayDetail([FromBody]LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            return loLoanEndOfDayDetail.insertLoanEndOfDayDetail(pLoanEndOfDayDetail);
        }

        [HttpPost]
        public bool updateLoanEndOfDayDetail([FromBody]LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            return loLoanEndOfDayDetail.updateLoanEndOfDayDetail(pLoanEndOfDayDetail);
        }

        [HttpGet]
        public bool removeLoanEndOfDayDetail(string pDetailId, string pUserId)
        {
            return loLoanEndOfDayDetail.removeLoanEndOfDayDetail(pDetailId, pUserId);
        }
        #endregion ""

        #endregion

        #region "SYSTEMS"
        #region "Users"
        [HttpGet]
        public DataTable authenticateUser(string pUsername, string pPassword)
        {
            if (pPassword == null)
            {
                pPassword = "";
            }
            return loUser.authenticateUser(pUsername, pPassword);
        }

        [HttpGet]
        public DataTable getUsers(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUser.getUsers(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public bool checkUserPassword(string pUserId, string pCurrentPassword)
        {
            return loUser.checkUserPassword(pUserId, pCurrentPassword);
        }

        [HttpGet]
        public bool changePassword(string pUserId,string pNewPassword)
        {
            return loUser.changePassword(pUserId, pNewPassword);
        }

        [HttpPost]
        public string insertUser([FromBody]User pUser)
        {
            return loUser.insertUser(pUser);
        }

        [HttpPost]
        public string updateUser([FromBody]User pUser)
        {
            return loUser.updateUser(pUser);
        }

        [HttpGet]
        public bool removeUser(string pId,string pUserId)
        {
            return loUser.removeUser(pId, pUserId);
        }
        #endregion ""

        #region "User Groups"
        [HttpGet]
        public DataTable getUserGroups(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUserGroup.getUserGroups(pDisplayType,pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertUserGroup([FromBody]UserGroup pUserGroup)
        {
            return loUserGroup.insertUserGroup(pUserGroup);
        }

        [HttpPost]
        public string updateUserGroup([FromBody]UserGroup pUserGroup)
        {
            return loUserGroup.updateUserGroup(pUserGroup);
        }

        [HttpGet]
        public bool removeUserGroup(string pId, string pUserId)
        {
            return loUserGroup.removeUserGroup(pId, pUserId);
        }

        [HttpGet]
        public bool removeAllUserGroup(string pUserGroupId)
        {
            return loUserGroup.removeAllUserGroup(pUserGroupId);
        }

        [HttpGet]
        public bool updateUserGroupMenuItems(string pUserGroupId, string pMenuItem, string pItemName)
        {
            return loUserGroup.updateUserGroupMenuItems(pUserGroupId, pMenuItem, pItemName);
        }

        [HttpGet]
        public bool removeAllRights(string pUserGroupId, string pItemName)
        {
            return loUserGroup.removeAllRights(pUserGroupId, pItemName);
        }

        [HttpGet]
        public bool updateUserGroupRights(string pUserGroupId, string pItemName, string pRights)
        {
            return loUserGroup.updateUserGroupRights(pUserGroupId, pItemName, pRights);
        }
        #endregion ""

        #region "System Configurations"
        [HttpGet]
        public DataTable getSystemConfigurations()
        {
            return loSystemConfigurations.getSystemConfigurations();
        }

        [HttpPost]
        public bool updateSystemConfiguration([FromBody]SystemConfiguration pSystemConfiguration)
        {
            return loSystemConfigurations.updateSystemConfiguration(pSystemConfiguration);
        }
        #endregion ""

        #region "Audit Trail"
        [HttpGet]
        public DataTable getAuditTrailByDate(DateTime pFrom, DateTime pTo)
        {
            return loAuditTrail.getAuditTrailByDate(pFrom, pTo);
        }

        [HttpGet]
        public bool removeAuditTrail(DateTime pFrom, DateTime pTo)
        {
            return loAuditTrail.removeAuditTrail(pFrom, pTo);
        }
        #endregion ""

        #region "Backup / Restore Database"
        [HttpGet]
        public bool backupDatabase(string pSaveFileTo, string pBackupMySqlDumpAddress,
            string pUserId, string pPassword, string pServer, string pDatabase)
        {
            return loCommon.backupDatabase(pSaveFileTo, pBackupMySqlDumpAddress, pUserId, pPassword, pServer, pDatabase);
        }

        [HttpGet]
        public bool restoreDatabase(string pSQLFileFrom, string pRestoreMySqlAddress,
            string pUserId, string pPassword, string pServer, string pDatabase)
        {
            return loCommon.restoreDatabase(pSQLFileFrom, pRestoreMySqlAddress, pUserId, pPassword, pServer, pDatabase);
        }

        #endregion ""

        #endregion
    }
}
