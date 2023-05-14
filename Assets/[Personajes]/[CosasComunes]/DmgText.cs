using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgText : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyTime = 3f;
    public Vector3 Offset = new Vector3(0,0.01f,0);
    public Vector3 RandomPos = new Vector3(0.5f,0,0);
     private GameObject mainCamera;
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        Destroy(gameObject,destroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomPos.x,RandomPos.x),Random.Range(-RandomPos.y,RandomPos.y),Random.Range(-RandomPos.z,RandomPos.z));
    }

    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward , mainCamera.transform.rotation * Vector3.up);
    }



}
  