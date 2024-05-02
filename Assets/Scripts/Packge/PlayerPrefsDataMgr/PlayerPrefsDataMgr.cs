using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class PlayerPrefsDataMgr
{
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();
    private PlayerPrefsDataMgr()
    {

    }
    public static PlayerPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    public void SaveDate(object data,string key)
    {
        Type dataType = data.GetType();
        FieldInfo[] fields = dataType.GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            //Debug.Log(fields[i]);
        }
        string saveKeyName;
        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo info = fields[i];
            saveKeyName = key + "_" + dataType.Name + "_" +
                info.FieldType.Name + "_" + info.Name;
            //Debug.Log(saveKeyName);
            SaveData(info.GetValue(data), saveKeyName);
        }
        PlayerPrefs.Save();
    }
    private void SaveData(object data,string key)
    {
        Type type = data.GetType();
        if (type == typeof(int))
        {
            //Debug.Log("存储int:"+ key);
            PlayerPrefs.SetInt(key, (int)data);
        }
        else if (type == typeof(string))
        {
            //Debug.Log("存储string:" + key);
            PlayerPrefs.SetString(key, (string)data);
        }
        else if (type == typeof(float))
        {
            //Debug.Log("存储float:" + key);
            PlayerPrefs.SetFloat(key, (float)data);
        }
        else if (type == typeof(bool))
        {
            //Debug.Log("存储bool:" + key);
            PlayerPrefs.SetInt(key, (bool)data?1:0);
        }
        else if (typeof(IList).IsAssignableFrom(type))
        {
            //Debug.Log("存储List"+key);
            IList list = data as IList;
            int count = list.Count;
            PlayerPrefs.SetInt(key, count);
            int Index = 0;
            foreach (object item in list)
            {
                SaveData(item, key + "_" + Index);
                Index++;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(type))
        {
            //Debug.Log("存储Dic"+key);
            IDictionary dic = data as IDictionary;
            PlayerPrefs.SetInt(key, dic.Count);
            int index = 0;
            foreach (object item in dic.Keys)
            {
                SaveData(item, key + "_key_" + index);
                SaveData(dic[item], key + "_value_" + index);
                index++;
                
            }
        }
        else
        {
            SaveDate(data, key);
            //Debug.Log("递归");
        }

    }
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="type">传入要获取的类型</param>
    /// <param name="key">传入唯一键</param>
    /// <returns>返回查询的数据</returns>
    public object LoadData(Type type,string key)
    {
        //要求存取的数据结构必须含有无参构造函数
        object data = Activator.CreateInstance(type);

        FieldInfo[] infos = type.GetFields();
        string loadKayName;
        FieldInfo field;
        for (int i = 0; i < infos.Length; i++)
        {
            field = infos[i];
            loadKayName = key + "_" + type.Name + "_" +
                field.FieldType.Name + "_" + field.Name;
            field.SetValue(data, LoadValue(field.FieldType, loadKayName));
        }

        return data;
    }
    private object LoadValue(Type type,string key)
    {
        if (type == typeof(int))
        {
            return PlayerPrefs.GetInt(key, 0);
        }
        else if(type == typeof(float))
        {
            return PlayerPrefs.GetFloat(key, 0);
        }
        else if (type == typeof(string))
        {
            return PlayerPrefs.GetString(key, "");
        }
        else if (type == typeof(bool))
        {
            return PlayerPrefs.GetInt(key) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(type))
        {
            int count = PlayerPrefs.GetInt(key, 0);
            IList list = Activator.CreateInstance(type) as IList;
            for(int i = 0; i < count; i++)
            {
                list.Add(LoadValue(type.GetGenericArguments()[0], key +"_"+ i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(type))
        {
            int count = PlayerPrefs.GetInt(key, 0);
            IDictionary dictionary = Activator.CreateInstance(type) as IDictionary;
            Type[] kvType = type.GetGenericArguments();
            for(int i = 0; i < count; i++)
            {
                dictionary.Add(LoadValue(kvType[0], key + "_key_" + i),
                    LoadValue(kvType[1], key + "_value_" + i));
            }
            return dictionary;
        }
        else
        {
            return LoadData(type, key);
        }
    }
}
