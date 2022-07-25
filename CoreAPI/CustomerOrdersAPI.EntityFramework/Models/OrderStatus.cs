using System;

namespace CustomerOrdersAPI.EntityFramework.Models
{
    /// <summary>
    /// Defines the <see cref="OrderStatus" />.
    /// </summary>
    public class OrderStatus
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CreateDate.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatusDescription.
        /// </summary>
        public string OrderStatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatusId.
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate.
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBy.
        /// </summary>
        public string UpdatedBy { get; set; }

        #endregion
    }
}
