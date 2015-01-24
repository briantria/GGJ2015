using UnityEngine;
using System.Collections;

public class LevelJumpTrigger : MonoBehaviour 
{
	private CharacterMotor m_charMotor;
	private bool m_bAlreadyHit;
	
	private void Awake ()
	{
		m_charMotor = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMotor>();
		m_bAlreadyHit = false;
	}

	private void OnTriggerEnter (Collider p_collider)
	{
		if( 	m_bAlreadyHit == false
			&& 	p_collider.CompareTag("Player"))
		{
			m_bAlreadyHit = true;
			m_charMotor.jumping.enabled = true;
			LevelMngr.Instance.LoadNextLevel(Constants.LVL_JUMP);
		}
	}
}
