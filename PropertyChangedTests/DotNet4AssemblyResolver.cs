﻿using System;
using System.Diagnostics;
using Mono.Cecil;

public class DotNet4AssemblyResolver : IAssemblyResolver
{
    public AssemblyDefinition Resolve(AssemblyNameReference name)
    {
        return AssemblyDefinition.ReadAssembly(name.Name + ".dll");

    }

    public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
    {
        return Resolve(name.FullName);
    }

    public AssemblyDefinition Resolve(string fullName)
    {
        if (fullName == "System")
        {
            var codeBase = typeof(Debug).Assembly.CodeBase.Replace("file:///", "");
            return AssemblyDefinition.ReadAssembly(codeBase);
        }
        else
        {
            var codeBase = typeof(string).Assembly.CodeBase.Replace("file:///", "");
            return AssemblyDefinition.ReadAssembly(codeBase);
        }
    }

    public void Dispose()
    {
        
    }
}