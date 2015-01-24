using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour 
{
	public CharacterController m_playerController;
	public CharacterMotor m_charMotor;
	
//	private void Update ()
//	{
//		if(IsWalking())
//		{
//			
//		}
//	}
	
	private bool IsWalking ()
	{
		if(		m_playerController.isGrounded
		   &&	Input.GetKey(KeyCode.W)
		   &&	Input.GetKey(KeyCode.A)
		   &&	Input.GetKey(KeyCode.S)
		   &&	Input.GetKey(KeyCode.D))
		{
			return true;
		}
		
		return false;
	}
}
