

namespace _0601_emplManagerAsync
{
    public class EmployeeController
    {
        
        private readonly InputValidator _validator = new InputValidator();

        public async Task<string> AddEmployeeAsync(string nameInput, string ageInput)
        {
            // Validation stays sync
            _validator.ValidateName(nameInput);
            _validator.ValidateAge(ageInput); // Pass ageInput (string) instead of age (int)

            if (!int.TryParse(ageInput, out int age))
                throw new ArgumentException("Age must be a valid number.", nameof(ageInput));

            // Load fresh
            var employees = await DataStorage.LoadEmployeesAsync();

            // Prevent duplicate by name
            if (employees.Any(e => e.Name.Equals(nameInput, StringComparison.OrdinalIgnoreCase)))
                return $"Error: '{nameInput}' already exists.";

            employees.Add(new Employee(nameInput, age));
            await DataStorage.SaveEmployeesAsync(employees);

            return $"Employee {nameInput} successully added.";
        }



        // Returns all employee records as a multi-line string.
        public async Task<string> DisplayAllEmployeesAsync()
        {
            var employees = await DataStorage.LoadEmployeesAsync();
            if (!employees.Any())

                return "No records found.";
            // Join method to format each employee's details into a sequence of strings 
            // Environment.NewLine used to separate each record (clearer intent than embedding literal "\r\n" or "\n")
            return string.Join(Environment.NewLine,
                employees.Select(e => $"Name: {e.Name}, Age: {e.Age}"));
        }
    }
}
