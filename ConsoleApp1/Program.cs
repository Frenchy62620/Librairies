using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var one = new One();
            var two = new Two();

            var obj_int = new ClassX();
            var obj_str = new ClassX();

            var ActOne = new test1<int, One>();
            var ActTwo = new test1<string, Two>();

            ActOne.myLambda1(obj_int, 10, one);
            ActTwo.myLambda1(obj_str, "Youpi", two);

            Console.WriteLine($"one = {obj_int.Value} two = {string.Join(",",(char[])obj_str.Value)}");

            new test2<int, One>().myLambda2(obj_int, 20);
            new test2<string, Two>().myLambda2(obj_str, "Super");

            Console.WriteLine($"one = {obj_int.Value} two = {string.Join(",", (char[])obj_str.Value)}");
        }

    }

    public class test1<T,U> where U : ITest<T>
    {
        public Action<ClassX, T, U> myLambda1 = (arg1, arg2, arg3) =>
        {
            arg3.SetValue(arg1, arg2);
        };
    }
    public class test2<T, U> where U : ITest<T> , new()
    { 
        public Action<ClassX, T> myLambda2 = (arg1, arg2) =>
        {
            new U().SetValue(arg1, arg2);
        };
    }

    public class ClassX
    {
        public object Value;
    }

    public interface ITest<T>
    {
        void SetValue(ClassX parameter, T value);
    }

    public class One : ITest<int>
    {
        public void SetValue(ClassX parameter, int value)
        {
            parameter.Value = value + 10;
        }
    }

    public class Two : ITest<string>
    {
        public void SetValue(ClassX parameter, string value)
        {
            parameter.Value = value.ToCharArray();
        }
    }
}
