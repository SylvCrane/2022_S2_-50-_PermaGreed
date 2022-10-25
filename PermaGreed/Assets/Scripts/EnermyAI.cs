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
    [SerializeField] float timeToAttack = 4f;
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

        while (true)
        {
            float x = target.position.x + Random.Range(-10, 10);
            float z = target.position.z + Random.Range(-10, 10);
            float y = 2f;
            float hypo = Mathf.Sqrt((Mathf.Pow(2, x)) + (Mathf.Pow(2, z)));

            if (Physics.Raycast(transform.position, new Vector3(x, y, z), hypo) != true 
                && Physics.Raycast(transform.position, new Vector3((x + 2), y, (z + 2)), hypo) != true  //conditions to check around the spawn point (top left)
                && Physics.Raycast(transform.position, new Vector3((x + 2), y, (z - 2)), hypo) != true  //conditions to check around the spawn point (top right)
                && Physics.Raycast(transform.position, new Vector3((x - 2), y, (z - 2)), hypo) != true  //conditions to check around the spawn point (bottome left)
                && Physics.Raycast(transform.position, new Vector3((x - 2), y, (z + 2)), hypo) != true) //conditions to check around the spawn point (bottome right)
            {
                setSpawnLocation(x, y, z);
                break;
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); //calculating distance from enemy to player
        try
        {
            EngageTarget();
        }
        catch(System.Exception E)
        {

        }
        
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

    private void ChaseTarget() //set the player as detination for navMeshAgent, nMA will just handle the running + pathing of the enemy
    {
        navMeshAgent.SetDestination(target.position); 
    }

    private void AttackTarget() //attacking the player script, run wait timer after hitting player
    {
        if (canAttack == true)
        {
            playerBehavior.PlayerTakeDmg(attackDamage);
            canAttack = false;
            StartCoroutine(attackWait(timeToAttack));
        }  
    }

    private IEnumerator attackWait(float timeToAttack) //wait timer before enemy can attack again
    {
        yield return new WaitForSeconds(timeToAttack);
        canAttack = true;
    }

    void OnDrawGizmosSelected() //displaying the range with line drawn in unity (for debugging purpose n visual representation, no actual purpose in game)
    {
        Gizmos.color = Color.red; //new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
