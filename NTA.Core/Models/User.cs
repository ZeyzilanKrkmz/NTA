namespace NTA.Core.Models;

public class User:BaseEntity
{
    public string Name { get; set; }
    
    public int DepartmentId { get; set; }
    public int GroupId { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public Department Department { get; set; }
    public Group Group { get; set; }
}