using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetX;
    public float offsetY;
    public float smoothing = 5f; 
    public bool updateCamera = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!updateCamera) return;
        Vector3 newPosition = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.unscaledDeltaTime);
        
    }
}
