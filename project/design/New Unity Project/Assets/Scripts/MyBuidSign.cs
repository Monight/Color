using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 建造者模式
/// </summary>


namespace MyBuidSample
{
    /// <summary>
    /// 调用的地方
    /// </summary>
    public class MyBuidSign : MonoBehaviour
    {
        void Start()
        {
            Combine combin = new Combine();
            house houseActor = combin.buideHouse(new ChineseBuild());
            Debug.Log(houseActor.wallType);
        }
        
    }



    /// <summary>
    /// 建筑的基类
    /// </summary>
    public abstract class Build
    {
        protected house houseActor = new house();

        public abstract void BuilWall();
        public abstract void BuidFloor();

        public house CreatHouseActor()
        {
            return houseActor;
        }
    }

    public class house
    {
        public int wallType;
        public int floorType;

        public void SetWallType(int type)
        {
            wallType = type;
        }

        public void SetFloorType(int type)
        {
            floorType = type;
        }
    }

    /// <summary>
    /// 中国的建筑
    /// </summary>
    public class ChineseBuild:Build
    {
        public override void BuilWall()
        {
            houseActor.SetWallType(1);
            Debug.Log("中国建筑墙面");
        }

        public override void BuidFloor()
        {
            houseActor.SetFloorType(1);
            Debug.Log("中国建筑地面");
        }
    }

    /// <summary>
    /// 英式的建筑
    /// </summary>
    public class EnglishBuid : Build
    {
        public override void BuilWall()
        {
            houseActor.SetWallType(2);
            Debug.Log("英式建筑墙面");
        }

        public override void BuidFloor()
        {
            houseActor.SetFloorType(2);
            Debug.Log("英式建筑地面");
        }
    }

    /// <summary>
    /// 将建筑组合在一起的算法
    /// </summary>
    public class Combine
    {
        ///// <summary>
        ///// 单例模式
        ///// </summary>
        //private static Combine _insTance = null;
        //public static Combine insTance
        //{
        //    get
        //    {
        //        if (_insTance == null)
        //            _insTance = new Combine();
        //        return _insTance;
        //    }
        //}


        public house buideHouse(Build build)
        {
            house houseActor;
            build.BuilWall();
            build.BuidFloor();
            houseActor = build.CreatHouseActor();
            return houseActor;
        }

        
    }




}











