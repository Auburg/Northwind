namespace NorthwindModels;

public record EmployeeDto(int EmployeeId, 
    string FirstName, 
    string LastName,
    string? Title, 
    DateTime? DOB, 
    DateTime? HiredDate, 
    string? Address, 
    string? City);
