namespace CustomerOrdersAPI.Models.Base.Request
{
    /// <summary>
    /// Defines the <see cref="ServiceRequestBaseModel" />.
    /// </summary>
    public class ServiceRequestBaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ErrorDescription.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the ResultStatusCode.
        /// </summary>
        public int ResultStatusCode { get; set; }

        #endregion
    }
}
