namespace NTA.Core.Models;

public class Group:BaseEntity
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<Role> Roles { get; set; }
}