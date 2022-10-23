using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;
        public Bakery(string name, int capaciy)
        {
            this.employees = new List<Employee>();
            Name = name;
            Capaciy = capaciy;
        }

        public string Name { get; set; }
        public int Capaciy { get; set; }
        public int Count => this.employees.Count;
        public void Add(Employee employee)
        {
            if (this.Capaciy - this.employees.Count > 0)
            {
                this.employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employeeToRemove = this.employees.FirstOrDefault(e => e.Name == name);
            if (employeeToRemove!=null)
            {
                this.employees.Remove(employeeToRemove);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            return this.employees.OrderByDescending(e => e.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return this.employees.First(e => e.Name == name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (Employee employee in this.employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
