using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerInvoker _invoker;

        private void Update()
        {
            ReadMoveInput();
            ReadShootInput();
        }
        private void ReadMoveInput()
        {
            _invoker.InvokeMove();
        }
        private void ReadShootInput()
        {
            _invoker.InvokeShoot();
        }
        public void SetInvoker(PlayerInvoker invoker)
        {
            _invoker = invoker;
            Debug.Log("Invoker Set");
        }
    }
}
