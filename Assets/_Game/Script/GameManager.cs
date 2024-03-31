using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    private const int SIDE_LENGTH = 100;
    public const float DEPTH_OFFSET = 7;
    private static int Depth { get; set; } = 1;
    private void Start()
    {
        LoopPositions((i, p) =>
        {
            Instantiate(_cubePrefab, new Vector3(p.x, p.y * DEPTH_OFFSET, p.z), Quaternion.identity, transform)
                .AddComponent<Cube>()
                .Init(p.y);
        });


    }
    public static void LoopPositions(Action<int, Vector3> action)
    {
        var i = 0;
        for (var y = 0; y < Depth; y++)
        {
            for (var x = 0; x < SIDE_LENGTH; x++)
            {
                for (var z = 0; z < SIDE_LENGTH; z++)
                {
                    action(i++, new Vector3(x, y, z));
                }
            }
        }
    }
}
