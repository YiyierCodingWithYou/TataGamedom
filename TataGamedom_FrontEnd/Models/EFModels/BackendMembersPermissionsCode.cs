using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class BackendMembersPermissionsCode
    {
        public BackendMembersPermissionsCode()
        {
            BackendMembersRolePermissions = new HashSet<BackendMembersRolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BackendMembersRolePermission> BackendMembersRolePermissions { get; set; }
    }
}
