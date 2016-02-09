using UnityEngine;
using System.Collections;
using UnityEditor;

public class LevelEditor : EditorWindow {

	public string LevelName = "Level 1";
	public Sprite GroundSprite;
	public Sprite WaterSprite;
	public float MaxGroundSprites = 1f;
	public float MaxWaterSprites = 1f;

	[MenuItem("Lab4/LevelEditor")]
	public static void OpenLevelEditorWindow()
	{
		EditorWindow.GetWindow<LevelEditor> (true, "Level Editor");
	}

	void OnGUI ()
	{
		GUILayout.Label ("Level Name", EditorStyles.boldLabel);
		LevelName = GUILayout.TextField (LevelName, 20);

		GUILayout.Label ("Ground Sprite", EditorStyles.boldLabel);
		GroundSprite = EditorGUILayout.ObjectField (GroundSprite, typeof(Sprite), true) as Sprite;

		GUILayout.Label ("Water Sprite", EditorStyles.boldLabel);
		WaterSprite = EditorGUILayout.ObjectField (WaterSprite, typeof(Sprite), true) as Sprite;

		GUILayout.Label (MaxGroundSprites + "Max Ground Sprites", EditorStyles.boldLabel);
		MaxGroundSprites = GUILayout.HorizontalScrollbar (MaxGroundSprites, 1.0f, 0.0f, 20.0f);
		MaxGroundSprites = (int)MaxGroundSprites;

		GUILayout.Label (MaxWaterSprites + "Max Water Sprites", EditorStyles.boldLabel);
		MaxWaterSprites = GUILayout.HorizontalScrollbar (MaxWaterSprites, 1.0f, 0.0f, 20.0f);
		MaxWaterSprites = (int)MaxWaterSprites;

		if (GUILayout.Button ("Create Level"))
		{
			if (MaxGroundSprites == 0 || MaxWaterSprites == 0) 
			{
				ShowNotification (new GUIContent ("The numbers must be nonzero"));
				return;
			}
			if (GroundSprite == null || WaterSprite == null)
			{
				ShowNotification (new GUIContent ("Please choose the sprites"));
				return;
			}
			if (GroundSprite.bounds.size.y != WaterSprite.bounds.size.y)
			{
				ShowNotification (new GUIContent ("Sprites must be of same height"));
				return;
			}

			CreateLevel(LevelName, GroundSprite, WaterSprite, MaxGroundSprites, MaxWaterSprites);
		}
	}

	public static void CreateLevel (string name, Sprite sp1, Sprite sp2, float maxSp1, float maxSp2)
	{
		float xGround = sp1.bounds.size.x;
		float xWater = sp2.bounds.size.x;
		Vector3 currentLocation = new Vector3 (0, 0, 0);
		int objectCount = 0;
		int groundTiles = (int)Random.Range (0, maxSp1);
		int waterTiles = (int)Random.Range (0, maxSp2);

		GameObject rootObject = new GameObject ();
		rootObject.name = name;

		for (int i = 0; i < groundTiles; i++)
		{
			GameObject levelObject = new GameObject();
			levelObject.transform.SetParent(rootObject.transform);
			levelObject.name = name + objectCount;
			objectCount++;
			levelObject.transform.position = currentLocation;
			currentLocation.x += xGround;
			SpriteRenderer levelRenderer = levelObject.AddComponent<SpriteRenderer>();
			levelRenderer.sprite = sp1;
			levelObject.AddComponent<BoxCollider2D>();
		}
	}
}
