namespace FluentBuilder.Employees;

// ============================================================
// FLUENT BUILDER — Pracownik (na podstawie przykładu z old_version,
// rozszerzony o departament, pensję i konstruktor domyślny)
// ============================================================

public sealed class Employee
{
    public int      Id         { get; }
    public string   FirstName  { get; }
    public string   LastName   { get; }
    public DateTime BirthDate  { get; }
    public string   Department { get; }
    public decimal  Salary     { get; }

    private Employee(Builder b)
    {
        Id         = b.Id;
        FirstName  = b.FirstName;
        LastName   = b.LastName;
        BirthDate  = b.BirthDate;
        Department = b.Department;
        Salary     = b.Salary;
    }

    public string GetFullName() => $"{FirstName} {LastName}";

    public int GetAge()
    {
        var today = DateTime.Today;
        var age   = today.Year - BirthDate.Year;
        if (BirthDate > today.AddYears(-age)) age--;
        return age;
    }

    public override string ToString() =>
        $"Employee #{Id}: {GetFullName()}, age={GetAge()}, dept={Department}, salary={Salary:N0} PLN";

    // ----- Fluent Builder ----------------------------------------

    public class Builder
    {
        private static int _nextId = 1;

        public int      Id         { get; } = _nextId++;
        public string   FirstName  { get; private set; } = "Imię";
        public string   LastName   { get; private set; } = "Nazwisko";
        public DateTime BirthDate  { get; private set; } = new DateTime(1990, 1, 1);
        public string   Department { get; private set; } = "Niezdefiniowany";
        public decimal  Salary     { get; private set; } = 5000m;

        // Fluent setters — każda metoda zwraca this
        public Builder WithFirstName(string firstName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            return this;
        }

        public Builder WithLastName(string lastName)
        {
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            return this;
        }

        public Builder WithBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Today)
                throw new ArgumentException("Data urodzenia nie może być w przyszłości");
            BirthDate = birthDate;
            return this;
        }

        public Builder WithBirthDate(int year, int month, int day) =>
            WithBirthDate(new DateTime(year, month, day));

        public Builder WithDepartment(string department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
            return this;
        }

        public Builder WithSalary(decimal salary)
        {
            if (salary < 0) throw new ArgumentException("Pensja nie może być ujemna");
            Salary = salary;
            return this;
        }

        public Employee Build() => new Employee(this);

        /// <summary>
        /// Konwersja niejawna — pozwala przypisać Builder do Employee.
        /// Patrz: FluentInterface (Fowler) i old_version/03FluentBuilder
        /// </summary>
        public static implicit operator Employee(Builder builder) => builder.Build();
    }
}
