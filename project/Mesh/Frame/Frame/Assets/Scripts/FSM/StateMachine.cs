using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 状态机管理类
/// </summary>
public class StateMachine
{
    /// <summary>
    /// 当前的状态集合
    /// </summary>
    private Dictionary<int, IState> mStateDic = new Dictionary<int, IState>();

    /// <summary>
    /// 当前的状态
    /// </summary>
    private IState m_CurrentState = null;

    public IState currentState
    {
        get { return m_CurrentState; }
    }

    /// <summary>
    /// 当前的状态ID
    /// </summary>
    public int stateId
    {
        get
        {
            return m_CurrentState == null ? 0 : m_CurrentState.GetStateID();
        }
    }

    /// <summary>
    /// 往列表里面注册状态
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool OnRegisterState(IState state)
    {
        if (state == null)
        {
            Debug.LogError(" 当前的状态是空的");
        }
        if (mStateDic.ContainsValue(state))
        {
            return false;
        }
        mStateDic.Add(state.GetStateID(),state);
        return true;
    }
    /// <summary>
    /// 移出当前的状态
    /// </summary>
    /// <param name="stateID"></param>
    /// <returns></returns>
    public bool RemoveState(int stateID)
    {
        if (m_CurrentState != null && m_CurrentState.GetStateID() == stateID)
        {
            return false;
        }
        if (!mStateDic.ContainsKey(stateID))
            return false;
        mStateDic.Remove(stateID);
        return true;
    }

    /// <summary>
    /// 停止当前的状态
    /// </summary>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public void StopState(object param1,object param2)
    {
        if (m_CurrentState == null)
            return;
        m_CurrentState.OnLeave(null,param1,param2);
    }

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="stateId"></param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    /// <returns></returns>
    public bool SwitchState(int stateId, object param1, object param2)
    {
        if (m_CurrentState != null && m_CurrentState.GetStateID() == stateId)
            return false;
        IState state = null;
        mStateDic.TryGetValue(stateId,out state);
        if (state == null)
        {
            Debug.Log("当前列表里面没有这个状态");
            return false;
        }
        if (m_CurrentState != null)
        {
            m_CurrentState.OnLeave(state, param1, param2);
            state.OnEnter(this, m_CurrentState, param1, param2);
        }
        else
        {
            state.OnEnter(this, null, param1, param2);
        }
        m_CurrentState = state;
        return true;
    }


    /// <summary>
    /// 判断这个是不是当前的状态
    /// </summary>
    /// <returns></returns>
    public bool IsInState(int stateID)
    {
        return m_CurrentState == null ? false : m_CurrentState.GetStateID() == stateID;
    }


    void Updata()
    {
        if (m_CurrentState != null)
            m_CurrentState.OnUpdata();
    }

    void OnFixedUpdata()
    {
        if (m_CurrentState != null)
            m_CurrentState.OnFixeUpdata();
    }

    void OnLaterUpdata()
    {
        if (m_CurrentState != null)
            m_CurrentState.OnLaterUpdata();
    }

}
