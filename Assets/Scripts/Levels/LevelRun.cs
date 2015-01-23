using UnityEngine;
using UnityEngine.UI;

public class LevelRun : MonoBehaviour 
{
	public Text m_letterW;
	private float alpha;
	private bool m_bIsPlatformVisible;
	private MaterialFadeAnim m_matFadeAnim;
	
	#region MONO FUNCTIONS
	private void Awake ()
	{
		alpha = 0.0f;
		m_bIsPlatformVisible = false;
		m_matFadeAnim = this.transform.FindChild("Platform").GetComponent<MaterialFadeAnim>();
	}
	
	private void Update ()
	{
		if(   m_bIsPlatformVisible == false
		   && Input.GetKeyUp(KeyCode.W))
		{
//			Debug.Log("bakit?????");
			m_bIsPlatformVisible = true;
			m_matFadeAnim.FadeIn();
		}
	
		if(alpha < 255)
		{
			alpha += 1.2f;
			Vector4 c = m_letterW.color;
			c.w += Time.deltaTime * alpha * Constants.ALPHA_RATIO;
			m_letterW.color = (Color) c;
		}
	}
	#endregion
}
