using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    int DamageValue = 20;

    public int GetDamageValue()
    {
        return DamageValue;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
