using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScreenMngr : MonoBehaviour 
{
	public Image m_bgImg;
	public Text m_endMsg;

	private void Start () 
	{
		StartCoroutine ("IEFadeIn");
	}
	
	private void Update () 
	{
		// wait for left mouse click
		if(Input.GetMouseButtonUp(0))
		{
			Application.LoadLevel(0);
		}
	}
	
	private IEnumerator IEFadeIn ()
	{
		while (m_bgImg.color.a < 1.0f)
		{
			Vector4 c = m_bgImg.color;
			c.w += Time.deltaTime * Constants.ALPHA_RATIO * 200.0f;
			m_bgImg.color = c;
			
			c = m_endMsg.color;
			c.w += Time.deltaTime * Constants.ALPHA_RATIO * 200.0f;
			m_endMsg.color = c;
			
			yield return 0;
		}
	}
}
