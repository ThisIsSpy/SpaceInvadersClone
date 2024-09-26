using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerInvoker _invoker;
        private bool _isShootAllowed = true;

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
            if (Input.GetKeyDown(KeyCode.Q) && _isShootAllowed)
            {
                _invoker.InvokeShoot();
                StartCoroutine(ShootInputCooldown());
            }
        }
        public void SetInvoker(PlayerInvoker invoker)
        {
            _invoker = invoker;
            Debug.Log("Invoker Set");
        }
        IEnumerator ShootInputCooldown()
        {
            _isShootAllowed = false;
            yield return new WaitForSeconds(1);
            _isShootAllowed = true;
        }
    }
}
