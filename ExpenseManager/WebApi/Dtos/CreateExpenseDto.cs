namespace WebApi.Models
{
    public class CreateExpenseDto
    {
        public string Name { get; set; }
        public decimal Ammount { get; set; }
        public string Description { get; set; }

    }
}
