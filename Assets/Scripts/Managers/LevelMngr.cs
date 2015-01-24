using UnityEngine;

public class LevelMngr : MonoBehaviour 
{
	private static LevelMngr m_instance;
	public static LevelMngr Instance {get { return m_instance; }}
	
	private Transform  m_transform;
	private GameObject m_gameObject;
	private GameObject m_currLevel;

	#region MONO FUNCTIONS
	private void Awake ()
	{
		m_instance = this;
		m_gameObject = this.gameObject;
		m_transform = this.transform;
		m_currLevel = null;
	}

	private void Start () 
	{
		LoadNextLevel (Constants.LVL_THEBUTTON);
	}
	#endregion

	public void LoadNextLevel (string p_lvlName)
	{
		// TODO: consider object pooling...
		// TODO: group levels and singit force garbage collection. (see Bibby's architecture)

		if (m_currLevel != null) 
		{
			Destroy (m_currLevel);
		}

		m_currLevel = GameObject.Instantiate(Resources.Load ("Prefabs/" + p_lvlName)) as GameObject;
		m_currLevel.name = p_lvlName;
		m_currLevel.transform.SetParent (m_transform);
	}
}
