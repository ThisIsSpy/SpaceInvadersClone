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
        Debug.Log($"Player {Player} found");
        Listener = Player.GetComponentInChildren<InputListener>();
        Debug.Log($"Listener {Listener} found");
        Listener.SetInvoker(new(Player));
    }
}
