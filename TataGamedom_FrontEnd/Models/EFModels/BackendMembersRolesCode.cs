using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class BackendMembersRolesCode
    {
        public BackendMembersRolesCode()
        {
            BackendMembers = new HashSet<BackendMember>();
            BackendMembersRolePermissions = new HashSet<BackendMembersRolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BackendMember> BackendMembers { get; set; }
        public virtual ICollection<BackendMembersRolePermission> BackendMembersRolePermissions { get; set; }
    }
}
