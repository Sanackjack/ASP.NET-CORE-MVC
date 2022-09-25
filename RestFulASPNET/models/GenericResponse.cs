using System;
using System.Net.NetworkInformation;

namespace RestFulASPNET.models
{
	public class GenericResponse
	{
        public StatusResponse status { get; set; }
        public Object data { get; set; }

        public GenericResponse(StatusResponse status)
		{
			this.status = status;
		}

        public GenericResponse(StatusResponse status,Object data)
        {
            this.status = status;
			this.data = data;
        }
    }
}

