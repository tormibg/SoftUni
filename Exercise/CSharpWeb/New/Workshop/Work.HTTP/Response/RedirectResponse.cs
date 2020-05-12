using System;
using System.Collections.Generic;
using System.Text;

namespace Work.HTTP.Response
{
    public class RedirectResponse:HttpResponse
    {
        public RedirectResponse(string newLocation)
        {
            this.Headers.Add(new Header("Location",newLocation));
            this.Code = HttpResponseCode.Found;
        }
    }
}
