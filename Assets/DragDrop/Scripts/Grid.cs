using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid: MonoBehaviour
{

	[SerializeField] private Color color;

	// Start is called before the first frame update
	void Start()
    {





		Shader squareShader = Shader.Find("Unlit/Color");
		MeshRenderer[,] squareRenderers;
		SpriteRenderer[,] squarePieceRenderers;
		squareRenderers = new MeshRenderer[16, 16];
		squarePieceRenderers = new SpriteRenderer[16, 16];

		for (int rows = 0; rows < 16; rows++)
		{
			for (int column = 0; column < 16; column++)
			{
				// Create square
				Transform square = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
				square.parent = transform;
				square.name = "" + rows + "_" + column;
				square.transform.localPosition = new Vector3((rows * 100 ), (column * 100),-2);
				square.transform.localScale = new Vector3(10, 10, 0);
				//square.setColor("_color", new Color(0.0f, 0.5f, 50));
				//Material squareMaterial = new Material(squareShader);

				Material squareMaterial = new Material(squareShader);

				squareRenderers[column, rows] = square.gameObject.GetComponent<MeshRenderer>();
				squareRenderers[column, rows].material.SetColor("_Color", color * new Color(5,5,5));

				// Create piece sprite renderer for current square
				SpriteRenderer pieceRenderer = new GameObject("Piece").AddComponent<SpriteRenderer>();
				pieceRenderer.transform.parent = square;
				pieceRenderer.transform.position = new Vector3(rows, column);
				pieceRenderer.transform.localScale = new Vector3(0.01f,0.01f,1);
				squarePieceRenderers[column, rows] = pieceRenderer;
			}
		}


	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
