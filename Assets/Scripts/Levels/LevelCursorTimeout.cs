using UnityEngine;
using UnityEngine.UI;

public class LevelCursorTimeout : MonoBehaviour 
{
	public Text m_countterDisplay;

	private Transform m_transform;
	private Transform m_counterPos;
	private Vector3 m_prevPos;
	//TODO: counter position offset
//	private Vector3 m_ctrPosOffset;

	private int m_counter;
	private float m_distance;

	// required distance to update counter
	private const float m_cReqDist = 30.0f; 

	#region MONO FUNCTIONS
	private void Awake ()
	{
		m_counter = 100;
		m_distance = 0.0f;
		m_prevPos = Input.mousePosition;
		m_transform = this.transform;
		m_counterPos = m_transform.FindChild ("Counter").transform;
//		m_ctrPosOffset = Utilities.GetScreenPos (0.5f, 0.8f);
//		Debug.Log (m_ctrPosOffset);
	}

	private void Update () 
	{
		Vector3 mousepos = Input.mousePosition;
//		mousepos.x += m_ctrPosOffset.x;
//		mousepos.y -= m_ctrPosOffset.y;
		m_counterPos.position = mousepos;
	}

	private void LateUpdate ()
	{
		UpdateDistance (m_prevPos, m_counterPos.position);
		m_prevPos = m_counterPos.position;
	}
	#endregion

	private void UpdateCounter ()
	{
		m_counter--;

		if (m_counter <= 0) 
		{
			LevelMngr.Instance.LoadNextLevel(Constants.LVL_RUN);
		}
		else
		{
			m_countterDisplay.text = m_counter.ToString();
		}
	}

	private void UpdateDistance (Vector3 p_prevPos, Vector3 p_newPos)
	{

		m_distance += Vector2.Distance (new Vector2(p_prevPos.x, p_prevPos.y), 
		                                new Vector2(p_newPos.x, p_newPos.y));

		if(m_distance >= m_cReqDist)
		{
			UpdateCounter();
			m_distance = 0;
		}
	}
}
