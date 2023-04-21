using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowECO : MonoBehaviour
{
public Transform target; 
float moveSpeed = 8;
//float rotationSpeed = 3;

public Transform myTransform; 

void Awake()
{
myTransform = transform; 
}
void Start()
{
target = GameObject.FindWithTag("Player").transform; 

}

void Update () {
/*myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;*/

 Vector3 posPlayer = new Vector3(target.position.x +2 , transform.position.y , target.position.z -2);
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, moveSpeed * Time.deltaTime );


}
}
