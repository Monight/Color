using UnityEngine;
using System.Collections;

/// <summary>
/// 状态接口类
/// </summary>


public interface IState
{

    /// <summary>
    /// 进入状态
    /// </summary>
    /// <param name="machine"></param>
    /// <param name="pro"></param>
    /// <param name="parma1"></param>
    /// <param name="param2"></param>
    void OnEnter(StateMachine machine,IState pro,object parma1,object param2);

    /// <summary>
    /// 离开状态
    /// </summary>
    /// <param name="nextState"></param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    void OnLeave(IState nextState,object param1,object param2);

    /// <summary>
    /// 获取当前的ID
    /// </summary>
    /// <returns></returns>
    int GetStateID();

    void OnUpdata();

    void OnFixeUpdata();

    void OnLaterUpdata();


}
