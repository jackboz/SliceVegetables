using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables.UI.StateMachine
{
    public interface IUIState
    {
        public void OnEnterUIState();
        public void OnExitUIState();
    }

    public enum UIStates
    {
        Start,
        Level,
        Win
    }

    public class UIStateMachineController
    {
        Dictionary<UIStates, IUIState> states = new Dictionary<UIStates, IUIState>();
        UIStates currentState; 

        public void Init(IUIState[] uistates)
        {
            if (uistates.Length == 0)
            {
                Debug.LogError("UI states are empty");
            }
            for (int i = 0; i < uistates.Length; i++)
            {
                states.Add((UIStates)i, uistates[i]);
            }
            currentState = 0;
            states[currentState].OnEnterUIState();
        }

        public void SwitchUI(UIStates newState)
        {
            states[currentState].OnExitUIState();
            currentState = newState;
            states[currentState].OnEnterUIState();
        }
    }
}
