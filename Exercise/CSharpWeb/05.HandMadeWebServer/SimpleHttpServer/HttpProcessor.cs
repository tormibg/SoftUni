using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SimpleHttpServer
{
    public class HttpProcessor
    {
        private HttpRequest Request;
        private HttpResponse Response;
        private IList<Route> Routes;

        public HttpProcessor(IEnumerable<Route> routes)
        {
            this.Routes = new List<Route>(routes);
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                Request = GetRequest(stream);
                Response = RouteRequest();
                StreamUtils.WriteResponse(stream, Response);
            }
        }

        private HttpResponse RouteRequest()
        {
            var matchRoutes = this.Routes.Where(r => Regex.Match(Request.URL, r.UrlRegex).Success).ToList();

            if (!matchRoutes.Any())
            {
                return HttpResponseBuilder.NotFound();
            }

            var route = Routes.FirstOrDefault(r => r.Method == Request.Method);

            if (route == null)
            {
                return new HttpResponse(ResponseStatusCode.MethodNotAllowed);
            }

            try
            {
                return route.Callable(Request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return HttpResponseBuilder.InternalServerError();
            }
        }

        private HttpRequest GetRequest(NetworkStream stream)
        {
            string firstLine = StreamUtils.ReadLine(stream);
            var requestInfo = firstLine.Split(' ');
            if (requestInfo.Length < 3)
            {
                throw new ArgumentException("Invalid HTTP request first line !");
            }
            RequestMethod method = (RequestMethod)Enum.Parse(typeof(RequestMethod), requestInfo[0].ToUpper());
            String url = requestInfo[1];
            String protocolVersion = requestInfo[2];

            Header header = new Header(HeaderType.HttpRequest);
            string line;
            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
                if (String.IsNullOrEmpty(line))
                {
                    break;
                }
                var lineObjects = line.Split(':');
                string name = lineObjects[0];
                string value = lineObjects[1];

                if (name == "Cookie")
                {
                    header.Cokies[name] = new Cookie(name, value);
                }
                else if (name == "Content-Length")
                {
                    header.ContentLenght = value;
                }
                else
                {
                    if (header.OthersParameters.ContainsKey(name))
                    {
                        header.OthersParameters[name] = value;
                    }
                    else
                    {
                        header.OthersParameters.Add(name, value);
                    }
                }
            }

            string content = null;
            if (header.ContentLenght != null)
            {
                int totalBytes = Convert.ToInt32(header.ContentLenght);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, totalBytes - bytesLeft);

                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes);
            }
            HttpRequest request = new HttpRequest(url, method)
            {
                Content = content,
                Header = header
            };

            Console.WriteLine("-Request ------");
            Console.WriteLine(request);
            Console.WriteLine("---------------");
            return request;
        }
    }
}