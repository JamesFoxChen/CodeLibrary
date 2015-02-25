using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

public static class SystemExtensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (!source.IsNullOrEmpty<T>() && (action != null))
        {
            foreach (T local in source)
            {
                action(local);
            }
        }
    }

    public static T GetCustomAttribute<T>(this Type type, bool inherit = false) where T : Attribute
    {
        if (type.IsDefined(typeof(T), false))
        {
            return (T)type.GetCustomAttributes(typeof(T), inherit)[0];
        }
        return default(T);
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
    {
        return ((source == null) || !source.Any<T>());
    }

    public static Assembly[] LoadAppAssemblies()
    {
        string relativeSearchPath = AppDomain.CurrentDomain.RelativeSearchPath;
        if (string.IsNullOrEmpty(relativeSearchPath))
        {
            relativeSearchPath = Environment.CurrentDirectory;
        }
        DirectoryInfo info = new DirectoryInfo(relativeSearchPath);
        return (from m in (from m in info.GetFiles("CodeLibrary.*.dll") select m.Name).ToArray<string>() select Assembly.Load(Path.GetFileNameWithoutExtension(m))).ToArray<Assembly>();
    }

    public static byte[] ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(filePath);
        }
        return File.ReadAllBytes(filePath);
    }

    public static byte[] ReadFile(string rootPath, string relativePath)
    {
        return ReadFile(Path.Combine(rootPath, relativePath));
    }

    public static IList<T> Remove<T>(this IList<T> source, Func<T, bool> predicate = null)
    {
        if (source != null)
        {
            T[] localArray = (predicate != null) ? source.Where<T>(predicate).ToArray<T>() : source.ToArray<T>();
            foreach (T local in localArray)
            {
                source.Remove(local);
            }
        }
        return source;
    }
}

