namespace FirstBlazorApp.Server.Model
{
    public class Products
    {
        public Int64 Id { get; set; }  
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
