using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class BackendMembersRolePermission
    {
        public int Id { get; set; }
        public int BackendMembersRoleId { get; set; }
        public int BackendMemberPermissionId { get; set; }

        public virtual BackendMembersPermissionsCode BackendMemberPermission { get; set; } = null!;
        public virtual BackendMembersRolesCode BackendMembersRole { get; set; } = null!;
    }
}
