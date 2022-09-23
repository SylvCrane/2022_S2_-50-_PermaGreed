using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnermyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target; //the player
    [SerializeField] float attackRange = 5f; //the range which enemy can attack (
    [SerializeField] int attackDamage = 5; //enemy dmg per hit
    bool canAttack; //boolean check if the enemy can attack to avoid enemy from lasor beaming player

    public PlayerBehaviour playerBehavior; //to store playerBehavior so player can take dmg

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //adding the enemy to the navMesh
        target = GameObject.FindWithTag("Player").transform; //setting attack target to the player
        playerBehavior = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>(); //getting playerBehavior script reference to deal dmg to player hp
        attackRange = navMeshAgent.stoppingDistance; //setting attack range to the navMeshAgent stopping distance
        canAttack = true; //allow enemy to attack

        //setSpawnLocation((target.position.x + Random.Range(-50, 50)) , 1.5f, (target.position.z + Random.Range(-50, 50)));
        setSpawnLocation(-150, 1.5f, 210);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); //calculating distance from enemy to player
        EngageTarget();
    }

    public void setSpawnLocation(float x, float y, float z) //warping enemy
    {
        navMeshAgent.Warp(new Vector3(x, y, z));
    }

    private void EngageTarget() //how enemy deal with the player, to chase ? or to attack ?
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget(); 
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position); //
    }

    private void AttackTarget()
    {
        if (canAttack == true)
        {
            playerBehavior.PlayerTakeDmg(attackDamage);
            canAttack = false;
            StartCoroutine(attackWait());
        }  
    }

    private IEnumerator attackWait()
    {
        yield return new WaitForSeconds(4f);
        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
