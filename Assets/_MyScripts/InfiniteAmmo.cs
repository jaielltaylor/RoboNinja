using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteAmmo : MonoBehaviour
{
    public GameObject Ammunition;
    private GameObject clone;

    public void Spawn()
    {
        clone = Instantiate(Ammunition, this.transform.position, this.transform.rotation);
    }
}
