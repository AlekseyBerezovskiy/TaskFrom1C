using System;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Character.Input
{
    public class InputController : ITickable
    {
        public event Action<Vector2> OnMoveButtonClick;

        public InputController(TickableManager tickableManager)
        {
            tickableManager.Add(this);
        }

        public void Tick()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                OnMoveButtonClick?.Invoke(Vector2.left);
            }

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                OnMoveButtonClick?.Invoke(Vector2.right);
            }

            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
            {
                OnMoveButtonClick?.Invoke(Vector2.up);
            }

            if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
            {
                OnMoveButtonClick?.Invoke(Vector2.down);        
            }
        }
    }
}