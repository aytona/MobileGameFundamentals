using UnityEngine;
using System.Collections;

public class LevelPieceManager : MonoBehaviour {

	public LevelPiece StartingLevelPiece;
	public LevelPiece[] LevelPieces;
	public float LevelPiecesMoveRate;
	private LevelPiece[] ActiveLevelPieces;
	private Vector3 leftPos, rightpos;

	// Use this for initialization
	void Start () {
		ActiveLevelPieces = new LevelPiece[2];
		ActiveLevelPieces[0] = StartingLevelPiece;
		ActiveLevelPieces[1] = GetRandomLevelPiece();
		//leftPos = StartingLevelPiece.transform.position
		ActiveLevelPieces[1].transform.position = StartingLevelPiece.gameObject.transform.FindChild("EndLocation").position;
	}

	// Update is called once per frame
	void Update () {
		int j;
		for (int i = 0; i < ActiveLevelPieces.Length; i++)
		{
			Vector3 newLocation = ActiveLevelPieces[ i ].transform.position;
			newLocation.x -= LevelPiecesMoveRate * Time.deltaTime;
			print (newLocation.x);
			ActiveLevelPieces[ i ].transform.position = newLocation;

			if (ActiveLevelPieces[ i ].transform.position.x < transform.position.x)
			{
				print (transform.position.x);
				if (ActiveLevelPieces[ i ] == StartingLevelPiece)
				{
					ActiveLevelPieces[ i ].gameObject.SetActive( false );
				}

				ActiveLevelPieces[ i ].transform.position = ActiveLevelPieces[ i ].GetInitialLocation( );
				ActiveLevelPieces[ i ] = GetRandomLevelPiece( );
			
				ActiveLevelPieces[ i ].transform.position = 
					FindOtherLevelPiece( ActiveLevelPieces[ i ] ).gameObject.transform.FindChild( "EndLocation" ).position;
			}
		}
	}

	private LevelPiece FindOtherLevelPiece(LevelPiece CurrentLevelPiece)
	{
		for (int i = 0; i < ActiveLevelPieces.Length; i++)
		{
			if (ActiveLevelPieces[ i ] != CurrentLevelPiece)
			{
				return ActiveLevelPieces[ i ];
			}
		}
		return null;
	}
	private LevelPiece GetRandomLevelPiece()
	{
		LevelPiece returnPiece = null;
		while (returnPiece == null)
		{
			for (int i = 0; i < LevelPieces.Length; i++)
			{
				if ( !isActivePiece( LevelPieces[ i ] ) )
				{
					returnPiece = LevelPieces[ i ];
				}
			}
		}
		return returnPiece;
	}

	// Check if LevelPiece
	// is already used.
	private bool isActivePiece(LevelPiece Piece)
	{
		for (int i = 0; i < ActiveLevelPieces.Length; i++)
		{
			if (Piece == ActiveLevelPieces[ i ])
			{
				return true;
			}
		}
		return false;
	}
}

