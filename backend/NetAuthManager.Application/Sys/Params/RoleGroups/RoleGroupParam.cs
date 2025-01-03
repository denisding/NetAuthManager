﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetAuthManager.Application.Sys.Params.RoleGroups;

/// <summary>
/// 角色基本参数
/// </summary>
public class RoleGroupBaseParam
{
    /// <summary>
    /// 角色编码
    /// </summary>
    public string GroupCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// 服务实体
    /// </summary>
    public string ServiceEntityCode { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsOpen { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int OrderIndex { get; set; }
}

/// <summary>
/// 角色添加参数
/// </summary>
public class RoleGroupAddParam : RoleGroupBaseParam
{
}

/// <summary>
/// 角色重命名参数
/// </summary>
public class RoleGroupModifyParam : RoleGroupBaseParam
{
}

/// <summary>
/// 角色启用参数
/// </summary>
public class SetRoleGroupIsOpenParam : RoleGroupBaseParam
{
}

/// <summary>
/// 角色删除参数
/// </summary>
public class RoleGroupDeletesParam
{
    /// <summary>
    /// 角色编码
    /// </summary>
    public List<string> GroupCodes { get; set; }
}

/// <summary>
/// 角色成员
/// </summary>
public class RoleGroupMember
{
    /// <summary>
    /// 显示名
    /// </summary>
    public string DisplayName { get; set; }
    /// <summary>
    /// 成员 SID
    /// </summary>
    public string SID { get; set; }
    /// <summary>
    /// 成员类型：UserSID、OUSID、RoleSID、LeaderTitleSID
    /// GroupSID、CustomCode
    /// </summary>
    public string SIDType { get; set; }
}
