using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "New Enemy")]
public class EnemySO : ScriptableObject
{
    public List<int> Enemies;
}