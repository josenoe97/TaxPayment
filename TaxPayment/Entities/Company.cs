using TaxPayment.Entities.Exceptions;

namespace TaxPayment.Entities
{
    internal class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(string name, double anualIncome, int numberOfEmployees) 
            : base(name, anualIncome)
        {
            if (numberOfEmployees < 0)
            {
                throw new DomainException("number of employees can't be negative");
            }
            NumberOfEmployees = numberOfEmployees;    
        }

        public override double Tax()
        {
            
            if (NumberOfEmployees <= 10)
            {
                return AnualIncome * 0.16;
            }
            else
            {
                return AnualIncome * 0.14;
            }
        }
    }
}
