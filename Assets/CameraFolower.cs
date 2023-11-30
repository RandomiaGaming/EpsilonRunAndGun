using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CameraFolower : MonoBehaviour
{
    public Transform Target;
    public float dampning;
    public Vector2 min;
    public Vector2 max;
    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, dampning);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), -10);
       
    }
}
