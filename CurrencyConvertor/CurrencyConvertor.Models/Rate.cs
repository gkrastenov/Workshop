namespace CurrencyConvertor.Models
{
    public class Rate
    {
        public Rate(string name, decimal value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }
    }
}
