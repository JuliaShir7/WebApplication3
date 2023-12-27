namespace WebApplication3.Interfaces
{
    public interface IConnectable
    {
        public Uri BaseUri { get; set; }
        public HttpClient Client { get; set; }
    }
}
