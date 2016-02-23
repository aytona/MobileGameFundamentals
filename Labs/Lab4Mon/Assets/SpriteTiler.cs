using UnityEngine;
using System.Collections;
using UnityEditor;

public class SpriteTiler : EditorWindow {

	public string RootObject = "GameLevel";
	public float MaxGroundTiles = 1.0f;
	public float MaxWaterTiles = 1.0f;
	public Sprite GroundSprite;
	public Sprite WaterSprite;

	[MenuItem("Lab4/Sprite Tiler")]
	public static void OpenSpriteTilerWindow() {
		EditorWindow.GetWindow<SpriteTiler> (true, "Sprite Tiler");
	}

	void OnGUI() {
		GUILayout.Label ("Level name", EditorStyles.boldLabel);
		RootObject = GUILayout.TextField (RootObject);

		GUILayout.Label (MaxGroundTiles + " Maximum number of ground tiles");
		MaxGroundTiles = GUILayout.HorizontalScrollbar (MaxGroundTiles, 
			1.0f, 0.0f, 30.0f);
		MaxGroundTiles = (int)MaxGroundTiles;
		GUILayout.Label ("Sprite Ground File",EditorStyles.boldLabel);
		GroundSprite = EditorGUILayout.ObjectField (GroundSprite, 
			typeof(Sprite), true) as Sprite;

		GUILayout.Label (MaxWaterTiles + " Maximum number of water tiles");
		MaxWaterTiles = GUILayout.HorizontalScrollbar (MaxWaterTiles, 
			1.0f, 0.0f, 30.0f);
		MaxWaterTiles = (int)MaxWaterTiles;
		GUILayout.Label ("Sprite Water File",EditorStyles.boldLabel);
		WaterSprite = EditorGUILayout.ObjectField (WaterSprite, 
			typeof(Sprite), true) as Sprite;

		if (GUILayout.Button ("Create Game Level")) {
			if (MaxGroundTiles == 0 && MaxWaterTiles == 0) {
				ShowNotification (new GUIContent ("Both tiles are zero"));
				return;
			}
			if (GroundSprite != null && WaterSprite != null) {
				if (GroundSprite.bounds.size.y != WaterSprite.bounds.size.y) {
					ShowNotification (new GUIContent ("Heights do not match!"));
					return;
				} else {
					// build the level and attach it to the hiearchy
					CreateGameLevel (MaxGroundTiles, MaxWaterTiles, GroundSprite,
						WaterSprite, RootObject);
				}
			} else {
				ShowNotification (new GUIContent ("One of the sprites does not exist"));
				return;
			}
		}
	}

	public static void CreateGameLevel(float MaxGroundTiles, float MaxWaterTiles, 
		Sprite GroundSprite, Sprite WaterSprite, string RootObject) {
		float spriteX = GroundSprite.bounds.size.x;
		float spriteY = GroundSprite.bounds.size.y;
		int objectCtr = 0;
		int tiles;
		Vector3 currentLocation = new Vector3 (0.0f, 0.0f, 0.0f);
		GameObject rootObject = new GameObject ();
		rootObject.name = RootObject;

		tiles = (int)Random.Range (0, MaxGroundTiles);
		for (int i = 0; i < tiles; i++) {
			GameObject gridObject = new GameObject ();
			gridObject.transform.SetParent (rootObject.transform);
			gridObject.name = RootObject + objectCtr;
			objectCtr += 1;
			gridObject.transform.position = currentLocation;
			SpriteRenderer gridRenderer = gridObject.AddComponent<SpriteRenderer> ();
			gridRenderer.sprite = GroundSprite;
			gridObject.AddComponent<BoxCollider2D> ();
			currentLocation.x += spriteX;
	
		}

	}


}
