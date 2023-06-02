namespace BiTrap.Entities
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<TbProduct> ListProducts { get; set; }
    }
}
