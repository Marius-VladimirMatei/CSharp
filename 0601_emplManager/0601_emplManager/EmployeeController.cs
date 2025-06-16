using System;
using System.Collections.Generic;
using System.Linq;

namespace _0601_emplManager
{
    public class EmployeeController
    {
        private readonly List<Employee> employees;
        private readonly InputValidator _validator = new InputValidator();

        public EmployeeController()
        {
            // Load existing entries from CSV (or header only if first run)
            employees = DataStorage.LoadEmployees();
        }


        // Validates and adds a new employee, then persists the list.
        // Returns a success message or throws ValidationException.

        public string AddEmployee(string nameInput, string ageInput)
        {
            _validator.ValidateName(nameInput);

            if (!int.TryParse(ageInput, out int age))
                throw new ValidationException("Age must be a valid number.");
            _validator.ValidateAge(age);

            // Prevent duplicate by name
            // Lambda boolean returns true if any employee has the same name (case-insensitive).
            if (employees.Any(employee =>
                employee.Name.Equals(nameInput, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ValidationException($"An employee named '{nameInput}' already exists.");
            }

            var employee = new Employee(nameInput, age);
            employees.Add(employee);
            DataStorage.SaveEmployees(employees);

            return $"Employee {employee.Name} ({employee.Age} years) added successfully.";
        }


        // Returns all employee records as a multi-line string.

        public string DisplayAllEmployees()
        {
            if (!employees.Any())
                return "No employee records found.";

            // Join method to format each employee's details into a sequence of strings 
            // Environment.NewLine used to separate each record (clearer intent than embedding literal "\r\n" or "\n")
            return string.Join(Environment.NewLine,
                employees.Select(e => $"Name: {e.Name}, Age: {e.Age}"));
        }
    }
}
