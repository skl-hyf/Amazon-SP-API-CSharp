﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaSmallandLight;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FbaSmallandLightService : RequestService
    {

        public FbaSmallandLightService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public SmallAndLightEnrollment GetSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            GetSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEnrollment> GetSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.GET);

            var response = await ExecuteRequestAsync<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_GetSmallAndLightEnrollmentBySellerSKU);

            return response;

        }

        public SmallAndLightEnrollment PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            PutSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEnrollment> PutSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.PutSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.PUT, queryParameters);

            var response = await ExecuteRequestAsync<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_PutSmallAndLightEnrollmentBySellerSKU);

            return response;

        }

        public bool DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            DeleteSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> DeleteSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.DeleteSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.DELETE, queryParameters);

            var response = await ExecuteRequestAsync<object>(RateLimitType.FbaSmallandLight_DeleteSmallAndLightEnrollmentBySellerSKU);

            return true;

        }

        public SmallAndLightEligibility GetSmallAndLightEligibilityBySellerSKU(string sellerSKU) =>
            GetSmallAndLightEligibilityBySellerSKUAsync(sellerSKU).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEligibility> GetSmallAndLightEligibilityBySellerSKUAsync(string sellerSKU)
        {

            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightEligibilityBySellerSKU(sellerSKU), RestSharp.Method.GET, queryParameters);

            var response = await ExecuteRequestAsync<SmallAndLightEligibility>(RateLimitType.FbaSmallandLight_GetSmallAndLightEligibilityBySellerSKU);

            return response;

        }

        public List<FeePreview> GetSmallAndLightFeePreview(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest) =>
            GetSmallAndLightFeePreviewAsync(smallAndLightFeePreviewRequest).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<FeePreview>> GetSmallAndLightFeePreviewAsync(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightFeePreview, RestSharp.Method.POST, postJsonObj: smallAndLightFeePreviewRequest);

            var response = await ExecuteRequestAsync<SmallAndLightFeePreviews>(RateLimitType.FbaSmallandLight_GetSmallAndLightFeePreview);
            if (response != null && response.Data != null)
                return response.Data;

            return null;

        }
    }
}
