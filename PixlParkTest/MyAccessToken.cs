namespace PixlParkTest
{
    public class MyAccessToken
    {
        public string RequestToken { get; set; }
        public string AccessToken { get; set; }
        public int Expires { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
        public bool RequeireSsl { get; set; }
    }
}
