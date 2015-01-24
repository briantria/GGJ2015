using UnityEngine;
using System.Collections;

public class LevelDownBelowTrigger : MonoBehaviour 
{
	private bool m_bAlreadyHit;
	
	private void Awake ()
	{
		m_bAlreadyHit = false;
	}
	
	private void OnTriggerEnter (Collider p_collider)
	{
		if( 	m_bAlreadyHit == false
		   && 	p_collider.CompareTag("Player"))
		{
			m_bAlreadyHit = true;
			LevelMngr.Instance.LoadNextLevel(Constants.LVL_DOWNBELOW);
		}
	}
}
