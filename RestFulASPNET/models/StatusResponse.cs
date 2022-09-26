using System;
using System.Xml.Linq;

namespace RestFulASPNET.models
{
	public class StatusResponse
	{
        public String code { get; set; }
        public String message { get; set; }
        public String remark { get; set; }

        public StatusResponse()
        {
            this.code = "0";
            this.message = "success";
            this.remark = "";
        }


        public StatusResponse(String code ,String message)
		{
			this.code = code;
			this.message = message;
            this.remark = "";
		}

        public StatusResponse(String code, String message,String remark)
        {
            this.code = code;
            this.message = message;
            this.remark = remark;
        }
    }
}

