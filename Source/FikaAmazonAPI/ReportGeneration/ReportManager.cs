﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReportManager
    {
        private const int DAY_30 = 30;
        private const int DAY_60 = 60;
        private const int DAY_90 = 90;
        private AmazonConnection _amazonConnection { get; set; }
        public ReportManager(AmazonConnection amazonConnection)
        {
            _amazonConnection = amazonConnection;
        }

        #region feedback
        public List<FeedbackOrderRow> GetFeedbackFromDays(int days) =>
            GetFeedbackFromDaysAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<FeedbackOrderRow>> GetFeedbackFromDaysAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetFeedbackFromDateAsync(fromDate, toDate);
        }
        public async Task<List<FeedbackOrderRow>> GetFeedbackFromDateAsync(DateTime fromDate, DateTime toDate)
        {
            var path = await GetFeedbackFromDateAsync(_amazonConnection, fromDate, toDate);
            FeedbackOrderReport report = new FeedbackOrderReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }
        private async Task<string> GetFeedbackFromDateAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_SELLER_FEEDBACK_DATA, fromDate);
        }

        #endregion

        #region Performance
        #endregion

        #region Reimbursement
        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(int days) =>
            GetReimbursementsOrderAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<IList<ReimbursementsOrderRow>> GetReimbursementsOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetReimbursementsOrderAsync(fromDate, toDate);
        }
        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(DateTime fromDate, DateTime toDate) =>
            GetReimbursementsOrderAsync(fromDate, toDate).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<IList<ReimbursementsOrderRow>> GetReimbursementsOrderAsync(DateTime fromDate, DateTime toDate)
        {
            var path = await GetReimbursementsOrderAsync(_amazonConnection, fromDate, toDate);
            ReimbursementsOrderReport report = new ReimbursementsOrderReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetReimbursementsOrderAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, fromDate, toDate);
        }
        #endregion

        #region ReturnFBAOrder
        public List<ReturnFBAOrderRow> GetReturnFBAOrder(int days) =>
            GetReturnFBAOrderAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<ReturnFBAOrderRow>> GetReturnFBAOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetReturnFBAOrderAsync(fromDate, toDate);
        }

        public List<ReturnFBAOrderRow> GetReturnFBAOrder(DateTime fromDate, DateTime toDate) =>
            GetReturnFBAOrderAsync(fromDate, toDate).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<ReturnFBAOrderRow>> GetReturnFBAOrderAsync(DateTime fromDate, DateTime toDate)
        {
            var path = await GetReturnFBAOrderAsync(_amazonConnection, fromDate, toDate);
            ReturnFBAOrderReport report = new ReturnFBAOrderReport(path, _amazonConnection.RefNumber);

            return report.Data;
        }

        private async Task<string> GetReturnFBAOrderAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBMOrder
        public List<ReturnFBMOrderRow> GetReturnMFNOrder(int days) =>
            GetReturnMFNOrderAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<ReturnFBMOrderRow>> GetReturnMFNOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetReturnMFNOrderAsync(fromDate, toDate);
        }
        public List<ReturnFBMOrderRow> GetReturnMFNOrder(DateTime fromDate, DateTime toDate) =>
            GetReturnMFNOrderAsync(fromDate, toDate).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<ReturnFBMOrderRow>> GetReturnMFNOrderAsync(DateTime fromDate, DateTime toDate)
        {
            List<ReturnFBMOrderRow> list = new List<ReturnFBMOrderRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_60);
            foreach (var date in dateList)
            {
                var path = await GetReturnMFNOrderAsync(_amazonConnection, date.StartDate, date.EndDate);

                ReturnFBMOrderReport report = new ReturnFBMOrderReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private async Task<string> GetReturnMFNOrderAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE, fromDate, toDate);
        }
        #endregion

        #region Settlement
        public List<SettlementOrderRow> GetSettlementOrder(int days) =>
            GetSettlementOrderAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<SettlementOrderRow>> GetSettlementOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetSettlementOrderAsync(fromDate, toDate);
        }
        public async Task<List<SettlementOrderRow>> GetSettlementOrderAsync(DateTime fromDate, DateTime toDate)
        {
            List<SettlementOrderRow> list = new List<SettlementOrderRow>();
            var totalDays = (DateTime.UtcNow - fromDate).TotalDays;
            if (totalDays > 90)
                fromDate = DateTime.UtcNow.AddDays(-90);

            var paths = await GetSettlementOrderAsync(_amazonConnection, fromDate, toDate);
            foreach (var path in paths)
            {
                SettlementOrderReport report = new SettlementOrderReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }
        private async Task<IList<string>> GetSettlementOrderAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.DownloadExistingReportAndDownloadFileAsync(ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2, fromDate, toDate);
        }
        #endregion

        #region GetInventoryQty
        public void GetInventoryQty()
        {
            //var path = GetInventoryQty(_amazonConnections);
            throw new Exception("Report not finished");
        }
        private string GetInventoryQty(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_AFN_INVENTORY_DATA);
        }
        #endregion

        #region GetInventoryAging
        public List<InventoryAgingRow> GetInventoryAging() =>
            GetInventoryAgingAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<InventoryAgingRow>> GetInventoryAgingAsync()
        {
            var path = await GetInventoryAgingAsync(_amazonConnection);
            InventoryAgingReport report = new InventoryAgingReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }
        private async Task<string> GetInventoryAgingAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_FBA_INVENTORY_AGED_DATA);
        }
        #endregion

        #region Products
        public List<ProductsRow> GetProducts() =>
            GetProductsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<ProductsRow>> GetProductsAsync()
        {
            var path = await GetProductsAsync(_amazonConnection);
            ProductsReport report = new ProductsReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }
        private async Task<string> GetProductsAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA);
        }
        #endregion

        #region Orders
        public List<OrdersRow> GetOrdersByLastUpdate(int days) =>
            GetOrdersByLastUpdateAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<OrdersRow>> GetOrdersByLastUpdateAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetOrdersByLastUpdateAsync(fromDate, toDate);
        }
        public async Task<List<OrdersRow>> GetOrdersByLastUpdateAsync(DateTime fromDate, DateTime toDate)
        {
            List<OrdersRow> list = new List<OrdersRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_30);
            foreach (var range in dateList)
            {
                var path = await GetOrdersByLastUpdateAsync(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private async Task<string> GetOrdersByLastUpdateAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL, fromDate, toDate);
        }

        public List<OrdersRow> GetOrdersByOrderDate(int days) =>
            GetOrdersByOrderDateAsync(days).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<OrdersRow>> GetOrdersByOrderDateAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetOrdersByOrderDateAsync(fromDate, toDate);
        }
        public List<OrdersRow> GetOrdersByOrderDate(DateTime fromDate, DateTime toDate) =>
            GetOrdersByOrderDateAsync(fromDate, toDate).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<OrdersRow>> GetOrdersByOrderDateAsync(DateTime fromDate, DateTime toDate)
        {
            List<OrdersRow> list = new List<OrdersRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_30);
            foreach (var range in dateList)
            {
                var path = await GetOrdersByOrderDateAsync(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private async Task<string> GetOrdersByOrderDateAsync(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL, fromDate, toDate);
        }
        #endregion




    }


}
