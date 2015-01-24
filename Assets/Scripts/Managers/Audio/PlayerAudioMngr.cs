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
	private bool m_bJustLanded;
	private bool m_bJustJumped;
	
	private CharacterController m_charController;
	private CharacterMotor m_charMotor;
	
	private void Awake ()
	{
		m_audioSource = GetComponent<AudioSource>();
		m_soundPlayInterval = 0.5f;
		m_timeLapsed = 0.0f;
		m_bJustLanded = true;
		m_bJustJumped = true;
		
		m_charController = GetComponent<CharacterController>();
		m_charMotor = GetComponent<CharacterMotor>();
	}
	
	private void Update ()
	{
		PlayFootStep();
		PlayGruntJump();
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
	
	private void PlayGruntJump ()
	{
		if(m_charMotor.enabled == false)
		{
			return;
		}
		
		if(m_charMotor.jumping.enabled == false)
		{
			return;
		}
	
		if (m_charController.isGrounded)
		{
			if(!m_bJustLanded)
			{
				m_bJustLanded = true;
				m_bJustJumped = true;
				m_audioSource.PlayOneShot(m_gruntLand, Random.Range(0.7f, 1.0f));
				m_audioSource.PlayOneShot(m_footstepSfx, Random.Range(0.5f, 0.8f));
			}
		}
		else
		{
			m_bJustLanded = false;
			
			if(m_bJustJumped)
			{
				m_bJustJumped = false;
				m_audioSource.PlayOneShot(m_gruntTakeOff, Random.Range(0.7f, 1.0f));
			}
		}
	}
}
