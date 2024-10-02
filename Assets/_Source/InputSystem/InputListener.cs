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
        [field: SerializeField] public float ShootCooldownTime {  get; private set; }
        IEnumerator ShootInputCooldown()
        {
            _isShootAllowed = false;
            yield return new WaitForSeconds(ShootCooldownTime);
            _isShootAllowed = true;
        }
        private void Update()
        {
            ReadMoveInput();
            ReadShootInput();
            ReadRestartInput();
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
        private void ReadRestartInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _invoker.InvokeRestart();
            }
        }
        public void SetInvoker(PlayerInvoker invoker)
        {
            _invoker = invoker;
        }
    }
}
