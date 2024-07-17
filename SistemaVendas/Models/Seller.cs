namespace SistemaVendas.Models
{
    public class Seller
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthData { get; set; }
        public double Salary { get; set; }
        public Departament Departament { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller( string name, string email, DateTime birthData, double salary, Departament departament) {
            Name = name;
            Email = email;
            BirthData = birthData;
            Salary = salary;
            Departament = departament;
        }

        public Seller(int id, string name, string email, DateTime birthData, double salary, Departament departament) {
            Id = id;
            Name = name;
            Email = email;
            BirthData = birthData;
            Salary = salary;
            Departament = departament; 
        }

        public void AddSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
