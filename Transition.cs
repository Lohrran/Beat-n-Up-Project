 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Transition : MonoBehaviour
{

    private Animator animCamera;
    private int cameraMoveController;

    public bool canActive = false;
    public bool actived = false;

    [HideInInspector]
    public bool cameraAnimationIsFinish = false;

    private GameObject player;
	[HideInInspector]
    public PlayerScript playerController;
    private bool playerGoNextFloor = false;
    private Animator animPlayer;

    private GameObject characterObject;

    public List<GameObject> elevatorTarget = new List<GameObject>();
    public List<GameObject> middleScreenTarget = new List<GameObject>();
	public List<GameObject> elevators = new List<GameObject>();

	private Animator animElevator;

    [SerializeField]
    private List <GameObject> spawnFatherEnemies = new List<GameObject>();

	private float time = 1f;

    void Start()
    {
        animCamera = Camera.main.gameObject.GetComponent<Animator>();
		animElevator = elevators.First().gameObject.GetComponent<Animator> ();

        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.gameObject.GetComponent<PlayerScript>();
        animPlayer = player.GetComponent<Animator>();

        characterObject = GameObject.Find("Character");
    }

    void Update()
    {
        animElevator = elevators.First().gameObject.GetComponent<Animator>();
        if (canActive == true)
        {
			animElevator.SetBool("open", true);
			SoundEffect.Instance.MakeElevatorBeepSound();
            if (actived == true)
            {
                PlayerGoInsideElevator();

                if (player.transform.position.y == elevatorTarget.First().transform.position.y)
                {
                    Destroy(elevatorTarget.First());
                    elevatorTarget.RemoveAt(0);

					animElevator.SetBool("open", false);

					PlayerGoToNextFloor();

                    cameraMoveController += 1;

                    canActive = false;
					actived = false;
                }
            }
        }
        else
        {
            actived = false;
        }

        if (playerGoNextFloor == true)
        {
            MoveCamera();
            if (cameraAnimationIsFinish == true)
            {
				animElevator.SetBool("open", true);

                PlayerGoToMiddleOfScreen();
                if (player.transform.position.y == middleScreenTarget.First().transform.position.y)
                {
                    spawnFatherEnemies.First().SetActive(true);

                    Destroy(middleScreenTarget.First());
                    middleScreenTarget.RemoveAt(0);

					animElevator.SetBool("open", false);

                    playerController.controller = true;
                    player.GetComponent<Punch>().enabled = true;
                    player.GetComponent<BlockToScreen>().enabled = true;
                    cameraAnimationIsFinish = false;
                    playerGoNextFloor = false;
                    animPlayer.SetBool("walk", false);
                }
            }
        }
    }

    private void PlayerGoInsideElevator()
    {
        playerController.controller = false;
        player.GetComponent<Punch>().enabled = false;
        player.GetComponent<BlockToScreen>().enabled = false;

        player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(0, elevatorTarget.First().transform.position.y), 0.3f * Time.deltaTime);
        animPlayer.SetBool("walk", true);
    }

    private void PlayerGoToNextFloor()
    {
        characterObject.transform.position = new Vector2(0, characterObject.transform.position.y + 1.66f);
        playerGoNextFloor = true;
        animPlayer.SetBool("walk", false);
		time = 1f;
    }

    private void PlayerGoToMiddleOfScreen()
    {
		time = time - Time.deltaTime;

		if (time <= 0)
		{
        	player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(0, middleScreenTarget.First().transform.position.y), 0.3f * Time.deltaTime);
			animPlayer.SetBool("walk", true);
		}
	}

    private void MoveCamera()
    {
        animCamera.SetInteger("Move", cameraMoveController);
    }

	public void DestroyElevatorDoor()
	{
		Destroy(elevators.First());
		elevators.RemoveAt(0);
	}

    public void DestroySpawnEnemies()
    {
        Destroy(spawnFatherEnemies.First());
        spawnFatherEnemies.RemoveAt(0);
    }

}
