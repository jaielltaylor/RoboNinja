using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Transform myTransform;
    public GameObject target;
    public float attackDistance;
    public float spotDistance;
    public float speed;

    public GameObject explosion;
    public AudioClip onAttack;
    private AudioSource patrollerAudio;
    private Animator animator;
    public float rateOfAttack;
    private float nextAttackTime;

    private float escapeCounter = 0;
    private bool playerIn = false;
    public GameObject agent;

    void Start()
    {
        patrollerAudio = GetComponent<AudioSource>();
        myTransform = transform;
        nextAttackTime = Time.time;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Player is in Patrol Sights");
            playerIn = true;
            escapeCounter = 0;
            agent.gameObject.transform.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (playerIn == true)
        {
            Debug.Log("Player has been spotted");
            GameControl.control.score -= 10;
            animator.Play("Pursuit");
            myTransform.LookAt(target.transform);
            myTransform.position = Vector3.MoveTowards(myTransform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Player is out of view");
            playerIn = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Debug.Log("We call this a DIFFICULTY TWEAK!");
            SceneManager.LoadScene(2);
        }

        if (collision.transform.tag.Equals("Weapon"))
        {
            GameObject expl = (GameObject)Instantiate(explosion, myTransform.position, myTransform.rotation);
            GameControl.control.score += 10;
            GameControl.control.patrollersDestroyed += 1;
            animator.Play("Die");
            Destroy(gameObject);
            Destroy(expl, 2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerIn)
        {
            escapeCounter += Time.deltaTime;
        }

        if (escapeCounter >= 3)
        {
            Debug.Log("Player has escaped, returning to normal patrol!");
            agent.gameObject.transform.GetComponent<NavMeshAgent>().isStopped = false;
            GameControl.control.score += 5;
        }

        float distance = Vector3.Distance(myTransform.position, target.transform.position);
        if (distance <= attackDistance && playerIn)
        {   // The AI is in range to attack the player ("Attack" state)
            Debug.Log("In Hot Pursuit of Player");
            animator.Play("Pursuit");
            patrollerAudio.clip = onAttack;
            patrollerAudio.Play();
            myTransform.LookAt(target.transform);
            myTransform.position = Vector3.MoveTowards(myTransform.position, target.transform.position, speed * Time.deltaTime);

            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + rateOfAttack;
            }
            else
            {   // The AI is in "Pursuit" state
                animator.Play("Pursuit");
            }
        }
    }
}
