﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing;
using FikaAmazonAPI.Parameter.ProductPricing;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ProductPricingService : RequestService
    {
        public ProductPricingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<Price> GetPricing(ParameterGetPricing parameterGetPricing) =>
            GetPricingAsync(parameterGetPricing).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<IList<Price>> GetPricingAsync(ParameterGetPricing parameterGetPricing)
        {
            var param = parameterGetPricing.getParameters();

            await CreateAuthorizedRequestAsync(ProductPricingApiUrls.GetPricing, RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<GetPricingResponse>(RateLimitType.ProductPricing_GetPricing);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public IList<Price> GetCompetitivePricing(ParameterGetCompetitivePricing parameterGetCompetitivePricing) =>
            GetCompetitivePricingAsync(parameterGetCompetitivePricing).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<IList<Price>> GetCompetitivePricingAsync(ParameterGetCompetitivePricing parameterGetCompetitivePricing)
        {
            var param = parameterGetCompetitivePricing.getParameters();

            await CreateAuthorizedRequestAsync(ProductPricingApiUrls.GetCompetitivePricing, RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<GetPricingResponse>(RateLimitType.ProductPricing_GetCompetitivePricing);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetOffersResult GetListingOffers(ParameterGetListingOffers parameterGetListingOffers) =>
            GetListingOffersAsync(parameterGetListingOffers).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetOffersResult> GetListingOffersAsync(ParameterGetListingOffers parameterGetListingOffers)
        {
            var param = parameterGetListingOffers.getParameters();

            await CreateAuthorizedRequestAsync(ProductPricingApiUrls.GetListingOffers(parameterGetListingOffers.SellerSKU), RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<GetOffersResponse>(RateLimitType.ProductPricing_GetListingOffers);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetOffersResult GetItemOffers(ParameterGetItemOffers parameterGetItemOffers) =>
            GetItemOffersAsync(parameterGetItemOffers).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetOffersResult> GetItemOffersAsync(ParameterGetItemOffers parameterGetItemOffers)
        {
            var param = parameterGetItemOffers.getParameters();

            await CreateAuthorizedRequestAsync(ProductPricingApiUrls.GetItemOffers(parameterGetItemOffers.Asin), RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<GetOffersResponse>(RateLimitType.ProductPricing_GetItemOffers);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

    }
}
