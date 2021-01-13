using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is based on the following:
/// http://wiki.unity3d.com/index.php/FramesPerSecond#FPSCounter.cs
/// </summary>
public class FPSLabel : MonoBehaviour
{
	/// <summary>
	/// The y-offset of the label inside the window in order to prevent visual overlapping
	/// </summary>
	private const float LABEL_OFFSET_Y = 20f;

	/// <summary>
	/// The initial percentage of the Screen.height to display the FPS Label. Default is 5%
	/// </summary>
	private const float HEIGHT_PERCENTAGE = 0.05f;

	/// <summary>
	/// This is the initial offset of the label. (0f, 0f) means top left of the screen. Defaut is (20f, 20f)
	/// </summary>
	private readonly Vector2 LABEL_OFFSET = new Vector2(20f, 20f);

	/// <summary>
	/// Determines the color of the label. Defaut is Color.white
	/// </summary>
	private readonly Color[] LABEL_COLORS = new Color[]
	{
		Color.white,
		Color.blue,
		Color.red,
		Color.green,
		Color.black
	};

	/// <summary>
	/// Whether to show the label or not initially
	/// </summary>
	private bool m_ShowLabel = true;

	/// <summary>
	/// Whether to show the milliseconds or not initially
	/// </summary>
	private bool m_ShowMSec = true;

	private float m_HeightPercentage;
	private float m_DeltaTime;
	private int m_ColorIndex;
	private string m_LabelText;
	private Rect m_WindowRect;
	private GUIStyle m_LabelStyle = new GUIStyle();

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		m_LabelStyle.alignment = TextAnchor.UpperLeft;
		m_LabelStyle.normal.textColor = LABEL_COLORS[m_ColorIndex];
		m_WindowRect.x = LABEL_OFFSET.x;
		m_WindowRect.y = LABEL_OFFSET.y;
		m_HeightPercentage = HEIGHT_PERCENTAGE;
	}

	private void Update()
	{
		m_DeltaTime += (Time.unscaledDeltaTime - m_DeltaTime)* 0.1f;
		CheckInputs();
	}

	private void OnGUI()
	{
		if (!m_ShowLabel)
		{
			return;
		}

		Rect labelRect = new Rect(LABEL_OFFSET.x, LABEL_OFFSET.y, Screen.width, 0f);
		m_LabelStyle.fontSize = (int)(Screen.height * m_HeightPercentage);
		UpdateText();

		Vector2 textSize = m_LabelStyle.CalcSize(new GUIContent(m_LabelText));
		labelRect.height = textSize.y;
		m_WindowRect.width = textSize.x+5f;
		m_WindowRect.height = labelRect.height+LABEL_OFFSET_Y+5f;
		m_WindowRect = GUI.Window(0, m_WindowRect, DoMyWindow, "");
		CheckGUIEvents();
	}

	private void DoMyWindow(int windowID)
	{
		GUI.Label(new Rect(0f, LABEL_OFFSET_Y, m_WindowRect.width, m_WindowRect.height), m_LabelText, m_LabelStyle);
		GUI.DragWindow(new Rect(0f, 0f, m_WindowRect.width, m_WindowRect.height));
	}

	private void UpdateText()
	{
		float fps = 1f / m_DeltaTime;
		if (m_ShowMSec)
		{
			float msec = m_DeltaTime * 1000f;
			m_LabelText = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		}
		else
		{
			m_LabelText = string.Format("{0:0.} fps", fps);
		}
	}

	private void CheckGUIEvents()
	{
		Event e = Event.current;
		bool contains = m_WindowRect.Contains(e.mousePosition);

		// Check for double-click in order 
		if (e.type == EventType.Used &&
			e.clickCount == 2 &&
			contains)
		{
			// If left mouse button, toggle milliseconds
			if(e.button == 0)
			{
				m_ShowMSec = !m_ShowMSec;
			}
			// If right mouse button, change color
			else if(e.button == 1)
			{
				m_ColorIndex++;
				if(m_ColorIndex >= LABEL_COLORS.Length)
				{
					m_ColorIndex = 0;
				}
				m_LabelStyle.normal.textColor = LABEL_COLORS[m_ColorIndex];
			}
		}
		// Check for mouse wheel double-click in order to reset the label's size and offset
		else if (e.button == 2 && e.clickCount == 2)
		{
			m_HeightPercentage = HEIGHT_PERCENTAGE;
			m_WindowRect.x = LABEL_OFFSET.x;
			m_WindowRect.y = LABEL_OFFSET.y;
		}
		// Check for mouse scroll in order to scale the label's size
		else if (e.isScrollWheel && contains)
		{
			if (e.delta.y < 0f)
			{
				m_HeightPercentage += 0.01f;
			}
			else if (e.delta.y > 0f)
			{
				m_HeightPercentage -= 0.01f;
			}
			m_HeightPercentage = Mathf.Clamp(m_HeightPercentage, 0.02f, 0.25f);
		}
	}

	private void CheckInputs()
	{
		// If both mouse buttons have been pressed, it toggles the label
		if (Input.GetMouseButtonDown(0)&& Input.GetMouseButton(1)||
			Input.GetMouseButtonDown(1)&& Input.GetMouseButton(0))
		{
			m_ShowLabel = !m_ShowLabel;
		}
	}
}