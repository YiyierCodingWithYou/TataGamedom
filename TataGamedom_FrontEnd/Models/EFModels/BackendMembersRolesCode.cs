using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class BackendMembersRolesCode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BackendMember> BackendMembers { get; set; } = new List<BackendMember>();

    public virtual ICollection<BackendMembersRolePermission> BackendMembersRolePermissions { get; set; } = new List<BackendMembersRolePermission>();
}
