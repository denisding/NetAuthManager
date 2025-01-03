﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetAuthManager.Core.Helper;

public static class EnumHelper
{
    /// <summary>
    /// 将枚举转成List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<EnumEntity> EnumToList<T>()
    {
        List<EnumEntity> list = new List<EnumEntity>();

        foreach (var e in Enum.GetValues(typeof(T)))
        {
            EnumEntity m = new EnumEntity();
            object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (objArr != null && objArr.Length > 0)
            {
                DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                m.description = da.Description;
            }
            m.value = Convert.ToInt32(e);
            m.title = e.ToString();
            list.Add(m);
        }
        return list;
    }

    /// <summary>
    /// 根据枚举值来获取单个枚举实体
    /// </summary>
    /// <typeparam name="T">枚举</typeparam>
    /// <param name="value">value</param>
    /// <returns></returns>
    public static EnumEntity GetEnumberEntity<T>(int value)
    {
        foreach (var e in Enum.GetValues(typeof(T)))
        {
            EnumEntity m = new EnumEntity();
            object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (objArr != null && objArr.Length > 0)
            {
                DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                m.description = da.Description;
            }
            m.value = Convert.ToInt32(e);
            m.title = e.ToString();
            if (value == m.value)
            {
                return m;
            }
        }
        return null;
    }

    /// <summary>
    /// 根据枚举值value来获取单个枚举实体的文字描述内容
    /// </summary>
    /// <typeparam name="T">枚举</typeparam>
    /// <param name="value">value</param>
    /// <returns></returns>
    public static string GetEnumDescriptionByValue<T>(int value)
    {
        foreach (var e in Enum.GetValues(typeof(T)))
        {
            EnumEntity m = new EnumEntity();
            object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (objArr != null && objArr.Length > 0)
            {
                DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                m.description = da.Description;
            }
            m.value = Convert.ToInt32(e);
            m.title = e.ToString();
            if (value == m.value)
            {
                return m.description;
            }
        }
        return "";
    }

    /// <summary>
    /// 根据枚举key来获取单个枚举实体的文字描述内容
    /// </summary>
    /// <typeparam name="T">枚举</typeparam>
    /// <param name="key">value</param>
    /// <returns></returns>
    public static string GetEnumDescriptionByKey<T>(string key)
    {
        foreach (var e in Enum.GetValues(typeof(T)))
        {
            EnumEntity m = new EnumEntity();
            object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (objArr != null && objArr.Length > 0)
            {
                DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                m.description = da.Description;
            }
            m.value = Convert.ToInt32(e);
            m.title = e.ToString();
            if (key == m.title)
            {
                return m.description;
            }
        }
        return "";
    }

    /// <summary>
    /// 根据枚举类型和枚举值获取枚举描述
    /// </summary>
    /// <returns></returns>
    public static string ToDescription(this System.Enum value)
    {
        if (value == null) return "";

        Type type = value.GetType();
        string enumText = System.Enum.GetName(type, value);
        return GetDescription(type, enumText);
    }

    /// <summary>
    /// 获取值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToIntValue<T>(this T value) where T : Enum
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// 获取值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToStringValue<T>(this T value) where T : Enum
    {
        if (value == null) return "";
        return value.ToString("d");
    }

    /// <summary>
    /// 转换为枚举
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T FromStringValue<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value);
    }

    /// <summary>
    /// 转换为枚举
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToDescription<T>(object value) where T : Enum
    {
        return ((T)Enum.Parse(typeof(T), Convert.ToString(value))).ToDescription();
    }

    #region 内部成员

    /// <summary>
    /// 转化枚举及其描述为字典类型
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enumObj"></param>
    /// <returns></returns>
    public static Dictionary<int, string> ToDescriptionDictionary<TEnum>()
    {
        Type type = typeof(TEnum);
        var values = Enum.GetValues(type);
        var enums = new Dictionary<int, string>();
        foreach (Enum item in values)
        {
            enums.Add(Convert.ToInt32(item), item.ToDescription());
        }

        return enums;
    }

    /// <summary>
    /// 转化枚举及其Text值转为字典类型
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enumObj"></param>
    /// <returns></returns>
    public static Dictionary<int, string> ToDictionary<TEnum>()
    {
        Type type = typeof(TEnum);
        var values = Enum.GetValues(type);
        var enums = new Dictionary<int, string>();
        foreach (Enum item in values)
        {
            enums.Add(Convert.ToInt32(item), item.ToString());
        }

        return enums;
    }

    private static bool IsIntType(double d)
    {
        return (int)d != d;
    }

    static Hashtable enumDesciption = GetDescriptionContainer();

    static Hashtable GetDescriptionContainer()
    {
        enumDesciption = new Hashtable();
        return enumDesciption;
    }

    static void AddToEnumDescription(Type enumType)
    {
        enumDesciption.Add(enumType, GetEnumDic(enumType));
    }


    ///<summary>
    /// 返回 Dic&lt;枚举项，描述&gt;
    ///</summary>
    ///<param name="enumType">枚举的类型</param>
    ///<returns>Dic&lt;枚举项，描述&gt;</returns>
    static Dictionary<string, string> GetEnumDic(Type enumType)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        FieldInfo[] fieldinfos = enumType.GetFields();
        foreach (FieldInfo field in fieldinfos)
        {
            if (field.FieldType.IsEnum)
            {
                Object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                dic.Add(field.Name, ((DescriptionAttribute)objs[0]).Description);
            }

        }

        return dic;
    }

    /// <summary>
    /// 根据枚举类型和枚举值获取枚举描述
    /// </summary>
    /// <param name="enumType">枚举类型</param>
    /// <param name="enumText">枚举值</param>
    /// <returns></returns>
    static string GetDescription(Type enumType, string enumText)
    {
        if (String.IsNullOrEmpty(enumText))
            return null;
        if (!enumDesciption.ContainsKey(enumType))
            AddToEnumDescription(enumType);

        object value = enumDesciption[enumType];

        if (value != null && !String.IsNullOrEmpty(enumText))
        {
            Dictionary<string, string> description = (Dictionary<string, string>)value;
            return description[enumText];
        }
        else
            throw new ApplicationException("不存在枚举的描述");

    }

    #endregion
}

/// <summary>
/// 枚举实体
/// </summary>
public class EnumEntity
{
    /// <summary>
    /// 枚举的描述
    /// </summary>
    public string description { set; get; }

    /// <summary>
    /// 枚举名称
    /// </summary>
    public string title { set; get; }

    /// <summary>
    /// 枚举对象的值
    /// </summary>
    public int value { set; get; }
}
