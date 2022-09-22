using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private Player _playerData; 
    public Invoker(Player playerData)
    {
        _playerData = playerData;
    }
    public void CallMove(float axis)
    {
        PlayerFunctions.Move(_playerData.gameObject, _playerData.speed, axis);
    }
    public void CallShoot()
    {
        PlayerFunctions.Shoot(_playerData.bullet, _playerData.shootPos);
    }
}