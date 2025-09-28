using NTA.Core.Models;

namespace NTA.Core.DTOs;

public class DepartmentDto:BaseDto
{
    public string Name { get; set; }
    public List<User> Users { get; set; }
}