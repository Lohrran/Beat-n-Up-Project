using UnityEngine;
using System.Collections;

public enum EnemyStatusType
{
    Walking,
    Waiting,
    Attack,
    Punch,
    TakePunch
}

public class EnemyAI : MonoBehaviour
{
    [HideInInspector]
    public int id;

    private Animator anim;

    [SerializeField]
    private EnemyStatusType statusType = EnemyStatusType.Walking;
    private Transform playerTransform;
    
    // PUNCH DISTANCE.
    private const float PunchDistance = 0.1f;

    // ATTACK SPEED.
    private float attackSpeed = 0.3f;

    // WALKING DISTANCE.
    private float walkingDistance;
    // Max & Min WALKING DISTANCE
    private const float MinWalkingDistance = 0.1f;
    private const float MaxWalkingDistance = 0.9f;

    // WALKING SPEED
    private Vector2 walkingSpeed;
    // Max & Min WALKING SPEED X
    private const float MinWalkingSpeedX = 0.1f;
    private const float MaxWalkingSpeedX = 0.3f;
    // Max & Min WALKING SPEED Y
    private const float MinWalkingSpeedY = 0.05f;
    private const float MaxWalkingSpeedY = 0.1f;

    [HideInInspector]
    public SpawnEnemy spawnScript;

	public float punchRate = 0.5f;
	[HideInInspector] public float punchCooldown;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>(); 

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        walkingSpeed = new Vector2
        (  
            Random.Range(MinWalkingSpeedX, MaxWalkingSpeedX),
            Random.Range(MinWalkingSpeedY, MaxWalkingSpeedY)
        );

        walkingDistance = Random.Range(MinWalkingDistance, MaxWalkingDistance);

		punchCooldown = 0;
    }

    void Update()
    {
        if (statusType == EnemyStatusType.Attack)
        {
            UpdateAttack();
        }
        else if (statusType == EnemyStatusType.Walking)
        {
            UpdateWalking();
        }
        else if (statusType == EnemyStatusType.Waiting)
        {
            UpdateWaiting();
        }
        
        else if (statusType == EnemyStatusType.Punch) 
        {
            UpdatePunch();
        }

        else
        {
            UpdateTakePunch();
        }

        Flip();
        UpdateAnimation();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - 0.09f);
		CoolDown ();
    }

    private void UpdateWalking()
    {
        Vector2 currentPlayerPosition = playerTransform.position;
        Vector2 movement = Vector2.zero;

        if (transform.position.x >= currentPlayerPosition.x)
        {
            movement.x = -walkingSpeed.x;
        }
        else
        {
            movement.x = walkingSpeed.x;
        }

        if (transform.position.y >= currentPlayerPosition.y)
        {
            movement.y = -walkingSpeed.y;
        }
        else
        {
            movement.y = walkingSpeed.y;
        }

        // Se chegar próximo da distãncia, muda o status para WAITING.
        if (Vector2.Distance(transform.position, currentPlayerPosition) < walkingDistance)
        {
            statusType = EnemyStatusType.Waiting;
        }

        // Movimenta na direção escolhida acima.
        transform.Translate(movement * Time.deltaTime);
    }

    public void UpdateWaiting()
    {
    }

    private void UpdateAttack()
    {
        Vector2 currentPlayerPosition = playerTransform.position;
        Vector2 target = currentPlayerPosition;

        if (Vector2.Distance(transform.position, target) < PunchDistance)
        {
			if (punchCooldown <= 0)
			{
            	statusType = EnemyStatusType.Punch;
				punchCooldown = punchRate;
			}
        }

        transform.position = Vector2.MoveTowards(transform.position, target, attackSpeed * Time.deltaTime);
    }

    private void UpdatePunch()
    {
        Vector2 currentPlayerPosition = playerTransform.position;
        Vector2 target = currentPlayerPosition;

        if (Vector2.Distance(transform.position, target) > PunchDistance)
        {
            statusType = EnemyStatusType.Attack;
        }
    }

    private void UpdateTakePunch()
    {
        Vector2 currentPlayerPosition = playerTransform.position;
        Vector2 target = currentPlayerPosition;

        if (Vector2.Distance(transform.position, target) > PunchDistance)
        {
            statusType = EnemyStatusType.Attack;
        }
    }

    public void Attack()
    {
        statusType = EnemyStatusType.Attack;
    }

    public void TakePunch()
    {
        statusType = EnemyStatusType.TakePunch;   
    }


    void Flip()
    {
        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    void UpdateAnimation ()
	{
        if (statusType == EnemyStatusType.Waiting)
		{
			anim.SetBool ("walk", false);
		}
		else 
		{
			anim.SetBool ("walk", true);
		}

        if (statusType == EnemyStatusType.Punch)
		{
			anim.SetBool("punch", true);
		}
		else
		{
			anim.SetBool("punch", false);
		}


        if (statusType == EnemyStatusType.TakePunch)
        {
            anim.SetBool("takePunch", true);
        }
        else
        {
            anim.SetBool("takePunch", false);
        }

	}

    public void Dead()
    {
        spawnScript.RemoveAtList(gameObject);

        Destroy(gameObject, 1);
    }
	void CoolDown()
	{
		if (punchCooldown > 0) 
		{
			punchCooldown -= Time.deltaTime;		
		}
	}
}
