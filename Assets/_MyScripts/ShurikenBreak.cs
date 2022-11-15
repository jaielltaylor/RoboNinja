using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Untagged"))
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
        }
    }
}
