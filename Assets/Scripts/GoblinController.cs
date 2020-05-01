using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinController : MonoBehaviour
{
    int maxHealth = 100;
    int curHealth = 100;

    public float lookRadius = 10f;
    public Animator anim_2;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Stick.R" || col.gameObject.name == "Bip001 Prop2")
        {
            Debug.Log("Hit");
            curHealth -= 10;
            if(curHealth <= 0) Destroy(gameObject);
            Debug.Log(curHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))); //tesing animation movement for npc
            //anim2.SetFloat

            anim_2.SetFloat("Speed_2", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
            if (distance <= agent.stoppingDistance+1 && !anim_2.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim_2.SetTrigger("Attack");
                Debug.Log("Goblin Attack");
            }
            
        }
      
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    

}
