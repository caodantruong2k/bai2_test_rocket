using System.Collections;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _yOffset;

    [SerializeField] Transform cube;

    Vector3 vectorup;
    Vector3 vectordown;
    public float speed = 2;
    bool onTop;
    // Start is called before the first frame update
    private void Update()
    {
        var (pos, rot) = transform.position.CalculatePos(_yOffset, Time.time);
        transform.SetPositionAndRotation(pos, rot);
    }

    public void Init(float yOffset)
    {
        _yOffset = yOffset;
    }

    // Update is called once per frame



}
public static class CubeHelpers
{
    public const float HEIGHT_SCALE = 2.5f;
    public const float NOISE_SCALE = .4f;
    public static readonly quaternion RotGoal = quaternion.Euler(130, 50, 150);

    public static (Vector3 pos, Quaternion rot) CalculatePos(this Vector3 pos, float yOffset, float time)
    {
        var t = Mathf.InverseLerp(yOffset, HEIGHT_SCALE + yOffset, pos.y);
        var rot = Quaternion.Slerp(quaternion.identity, RotGoal, t);
        pos.y = HEIGHT_SCALE * Mathf.PerlinNoise(pos.x * NOISE_SCALE + time, pos.z * NOISE_SCALE + time) + yOffset * GameManager.DEPTH_OFFSET;
        return (pos, rot);
    }
}