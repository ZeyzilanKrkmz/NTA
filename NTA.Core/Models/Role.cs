namespace NTA.Core.Models;

public class Role:BaseEntity
{
    public string Name { get; set; }
    public ICollection<GroupInRole> GroupInRoles { get; set; }
}