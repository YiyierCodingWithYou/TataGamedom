﻿using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IMemberRepository : IGenericRepository<Member>
{
    Task<MemberAndChatInfoDto?> GetLoginMemberChatInfo();
    Task<bool> IsMemberExist(int id);
}
