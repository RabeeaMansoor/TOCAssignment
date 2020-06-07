using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NpcStateMachine : StateMachine<NpcStateMachine>
{
    public enum NpcState
    {
        Idle,
        Chase,
        Grow,
    }
    public NpcState currentState;
    public Transform target;
    private void OnEnable() => OnstateChanged += _OnStateChanged;
    private void OnDisable() => OnStateChanged -= _OnStateChanged;

    public override void FillStateMachineStates()
    {
        AllStates = new Dictionary<int, BaseState<NpcStateMachine>>()
        {
            {(int)NpcState.Idle, new NpcStateIdle() },
            { (int)NpcState.Chase, new NpcStateChase()},
            {(int)NpcState.Grow, new NpcStateGrow() }
        };
    }
    private void _OnStateChanged(int _stateIndex) => currentState = (NpcState)_stateIndex;
}

