using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState {

    private PlayerState()
    {
        IsWalking = false;
        IsRunning = false;
        IsFiring = false;
    }

    private static PlayerState instance = null;

    public static PlayerState GetInstance()
    {
        if (instance == null)
            instance = new PlayerState();
        return instance;
    }

    public bool IsWalking   { get; set; }
    public bool IsRunning   { get; set; }
    public bool IsFiring    { get; set; }

}
