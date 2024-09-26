using InputSystem;
using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public Player Player { get; private set; }
    public InputListener Listener { get; private set; }
    void Awake()
    {
        Player = FindObjectOfType<Player>().GetComponent<Player>();
        Listener = Player.GetComponentInChildren<InputListener>();
        Listener.SetInvoker(new(Player));
    }
}
