using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Target : MonoBehaviour {
    public UnityEvent Collide;
    public float Damage;
    public void collide(float damage)
    {
        Damage = damage;
        Collide.Invoke();
    }

}
