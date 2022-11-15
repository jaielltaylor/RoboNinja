using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetDoor : MonoBehaviour
{
    public Material activeMaterial;
    public AudioSource alarm;
    public GameObject Door;
    public GameObject Blockade;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Weapon"))
        {
            this.gameObject.transform.GetComponent<MeshRenderer>().material = activeMaterial;
            Door.GetComponent<BoxCollider>().enabled = true;
            Blockade.SetActive(false);
            GameControl.control.score += 20;
            alarm.loop = true;
            alarm.Play();
        }
    }
}
