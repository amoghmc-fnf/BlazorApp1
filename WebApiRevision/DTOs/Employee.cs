﻿namespace WebApiRevision.DTOs
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; } = null!;

        public string EmpAddress { get; set; } = null!;

        public decimal EmpSalary { get; set; }

        public int DeptId { get; set; }
    }

    public class Dept
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
