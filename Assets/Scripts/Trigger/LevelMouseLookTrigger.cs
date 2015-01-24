using UnityEngine;
using System.Collections;

public class LevelMouseLookTrigger : MonoBehaviour 
{
	private MouseLook m_mouseLookX;
	private MouseLook m_mouseLookY;
	private bool m_bAlreadyHit;
	
	private void Awake ()
	{
		m_mouseLookX = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
		m_mouseLookY = m_mouseLookX.transform.FindChild("Eye (Main Camera)").GetComponent<MouseLook>();
		m_bAlreadyHit = false;
	}
	
	private void OnTriggerEnter (Collider p_collider)
	{
		if( 	m_bAlreadyHit == false
		   && 	p_collider.CompareTag("Player"))
		{
			m_bAlreadyHit = true;
			m_mouseLookX.enabled = true;
			m_mouseLookY.enabled = true;
			LevelMngr.Instance.LoadNextLevel(Constants.LVL_MOUSELOOK);
		}
	}
}
