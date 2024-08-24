using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class Seller
    {

        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthData { get; set; }

        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Salary { get; set; }


        public Departament Departament { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public int DepartamentId { get; set; }

        public Seller() { }

        public Seller(string name, string email, DateTime birthData, double salary, Departament departament)
        {
            Name = name;
            Email = email;
            BirthData = birthData;
            Salary = salary;
            Departament = departament;
        }

        public Seller(int id, string name, string email, DateTime birthData, double salary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthData = birthData;
            Salary = salary;
            Departament = departament;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
