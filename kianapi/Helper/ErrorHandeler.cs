namespace kianapi.Helper
{
    public class ErrorHandeler
    {
        public string message { get; set; }
        public int status { get; set; }

        public ErrorHandeler(int status, string message = null)
        {
            this.message = message ?? viewerror(status); //if null colease operator
            this.status = status;
        }

        private string viewerror(int status)
        => status switch

        {
            400 => "bad request yazmely",
            404 => "not found yazmely",
            500 => "server error yazmely",
            401 => "Authorized yazmely",
            _ => null
        };
    }
}
