// https://en.wikipedia.org/wiki/List_of_HTTP_status_codes

namespace SimpleHttpServer.Enums
{
    public enum ResponseStatusCode
    {
        OK = 200,
        NotFound = 404,
        InternalServerError = 500,
        MethodNotAllowed = 405
    }
}