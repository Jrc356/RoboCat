using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public void Kill() {
        Debug.Log("KILLING");
        Destroy(transform.gameObject);
    }
}
