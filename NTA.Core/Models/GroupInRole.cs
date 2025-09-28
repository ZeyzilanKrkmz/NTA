namespace NTA.Core.Models;

public class GroupInRole:BaseEntity
{
    public int GroupId { get; set; }
    public int RoleId { get; set; }
    public Group Group { get; set; }
    public Role Role { get; set; }
    
}