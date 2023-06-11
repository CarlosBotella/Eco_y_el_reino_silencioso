using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEcoHeal : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Eco;
    void Start()
    {
        Eco = GameObject.Find("ECO");
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 posPlayer = new Vector3(Eco.transform.position.x , Eco.transform.position.y , Eco.transform.position.z);
       transform.position = Vector3.MoveTowards(transform.position, posPlayer, 10 * Time.deltaTime);
    }
}
