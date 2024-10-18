using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int depth;
    [SerializeField] Transform mapPiecePrefab;

    [SerializeField] float maxHeight;
    [SerializeField] float wildness = 4f;

    Transform[,] map;

    void Start()
    {
        map = new Transform[width, depth];
        GenerateMapPieces();
    }

    private void GenerateMapPieces()
    {
        float startX = Random.Range(0, 0.5f);
        float startZ = Random.Range(0, 0.5f);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                var piece = Instantiate(mapPiecePrefab, transform);
                piece.localPosition = new Vector3(x, 0, z);

                var height = Mathf.PerlinNoise(
                    startX + (float)x/(width/ wildness),
                    startZ + (float)z/(depth/ wildness));
                piece.localScale = new Vector3(1, height * maxHeight, 1);
                map[x,z] = piece;
            }
        }
    }
}
