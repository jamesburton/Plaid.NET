using Acklann.Plaid.MSTest.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace Acklann.Plaid.MSTest.Tests
{
    [TestClass]
    //[UseReporter(typeof(FileLauncherReporter))]
    public class PlaidClientTest
    {
        [TestMethod]
        public void GetItemAsync_should_retrieve_the_item_associated_with_the_specified_access_token()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Management.GetItemRequest().UseDefaults();

            // Act
            var result = sut.FetchItemAsync(request).Result;

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Item.Id.ShouldNotBeNullOrEmpty();
            result.Item.InstitutionId.ShouldNotBeNullOrEmpty();
            result.Item.BilledProducts.Length.ShouldBeGreaterThan(0);
            result.Item.AvailableProducts.Length.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void ExchangePublicTokenAsync_should_retrieve_a_response_from_the_api_server()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);

            // Act
            var request = new Management.ExchangeTokenRequest()
            {
                PublicToken = "public-sandbox-5c224a01-8314-4491-a06f-39e193d5cddc"
            }.UseDefaults();
            var result = sut.ExchangeTokenAsync(request).Result;

            // Assert
            result.Exception.ShouldNotBeNull();
            result.IsSuccessStatusCode.ShouldBeFalse();
        }

        [TestMethod]
        public void FetchCategoriesAsync_should_retrieve_the_api_category_list()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Category.GetCategoriesRequest().UseDefaults();

            // Act
            var result = sut.FetchCategoriesAsync(request).Result;

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Categories.Length.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void FetchInstitutionsAsync_should_retrieve_a_list_of_banks_that_matches_a_specified_query()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);

            // Act
            var request = new Institution.SearchRequest()
            {
                Query = "tartan"
            }.UseDefaults();

            var result = sut.FetchInstitutionsAsync(request).Result;

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Institutions.Length.ShouldBeGreaterThanOrEqualTo(1);
            result.Institutions.ShouldAllBe(i => i.Name.IndexOf(request.Query, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [TestMethod]
        public void FetchInstitutionByIdAsync_should_retrieve_a_bank_that_matches_a_specified_id()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);

            // Act
            var request = new Institution.SearchByIdRequest()
            {
                InstitutionId = "ins_109511"
            }.UseDefaults();
            var response = sut.FetchInstitutionByIdAsync(request).Result;

            // Assert
            response.IsSuccessStatusCode.ShouldBeTrue();
            response.RequestId.ShouldNotBeNullOrEmpty();
            response.Institution.Id.ShouldBe(request.InstitutionId);
        }

        [TestMethod]
        public void FetchTransactionsAsync_should_retrieve_a_list_of_transactions()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);

            // Act
            var request = new Transactions.GetTransactionsRequest().UseDefaults();
            var result = sut.FetchTransactionsAsync(request).Result;

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.TransactionsReturned.ShouldBeGreaterThan(0);
            result.Transactions.Length.ShouldBeGreaterThan(0);
            result.Transactions[0].Amount.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void FetchAccountBalanceAsync_should_retrieve_the_account_balances_of_an_user()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);

            // Act
            var request = new Balance.GetBalanceRequest().UseDefaults();
            var result = sut.FetchAccountBalanceAsync(request).Result;

            // Assert
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Accounts.Length.ShouldBeGreaterThanOrEqualTo(1);
            result.Accounts[0].Balance.Current.ShouldBeGreaterThanOrEqualTo(1);
        }

        [TestMethod]
        public void FetchAccountInfoAsync_should_retrieve_the_routing_numbers_of_an_user_accounts()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Auth.GetAccountInfoRequest().UseDefaults();

            // Act
            var result = sut.FetchAccountInfoAsync(request).Result;

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Accounts.Length.ShouldBeGreaterThan(0);
            //result.Numbers.Length.ShouldBeGreaterThan(0);
            result.Item.ShouldNotBeNull();
        }

        [TestMethod]
        public void FetchUserIdentityAsync_should_retrieve_the_personal_info_of_an_user()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Identity.GetUserIdentityRequest().UseDefaults();

            // Act
            var result = sut.FetchUserIdentityAsync(request).Result;
            bool publicKeyDontHaveAccess = result.Exception.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Accounts.Length.ShouldBeGreaterThan(0);
            result.Identity.Names.Length.ShouldBeGreaterThan(0);
            result.Item.ShouldNotBeNull();
        }

        [TestMethod]
        public void FetchIncomeAsync_should_retrieve_the_monthly_earnings_of_an_user()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Income.GetIncomeRequest().UseDefaults();

            // Act
            var result = sut.FetchUserIncomeAsync(request).Result;
            bool publicKeyDontHaveAccess = result.Exception.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Income.Streams.Length.ShouldBeGreaterThan(0);
            result.Income.LastYearIncome.ShouldBeGreaterThan(0);
            result.Item.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task CreateAssetReportAsync_should_return_an_asset_report_token()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.CreateAssetReportRequest("access-sandbox-1cdbd094-a2c3-42a1-a6a0-6f911c20710a").UseDefaults();

            // Act
            var result = await sut.CreateAssetReportAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert
