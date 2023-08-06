using System;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Character.Input
{
    public class InputController : ITickable
    {
        public event Action OnLeftArrowPress;
        public event Action OnRightArrowPress;
        public event Action OnUpArrowPress;
        public event Action OnDownArrowPress;
        
        public InputController(TickableManager tickableManager)
        {
            tickableManager.Add(this);
        }

        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnLeftArrowPress?.Invoke();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnRightArrowPress?.Invoke();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                OnUpArrowPress?.Invoke();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                OnDownArrowPress?.Invoke();        
            }
        }
    }
}