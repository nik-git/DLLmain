using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select DLL to load (1 or 2):");
            String ch = Console.ReadLine();
            String dllName = "";
            if (ch == "1")
            {
                dllName = "DLLproject.dll";
            }
            else if(ch == "2")
            {
                dllName = "DLLproject2.dll";
            }
            Console.WriteLine("Loading DLL: "+ dllName);
            Assembly myassembly = Assembly.LoadFrom(dllName);
            Type type = myassembly.GetType("testdll.Class1");

            object instance = Activator.CreateInstance(type);

            MethodInfo[] methods = type.GetMethods();
            object res = methods[0].Invoke(instance, new object[] { 8, 3 });
            
            
            Console.WriteLine("from DLLproject.dll: " + res.ToString());
            Console.WriteLine("Going to unload DLL(press any key): " + dllName);
            Console.ReadLine();
            Assembly.UnsafeLoadFrom(dllName);
            
        }
    }
}