#if DEBUG
            var requestJson = JsonConvert.SerializeObject(request);
            var responseJson = result.RawJsonForDebugging;
#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.AssetReportId.ShouldNotBeNullOrEmpty();
            result.AssetReportToken.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetAssetReportAsync_should_return_an_asset_report()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.GetAssetReportRequest("assets-sandbox-2ba2d788-a321-4b5d-b26e-45e8af3b34c8").UseDefaults();

            // Act
            var result = await sut.GetAssetReportAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert 
            //#if DEBUG
            //            var requestJson = JsonConvert.SerializeObject(request);
            //            var responseJson = result.RawJsonForDebugging;
            //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
            //#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Report.ShouldNotBeNull();
            result.Report.AssetReportId.ShouldNotBeNullOrEmpty();
            //result.Report.ClientReportId.ShouldNotBeNullOrEmpty(); // NB: This is empty in the sandbox report
            result.Report.DateGenerated.ShouldBe(DateTime.Parse("2020-01-06 12:00"), TimeSpan.FromHours(12));
            result.Report.DaysRequested.ShouldBe(730);
            result.Report.Items.ShouldNotBeNull();
            result.Report.Items.ShouldNotBeEmpty();
            //result.Report.Items[0].Accounts[0].DaysAvailable.ShouldBe(730); // NB: Actually only 90 are available in sandbox report
            //result.Report.Items[0].Accounts[0].HistoricalBalances.Length.ShouldBe(730); // NB: Actually 0 were returned in sandbox report
        }

        [TestMethod]
        public async Task GetAssetReportPdfAsync_should_return_a_pdf_stream()
        {
            // Arrange
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.GetAssetReportPdfRequest("assets-sandbox-2ba2d788-a321-4b5d-b26e-45e8af3b34c8").UseDefaults();

            // Act
            using (var result = await sut.GetAssetReportPdfAsync(request).ConfigureAwait(false))
            {
                bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
                if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);
                long outputSize = 0;
                if (result.ResponseStream != null) outputSize = await result.ResponseStream.SaveToFile(@"c:\AssetReportExampleFromSandbox.pdf").ConfigureAwait(false);

                // Assert 
                //#if DEBUG
                //            var requestJson = JsonConvert.SerializeObject(request);
                //            var responseJson = result.RawJsonForDebugging;
                //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
                //#endif
                result.IsSuccessStatusCode.ShouldBeTrue();
                result.RequestId.ShouldNotBeNullOrEmpty(); // NB: Binary stream responses
                result.ResponseStream.ShouldNotBeNull();
                result.ResponseStream.Length.ShouldBeGreaterThanOrEqualTo(1000);
                outputSize.ShouldNotBe(0);
            }
        }

        [TestMethod]
        public async Task RefreshAssetReportAsync_should_return_an_new_asset_report_id()
        {
            // Arrange
            const string sourceAssetToken = "assets-sandbox-2ba2d788-a321-4b5d-b26e-45e8af3b34c8";
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.RefreshAssetReportRequest(sourceAssetToken).UseDefaults();

            // Act
            var result = await sut.RefreshAssetReportAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert 
            //#if DEBUG
            //            var requestJson = JsonConvert.SerializeObject(request);
            //            var responseJson = result.RawJsonForDebugging;
            //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
            //#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.AssetReportId.ShouldNotBeNullOrEmpty();
            result.AssetReportToken.ShouldNotBeNullOrEmpty();
            result.AssetReportToken.ShouldNotBeSameAs(sourceAssetToken);
        }

        [TestMethod]
        public async Task FilterAssetReportAsync_should_return_an_new_asset_report_id()
        {
            // Arrange
            const string sourceAssetToken = "assets-sandbox-2ba2d788-a321-4b5d-b26e-45e8af3b34c8"; // This is the asset-report token for the source to be filtered to create the new report
            const string accountIdToFilter = "GDP5wlKdWvux4WgegDe5f3L4drkJeac1B3oa5"; // This is the account id to exclude from the report
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.FilterAssetReportRequest(sourceAssetToken, accountIdToFilter).UseDefaults();

            // Act
            var result = await sut.FilterAssetReportAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert 
            //#if DEBUG
            //            var requestJson = JsonConvert.SerializeObject(request);
            //            var responseJson = result.RawJsonForDebugging;
            //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
            //#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.AssetReportId.ShouldNotBeNullOrEmpty();
            result.AssetReportToken.ShouldNotBeNullOrEmpty();
            result.AssetReportToken.ShouldNotBeSameAs(sourceAssetToken);
        }

        [TestMethod]
        public async Task RemoveAssetReportAsync_should_return_confirmation()
        {
            // Arrange
            const string sourceAssetToken = "assets-sandbox-32781293-02b0-4594-9567-1963078978de"; // This is the asset-report token for the asset-report to be removed.
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.RemoveAssetReportRequest(sourceAssetToken).UseDefaults();

            // Act
            var result = await sut.RemoveAssetReportAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert 
            //#if DEBUG
            //            var requestJson = JsonConvert.SerializeObject(request);
            //            var responseJson = result.RawJsonForDebugging;
            //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
            //#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Removed.ShouldBeTrue();
        }

        [TestMethod]
        public async Task CreateAssetReportAuditCopyAsync_should_return_an_new_asset_report_audit_copy()
        {
            // Arrange
            const string sourceAssetToken = "assets-sandbox-2ba2d788-a321-4b5d-b26e-45e8af3b34c8"; // This is the asset-report token for the source to be copied for the auditor.
            const string auditorId = "fannie_mae"; // This is the auditor's id to identify who can access this audit-copy.
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.CreateAssetReportAuditCopyRequest(sourceAssetToken, auditorId).UseDefaults();

            // Act
            var result = await sut.CreateAssetReportAuditCopyAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert 
            //#if DEBUG
            //            var requestJson = JsonConvert.SerializeObject(request);
            //            var responseJson = result.RawJsonForDebugging;
            //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
            //#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.AuditCopyToken.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task RemoveAssetReportAuditCopyAsync_should_return_confirmation()
        {
            // Arrange
            const string sourceAuditCopyToken = "a-sandbox-wkhidfibqbhbbeazvopvlv4ptu"; // This is the audit-copy token for the asset-report-audit-copy to be removed.
            var sut = new PlaidClient(Environment.Sandbox);
            var request = new Asset.RemoveAssetReportAuditCopyRequest(sourceAuditCopyToken).UseDefaults();

            // Act
            var result = await sut.RemoveAssetReportAuditCopyAsync(request).ConfigureAwait(false);
            bool publicKeyDontHaveAccess = result.Exception?.ErrorCode == "INVALID_PRODUCT";
            if (publicKeyDontHaveAccess) Assert.Inconclusive(Helper.your_public_key_do_not_have_access_contact_plaid);

            // Assert 
            //#if DEBUG
            //            var requestJson = JsonConvert.SerializeObject(request);
            //            var responseJson = result.RawJsonForDebugging;
            //            System.IO.File.WriteAllText(@"ExamplePlaidAssetReportResponse.json", responseJson);
            //#endif
            result.IsSuccessStatusCode.ShouldBeTrue();
            result.RequestId.ShouldNotBeNullOrEmpty();
            result.Removed.ShouldBeTrue();
        }
    }
}