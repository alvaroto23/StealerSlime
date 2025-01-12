using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private float cameraSpeed;
    private float t;


    // Update is called once per frame
    private void Update()
    {
        t = cameraSpeed * Time.deltaTime;
        Mathf.Clamp01(t);
        transform.position = Vector2.Lerp(transform.position, target.position, t);
    }

}
