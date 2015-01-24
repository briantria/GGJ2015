using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathZoneMngr : MonoBehaviour 
{
	private GameObject m_player;
	private Image m_fadeScreen;
	private Vector4 m_screenColor;
	
	private void Awake ()
	{
		m_player = GameObject.FindGameObjectWithTag("Player").gameObject;
		m_fadeScreen = GameObject.Find("FadeScreen").transform.FindChild("Image").GetComponent<Image>();
		m_screenColor = m_fadeScreen.color;
	}
	
	private void OnTriggerEnter (Collider p_collider)
	{
		if(p_collider.CompareTag("Player"))
		{
			StartCoroutine("ResetGame");
		}
	}
	
	private IEnumerator ResetGame ()
	{
		// fade to black
		while (m_screenColor.w < 1.0f)
		{
			m_screenColor.w += Time.deltaTime * 120.0f * Constants.ALPHA_RATIO;
			m_fadeScreen.color = m_screenColor;
			yield return 0;
		}
	
		// reset player
		m_player.transform.position = Constants.PLAYER_INITPOS;
		m_player.transform.localScale = Vector3.one;
		m_player.transform.eulerAngles = Vector3.zero;
		yield return new WaitForSeconds(0.3f);
		
		// fade to black
		while (m_screenColor.w > 0.0f)
		{
			m_screenColor.w -= Time.deltaTime * 120.0f * Constants.ALPHA_RATIO;
			m_fadeScreen.color = m_screenColor;
			yield return 0;
		}
	}
}
