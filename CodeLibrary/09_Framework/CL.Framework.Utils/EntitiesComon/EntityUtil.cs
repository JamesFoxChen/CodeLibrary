using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

namespace CL.Framework.Utils.EntitiesComon
{
    public class EntityUtil
    {
        public static void ConvertEntity<S, T>(S source, T target)
            where S : class
            where T : class
        {
            PropertyInfo[] properties = typeof(S).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] infoArray2 = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo info in infoArray2)
            {
                if (info.CanWrite)
                {
                    foreach (PropertyInfo info2 in properties)
                    {
                        if ((info2.CanRead && (info2.Name == info.Name)) && (info2.PropertyType == info.PropertyType))
                        {
                            info.SetValue(target, info2.GetValue(source, null), null);
                            break;
                        }
                    }
                }
            }
            FieldInfo[] fields = typeof(S).GetFields(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] infoArray4 = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info3 in infoArray4)
            {
                foreach (FieldInfo info4 in fields)
                {
                    if ((info3.Name == info4.Name) && (info4.FieldType == info3.FieldType))
                    {
                        info3.SetValue(target, info4.GetValue(source));
                        break;
                    }
                }
            }
        }

        public static DataTable ConvertToDataTable(IList list)
        {
            Type elementType = null;
            Type type = list.GetType();
            if (type.IsGenericType)
            {
                elementType = type.GetGenericArguments()[0];
            }
            else if (type.HasElementType)
            {
                elementType = type.GetElementType();
            }
            else
            {
                if (list.Count == 0)
                {
                    throw new NotSupportedException("list can not be converted.");
                }
                elementType = list[0].GetType();
            }
            DataTable dt = CreateDataTable(elementType);
            foreach (object obj2 in list)
            {
                FillDataTable(dt, elementType, obj2);
            }
            return dt;
        }

        public static T ConvertToEntity<T>(DataRow row) where T : class
        {
            Type type = typeof(T);
            T local = Activator.CreateInstance<T>();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (properties.Length != 0)
            {
                foreach (PropertyInfo info in properties)
                {
                    if ((info.CanWrite && row.Table.Columns.Contains(info.Name)) && (row[info.Name] != DBNull.Value))
                    {
                        info.SetValue(local, GenerateSpecifiedTypeValue(info.PropertyType, row[info.Name]), null);
                    }
                }
                return local;
            }
            foreach (FieldInfo info2 in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (row.Table.Columns.Contains(info2.Name) && (row[info2.Name] != DBNull.Value))
                {
                    info2.SetValue(local, GenerateSpecifiedTypeValue(info2.FieldType, row[info2.Name]));
                }
            }
            return local;
        }

        public static List<T> ConvertToEntityList<T>(DataTable dt) where T : class
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToEntity<T>(row));
            }
            return list;
        }

        private static DataTable CreateDataTable(Type elementType)
        {
            DataTable table = new DataTable();
            PropertyInfo[] properties = elementType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (properties.Length != 0)
            {
                foreach (PropertyInfo info in properties)
                {
                    if (info.CanRead && (GenerateDataColumnType(info.PropertyType) != null))
                    {
                        table.Columns.Add(info.Name, GenerateDataColumnType(info.PropertyType));
                    }
                }
                return table;
            }
            foreach (FieldInfo info2 in elementType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (GenerateDataColumnType(info2.FieldType) != null)
                {
                    table.Columns.Add(info2.Name, GenerateDataColumnType(info2.FieldType));
                }
            }
            return table;
        }

        private static void FillDataTable(DataTable dt, Type elementType, object info)
        {
            object obj2;
            DataRow row = dt.NewRow();
            PropertyInfo[] properties = elementType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (properties.Length != 0)
            {
                foreach (PropertyInfo info2 in properties)
                {
                    if (info2.CanRead && dt.Columns.Contains(info2.Name))
                    {
                        obj2 = info2.GetValue(info, null);
                        if (obj2 != null)
                        {
                            row[info2.Name] = obj2;
                        }
                    }
                }
            }
            else
            {
                foreach (FieldInfo info3 in elementType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (dt.Columns.Contains(info3.Name))
                    {
                        obj2 = info3.GetValue(info);
                        if (obj2 != null)
                        {
                            row[info3.Name] = obj2;
                        }
                    }
                }
            }
            dt.Rows.Add(row);
        }

        private static Type GenerateDataColumnType(Type typ)
        {
            if (typ.IsEnum)
            {
                return typeof(int);
            }
            if (typ == typeof(string))
            {
                return typ;
            }
            if (typ.IsValueType && typ.IsPrimitive)
            {
                return typ;
            }
            if (typ.IsGenericType && typ.IsValueType)
            {
                return GenerateDataColumnType(typ.GetGenericArguments()[0]);
            }
            return null;
        }

        private static object GenerateSpecifiedTypeValue(Type typ, object value)
        {
            if (typ.IsEnum)
            {
                return Enum.ToObject(typ, value);
            }
            if (typ != typeof(string))
            {
                if (typ.IsValueType && typ.IsPrimitive)
                {
                    return value;
                }
                if (typ.IsGenericType && typ.IsValueType)
                {
                    return GenerateSpecifiedTypeValue(typ.GetGenericArguments()[0], value);
                }
            }
            return value;
        }
    }
}
