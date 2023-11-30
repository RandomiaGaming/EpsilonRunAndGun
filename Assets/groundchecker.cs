using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundchecker : MonoBehaviour {
    public bool Grounded;
    public LayerMask Ground;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            Grounded = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            Grounded = false;
        }
    }
}
