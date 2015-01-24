using UnityEngine;
using System.Collections;

public class PlayerAudioMngr : MonoBehaviour 
{
	public AudioClip m_footstepSfx;
	public AudioClip m_gruntTakeOff;
	public AudioClip m_gruntLand;
	
	private AudioSource m_audioSource;
	private float m_soundPlayInterval;
	private float m_timeLapsed;
	private bool m_bDidJump;
	
	private CharacterController m_charController;
	private CharacterMotor m_charMotor;
	
	private void Awake ()
	{
		m_audioSource = GetComponent<AudioSource>();
		m_soundPlayInterval = 0.5f;
		m_timeLapsed = 0.0f;
		m_bDidJump = false;
		
		m_charController = GetComponent<CharacterController>();
		m_charMotor = GetComponent<CharacterMotor>();
	}
	
	private void Update ()
	{
		PlayFootStep();
		PlayGrunt();
	}
	
	private void PlayFootStep ()
	{
		if(m_charMotor.enabled == false)
		{
			return;
		}
		
		if(m_charController.isGrounded == false)
		{
			return;
		}
	
		m_timeLapsed += Time.deltaTime;
		if(m_timeLapsed < m_soundPlayInterval)
		{
			return;
		}
		
		if(		Input.GetKey(KeyCode.W)
		   ||	Input.GetKey(KeyCode.A)
		   ||	Input.GetKey(KeyCode.S)
		   ||	Input.GetKey(KeyCode.D))
		{
			m_timeLapsed = 0;
			m_audioSource.PlayOneShot(m_footstepSfx, Random.Range(0.5f, 0.8f));
		}
	}
	
	private void PlayGrunt ()
	{
		if(m_charMotor.enabled == false)
		{
			return;
		}
	
		if (	m_charController.isGrounded
			&&	Input.GetKeyDown(KeyCode.Space))
		{
			m_bDidJump = true;
			m_audioSource.PlayOneShot(m_gruntTakeOff, Random.Range(0.7f, 1.0f));
		}
		
//		if (	m_bDidJump
//		    &&	m_charController.isGrounded)
//		{
//			m_bDidJump = false;
//			m_audioSource.PlayOneShot(m_gruntLand, Random.Range(0.6f, 8.0f));
//		}
	}
}
