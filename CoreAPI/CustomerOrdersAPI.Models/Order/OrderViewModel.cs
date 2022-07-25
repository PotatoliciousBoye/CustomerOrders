namespace CustomerOrdersAPI.Models.Order
{
    /// <summary>
    /// Defines the <see cref="OrderViewModel" />.
    /// </summary>
    public class OrderViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CustomerOrderId.
        /// </summary>
        public string CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the DestinationAddress.
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Gets or sets the MaterialId.
        /// </summary>
        public string MaterialId { get; set; }

        /// <summary>
        /// Gets or sets the MaterialQuantity.
        /// </summary>
        public int MaterialQuantity { get; set; }

        /// <summary>
        /// Gets or sets the Note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatusId.
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the OriginAddress.
        /// </summary>
        public string OriginAddress { get; set; }

        /// <summary>
        /// Gets or sets the QuantityUnit.
        /// </summary>
        public string QuantityUnit { get; set; }

        /// <summary>
        /// Gets or sets the TotalWeight.
        /// </summary>
        public int TotalWeight { get; set; }

        /// <summary>
        /// Gets or sets the WeightUnit.
        /// </summary>
        public string WeightUnit { get; set; }

        #endregion
    }
}
