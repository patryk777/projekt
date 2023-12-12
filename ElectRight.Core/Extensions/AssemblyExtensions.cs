namespace ElectRight.Core.Extensions;

using System;
using System.Linq;
using System.Reflection;

public static class AssemblyExtensions
{
    public static Assembly[] GetAssemblies(string appName)
        => AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(x => x.FullName != null && x.FullName.Contains($"{appName}."))
            .ToArray();
}