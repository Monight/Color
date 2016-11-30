using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

/// <summary>
/// 建造者模式  一个所有建筑的基类  所以建筑继承他，一个组合类，将房子需要的所有的元素组合在一起
/// </summary>



public class BuilSign : MonoBehaviour
{

    void Start()
    {
        Builder instance;
        Director director = new Director();
        instance = new ChineseBuilder();
        director.Construct(instance);
        House house = instance.GetHouse();
        Debug.Log(house);


    }


    public class House
    {



    }



    public abstract class Builder
    {
        public abstract void BuildDoor();
        public abstract void BuildWall();
        public abstract void BuildWindows();
        public abstract void BuildFloor();
        public abstract void BuildHouseCeiling();

        public abstract House GetHouse();
    }
    //Director类：这一部分是 组合到一起的算法（相对稳定）。 
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildWall();
            builder.BuildHouseCeiling();
            builder.BuildDoor();
            builder.BuildWindows();
            builder.BuildFloor();
        }
    }
    //ChineseBuilder类
    public class ChineseBuilder : Builder
    {
        private House ChineseHouse = new House();
        public override void BuildDoor()
        {
            Debug.Log("chinese");
            Console.WriteLine("this Door 's style of Chinese");
        }
        public override void BuildWall()
        {
            Console.WriteLine("this Wall 's style of Chinese");
        }
        public override void BuildWindows()
        {
            Console.WriteLine("this Windows 's style of Chinese");
        }
        public override void BuildFloor()
        {
            Console.WriteLine("this Floor 's style of Chinese");
        }
        public override void BuildHouseCeiling()
        {
            Console.WriteLine("this Ceiling 's style of Chinese");
        }
        public override House GetHouse()
        {
            return ChineseHouse;
        }
    }
    //RomanBuilder类：
    class RomanBuilder : Builder
    {
        private House RomanHouse = new House();
        public override void BuildDoor()
        {
            Console.WriteLine("this Door 's style of Roman");
        }
        public override void BuildWall()
        {
            Console.WriteLine("this Wall 's style of Roman");
        }
        public override void BuildWindows()
        {
            Console.WriteLine("this Windows 's style of Roman");
        }
        public override void BuildFloor()
        {
            Console.WriteLine("this Floor 's style of Roman");
        }
        public override void BuildHouseCeiling()
        {
            Console.WriteLine("this Ceiling 's style of Roman");
        }
        public override House GetHouse()
        {
            return RomanHouse;
        }
    }
    //ChineseBuilder和RomanBuilder这两个是：这个复杂对象的两个部分经常面临着剧烈的变化。
    public class Client
    {
        public static void Main(string[] args)
        {
            Director director = new Director();

            Builder instance;






            //House house = instance.GetHouse();
            ////house.Show();

            //Console.ReadLine();
        }
    }
}

