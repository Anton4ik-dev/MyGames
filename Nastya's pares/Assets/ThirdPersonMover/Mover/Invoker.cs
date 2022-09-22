using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Invoker
{
    public static void CallForward()
    {
        PlayerMovement.MoveForward(Player.Instance.rb, Player.Instance.speed);
    }
    public static void CallBack()
    {
        PlayerMovement.MoveBack(Player.Instance.rb, Player.Instance.speed);
    }
    public static void CallRotation()
    {
        PlayerMovement.Rotate(Player.Instance.rb, Player.Instance.rotationSpeed);
    }
    public static void CallJump()
    {
        PlayerMovement.Jump(Player.Instance.rb, Player.Instance.jumpForce);
    }
}