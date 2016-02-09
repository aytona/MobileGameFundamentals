using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpriteTiler : EditorWindow {

	public string TileSpriteRootGameObjectName = "Tiled Object";

	public float GridXSlider = 1f;
	public float GridYSlider = 1f;

	public Sprite TileLevelSprite;

	[MenuItem("Week4 /Sprite Tiler")]
	public static void OpenSpriteTileWindow() {
		EditorWindow.GetWindow<SpriteTiler> (true, "Sprite Tiler");
	}



	void OnGUI() {
		
		GUILayout.Label ("Tile level object name", EditorStyles.boldLabel);
		TileSpriteRootGameObjectName = 
			GUILayout.TextField (TileSpriteRootGameObjectName, 30);
		GUILayout.Label ("X:" + GridXSlider, EditorStyles.boldLabel);
		GridXSlider = GUILayout.HorizontalScrollbar (GridXSlider, 1.0f, 0.0f, 30.0f);
		GridXSlider = (int)GridXSlider;
		GUILayout.Label ("Y:" + GridYSlider, EditorStyles.boldLabel);
		GridYSlider = GUILayout.HorizontalScrollbar (GridYSlider, 1.0f, 0.0f, 30.0f);
		GridYSlider = (int)GridYSlider;
		GUILayout.Label ("Sprite level file", EditorStyles.boldLabel);
		TileLevelSprite = EditorGUILayout.ObjectField (TileLevelSprite, typeof(Sprite), true) as Sprite;

		if (GUILayout.Button ("Create Level")) {
			if (GridXSlider == 0 && GridYSlider == 0) {
				ShowNotification (new GUIContent ("Must have either X or Y > 0"));
				return;
			}
			CreateSpriteTiledGameObject (GridXSlider, GridYSlider, 
				TileLevelSprite, TileSpriteRootGameObjectName);
		}

	}


	public static void CreateSpriteTiledGameObject(float GridXSlider, float GridYSlider,
		Sprite SpriteLevelFile, string RootObjectName) {

		// store the size of the sprite
		float spriteX = SpriteLevelFile.bounds.size.x;
		float spriteY = SpriteLevelFile.bounds.size.y;

		GameObject rootObject = new GameObject ();
		rootObject.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		rootObject.name = RootObjectName;

		int currentObjectCount = 0;
		int currentColumn = 0;
		int currentrow = 0;
		Vector3 currentLocation = new Vector3 (0.0f, 0.0f, 0.0f);

		while (currentrow < GridYSlider) {
			GameObject gridObject = new GameObject();
			gridObject.transform.SetParent (rootObject.transform);
			gridObject.name = RootObjectName + "_" + currentObjectCount;
			gridObject.transform.position = currentLocation;

			SpriteRenderer gridRenderer = 
				gridObject.AddComponent<SpriteRenderer> ();
			gridRenderer.sprite = SpriteLevelFile;
			gridObject.AddComponent<BoxCollider2D> ();
			currentLocation.x = currentLocation.x + spriteX;
			//currentLocation.y = currentLocation.y + spriteY;
			currentColumn++;

			if (currentColumn >= GridXSlider) {
				currentColumn = 0;
				currentrow++;
				currentLocation.x = 0;
				currentLocation.y = currentLocation.y - spriteY;

			}
			currentObjectCount++;
		}







	}

}
