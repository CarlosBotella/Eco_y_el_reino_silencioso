using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn2 : MonoBehaviour
{
    public Lava lava;
    private void OnTriggerEnter(Collider other) {
        lava.c = 1;
    }
}
