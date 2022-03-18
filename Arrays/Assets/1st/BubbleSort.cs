using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    [SerializeField] private Transform[] a;

    private void Start()
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - i - 1; j++)
            {
                if (a[j].localScale.magnitude > a[j + 1].localScale.magnitude)
                {
                    Transform cnt = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = cnt;
                }
            }
        }

        Vector3 spawn = new Vector3(0, 0, 0);
        for (int i = 0; i < a.Length; i++)
        {
            a[i].transform.position = spawn;
            if(i+1 != a.Length)
            {
                spawn.x += a[i + 1].localScale.x / 2;
            }
            spawn.x += a[i].localScale.x/2 + 0.1f; 
        }
    }
}
