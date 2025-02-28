﻿using FikaAmazonAPI.Search;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    public class ParameterGetListingOffers : ParameterBased
    {
        public string MarketplaceId { get; set; }
        public string SellerSKU { get; set; }
        public CustomerType? CustomerType { get; set; }
        public ItemCondition ItemCondition { get; set; }
    }
}
