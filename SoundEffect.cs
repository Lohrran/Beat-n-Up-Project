using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {
	
	public static SoundEffect Instance;
	
	public AudioClip punchPlayer;
	public AudioClip damagePlayer;
	public AudioClip death;
	public AudioClip elevatorBeep;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Existem Multiplas Instancia dos Script SoundEffect");
		}
		
		Instance = this;
		
	}
	
	public void MakeDeathSound()
	{
		MakeSound (death);
	}
	
	public void MakePlayerPunchSound()
	{
		MakeSound (punchPlayer);
	}
	
	public void MakePlayerDamageSound()
	{
		MakeSound (damagePlayer);
	}

	public void MakeElevatorBeepSound()
	{
		MakeSound (elevatorBeep);
	}

	
	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}
}
