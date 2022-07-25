using System;

namespace CustomerOrdersAPI.EntityFramework.Models
{
    /// <summary>
    /// Defines the <see cref="Material" />.
    /// </summary>
    public class Material
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
        /// Gets or sets the MaterialId.
        /// </summary>
        public string MaterialId { get; set; }

        /// <summary>
        /// Gets or sets the MaterialName.
        /// </summary>
        public string MaterialName { get; set; }

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
