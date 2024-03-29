﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Work.HTTP.Response
{
    public class FileResponse:HttpResponse
    {
        public FileResponse(byte[] fileContent, string contentType)
        {
            this.Code = HttpResponseCode.Ok;
            this.Body = fileContent;
            this.Headers.Add(new Header("Content-Type", contentType));
            this.Headers.Add(new Header("Content-Length", this.Body.Length.ToString()));
        }
    }
}
