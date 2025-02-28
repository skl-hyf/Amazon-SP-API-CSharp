/* 
 * Selling Partner API for Pricing
 *
 * The Selling Partner API for Pricing helps you programmatically retrieve product pricing and offer information for Amazon Marketplace products.
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing
{
    /// <summary>
    /// Contains price information about the product, including the LowestPrices and BuyBoxPrices, the ListPrice, the SuggestedLowerPricePlusShipping, and NumberOfOffers and NumberOfBuyBoxEligibleOffers.
    /// </summary>
    [DataContract]
    public partial class Summary : IEquatable<Summary>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Summary" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Summary() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Summary" /> class.
        /// </summary>
        /// <param name="TotalOfferCount">The number of unique offers contained in NumberOfOffers. (required).</param>
        /// <param name="NumberOfOffers">A list that contains the total number of offers for the item for the given conditions and fulfillment channels..</param>
        /// <param name="LowestPrices">A list of the lowest prices for the item..</param>
        /// <param name="BuyBoxPrices">A list of item prices..</param>
        /// <param name="ListPrice">The list price of the item as suggested by the manufacturer..</param>
        /// <param name="SuggestedLowerPricePlusShipping">The suggested lower price of the item, including shipping and Amazon Points. The suggested lower price is based on a range of factors, including historical selling prices, recent Buy Box-eligible prices, and input from customers for your products..</param>
        /// <param name="BuyBoxEligibleOffers">A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels..</param>
        /// <param name="OffersAvailableTime">When the status is ActiveButTooSoonForProcessing, this is the time when the offers will be available for processing..</param>
        public Summary(int? TotalOfferCount = default(int?), NumberOfOffers NumberOfOffers = default(NumberOfOffers), LowestPrices LowestPrices = default(LowestPrices), BuyBoxPrices BuyBoxPrices = default(BuyBoxPrices), MoneyType ListPrice = default(MoneyType), MoneyType SuggestedLowerPricePlusShipping = default(MoneyType), BuyBoxEligibleOffers BuyBoxEligibleOffers = default(BuyBoxEligibleOffers), DateTime? OffersAvailableTime = default(DateTime?))
        {
            // to ensure "TotalOfferCount" is required (not null)
            if (TotalOfferCount == null)
            {
                throw new InvalidDataException("TotalOfferCount is a required property for Summary and cannot be null");
            }
            else
            {
                this.TotalOfferCount = TotalOfferCount;
            }
            this.NumberOfOffers = NumberOfOffers;
            this.LowestPrices = LowestPrices;
            this.BuyBoxPrices = BuyBoxPrices;
            this.ListPrice = ListPrice;
            this.SuggestedLowerPricePlusShipping = SuggestedLowerPricePlusShipping;
            this.BuyBoxEligibleOffers = BuyBoxEligibleOffers;
            this.OffersAvailableTime = OffersAvailableTime;
        }

        /// <summary>
        /// The number of unique offers contained in NumberOfOffers.
        /// </summary>
        /// <value>The number of unique offers contained in NumberOfOffers.</value>
        [DataMember(Name = "TotalOfferCount", EmitDefaultValue = false)]
        public int? TotalOfferCount { get; set; }

        /// <summary>
        /// A list that contains the total number of offers for the item for the given conditions and fulfillment channels.
        /// </summary>
        /// <value>A list that contains the total number of offers for the item for the given conditions and fulfillment channels.</value>
        [DataMember(Name = "NumberOfOffers", EmitDefaultValue = false)]
        public NumberOfOffers NumberOfOffers { get; set; }

        /// <summary>
        /// A list of the lowest prices for the item.
        /// </summary>
        /// <value>A list of the lowest prices for the item.</value>
        [DataMember(Name = "LowestPrices", EmitDefaultValue = false)]
        public LowestPrices LowestPrices { get; set; }

        /// <summary>
        /// A list of item prices.
        /// </summary>
        /// <value>A list of item prices.</value>
        [DataMember(Name = "BuyBoxPrices", EmitDefaultValue = false)]
        public BuyBoxPrices BuyBoxPrices { get; set; }

        /// <summary>
        /// The list price of the item as suggested by the manufacturer.
        /// </summary>
        /// <value>The list price of the item as suggested by the manufacturer.</value>
        [DataMember(Name = "ListPrice", EmitDefaultValue = false)]
        public MoneyType ListPrice { get; set; }

        /// <summary>
        /// The suggested lower price of the item, including shipping and Amazon Points. The suggested lower price is based on a range of factors, including historical selling prices, recent Buy Box-eligible prices, and input from customers for your products.
        /// </summary>
        /// <value>The suggested lower price of the item, including shipping and Amazon Points. The suggested lower price is based on a range of factors, including historical selling prices, recent Buy Box-eligible prices, and input from customers for your products.</value>
        [DataMember(Name = "SuggestedLowerPricePlusShipping", EmitDefaultValue = false)]
        public MoneyType SuggestedLowerPricePlusShipping { get; set; }

        /// <summary>
        /// A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.
        /// </summary>
        /// <value>A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.</value>
        [DataMember(Name = "BuyBoxEligibleOffers", EmitDefaultValue = false)]
        public BuyBoxEligibleOffers BuyBoxEligibleOffers { get; set; }

        /// <summary>
        /// When the status is ActiveButTooSoonForProcessing, this is the time when the offers will be available for processing.
        /// </summary>
        /// <value>When the status is ActiveButTooSoonForProcessing, this is the time when the offers will be available for processing.</value>
        [DataMember(Name = "OffersAvailableTime", EmitDefaultValue = false)]
        public DateTime? OffersAvailableTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Summary {\n");
            sb.Append("  TotalOfferCount: ").Append(TotalOfferCount).Append("\n");
            sb.Append("  NumberOfOffers: ").Append(NumberOfOffers).Append("\n");
            sb.Append("  LowestPrices: ").Append(LowestPrices).Append("\n");
            sb.Append("  BuyBoxPrices: ").Append(BuyBoxPrices).Append("\n");
            sb.Append("  ListPrice: ").Append(ListPrice).Append("\n");
            sb.Append("  SuggestedLowerPricePlusShipping: ").Append(SuggestedLowerPricePlusShipping).Append("\n");
            sb.Append("  BuyBoxEligibleOffers: ").Append(BuyBoxEligibleOffers).Append("\n");
            sb.Append("  OffersAvailableTime: ").Append(OffersAvailableTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Summary);
        }

        /// <summary>
        /// Returns true if Summary instances are equal
        /// </summary>
        /// <param name="input">Instance of Summary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Summary input)
        {
            if (input == null)
                return false;

            return
                (
                    this.TotalOfferCount == input.TotalOfferCount ||
                    (this.TotalOfferCount != null &&
                    this.TotalOfferCount.Equals(input.TotalOfferCount))
                ) &&
                (
                    this.NumberOfOffers == input.NumberOfOffers ||
                    (this.NumberOfOffers != null &&
                    this.NumberOfOffers.Equals(input.NumberOfOffers))
                ) &&
                (
                    this.LowestPrices == input.LowestPrices ||
                    (this.LowestPrices != null &&
                    this.LowestPrices.Equals(input.LowestPrices))
                ) &&
                (
                    this.BuyBoxPrices == input.BuyBoxPrices ||
                    (this.BuyBoxPrices != null &&
                    this.BuyBoxPrices.Equals(input.BuyBoxPrices))
                ) &&
                (
                    this.ListPrice == input.ListPrice ||
                    (this.ListPrice != null &&
                    this.ListPrice.Equals(input.ListPrice))
                ) &&
                (
                    this.SuggestedLowerPricePlusShipping == input.SuggestedLowerPricePlusShipping ||
                    (this.SuggestedLowerPricePlusShipping != null &&
                    this.SuggestedLowerPricePlusShipping.Equals(input.SuggestedLowerPricePlusShipping))
                ) &&
                (
                    this.BuyBoxEligibleOffers == input.BuyBoxEligibleOffers ||
                    (this.BuyBoxEligibleOffers != null &&
                    this.BuyBoxEligibleOffers.Equals(input.BuyBoxEligibleOffers))
                ) &&
                (
                    this.OffersAvailableTime == input.OffersAvailableTime ||
                    (this.OffersAvailableTime != null &&
                    this.OffersAvailableTime.Equals(input.OffersAvailableTime))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.TotalOfferCount != null)
                    hashCode = hashCode * 59 + this.TotalOfferCount.GetHashCode();
                if (this.NumberOfOffers != null)
                    hashCode = hashCode * 59 + this.NumberOfOffers.GetHashCode();
                if (this.LowestPrices != null)
                    hashCode = hashCode * 59 + this.LowestPrices.GetHashCode();
                if (this.BuyBoxPrices != null)
                    hashCode = hashCode * 59 + this.BuyBoxPrices.GetHashCode();
                if (this.ListPrice != null)
                    hashCode = hashCode * 59 + this.ListPrice.GetHashCode();
                if (this.SuggestedLowerPricePlusShipping != null)
                    hashCode = hashCode * 59 + this.SuggestedLowerPricePlusShipping.GetHashCode();
                if (this.BuyBoxEligibleOffers != null)
                    hashCode = hashCode * 59 + this.BuyBoxEligibleOffers.GetHashCode();
                if (this.OffersAvailableTime != null)
                    hashCode = hashCode * 59 + this.OffersAvailableTime.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
