using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour , IDamagable
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
