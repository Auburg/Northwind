using NorthwindDAL.Models;
using NorthwindModels;

namespace NorthwindApi.Extensions;

public static class ModelToDto
{
    public static EmployeeDto EmployeeModelToDto(this Employee employee) => new (employee.EmployeeId, 
        employee.FirstName,
        employee.LastName,
        employee.Title,
        employee.BirthDate,
        employee.HireDate, 
        employee.Address,
        employee.City);
}

