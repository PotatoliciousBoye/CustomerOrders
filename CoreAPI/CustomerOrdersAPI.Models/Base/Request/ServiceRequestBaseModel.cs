using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.Models.Base.Request
{
    public class ServiceRequestBaseModel
    {
        public int ResultStatusCode { get; set; }

        public string ErrorDescription { get; set; }
    }
}
