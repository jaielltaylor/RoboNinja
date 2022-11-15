using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Door;
    private AudioSource audioDoor;
    private Transform controlTransform;
    private Animator doorAnimator;

    void Start()
    {
        controlTransform = transform;
        doorAnimator = Door.GetComponent<Animator>();
        audioDoor = Door.GetComponent<AudioSource>();
        doorAnimator.enabled = true;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            if (Door.transform.tag.Equals("door2"))
            {
                doorAnimator.SetBool("isTwoOpen", true);
                audioDoor.Play();
            }

            if (Door.transform.tag.Equals("door3"))
            {
                doorAnimator.SetBool("isThreeOpen", true);
                audioDoor.Play();
            }

            if (Door.transform.tag.Equals("door4"))
            {
                doorAnimator.SetBool("isFourOpen", true);
                audioDoor.Play();
            }

            if (Door.transform.tag.Equals("door5"))
            {
                doorAnimator.SetBool("isFiveOpen", true);
                audioDoor.Play();
            }
            if (Door.transform.tag.Equals("exitdoor"))
            {
                GameControl.control.missionComplete = true;
                SceneManager.LoadScene(3);
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            if (Door.transform.tag.Equals("door2"))
            {
                doorAnimator.SetBool("isTwoOpen", false);
            }

            if (Door.transform.tag.Equals("door3"))
            {
                doorAnimator.SetBool("isThreeOpen", false);
            }

            if (Door.transform.tag.Equals("door4"))
            {
                doorAnimator.SetBool("isFourOpen", false);
            }

            if (Door.transform.tag.Equals("door5"))
            {
                doorAnimator.SetBool("isFiveOpen", false);
            }
        }
    }
}
