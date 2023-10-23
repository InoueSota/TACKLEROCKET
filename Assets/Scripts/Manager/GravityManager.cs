using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public enum GravityPattern
    {
        LEFT,
        RIGHT,
        TOP,
        BOTTOM
    }
    public GravityPattern gravityPattern = GravityPattern.BOTTOM;

    public float gravityPower;
    public Vector2 gravity;

    // 同じ重力が続いている時間
    private float noChangeTime;
    // 重力を強くする時間間隔
    [SerializeField] private float changeInterval;

    void Start()
    {
        gravityPower = 0.2f;
    }

    void Update()
    {
        switch (gravityPattern)
        {
            case GravityPattern.LEFT:
                gravity.x = -gravityPower;
                gravity.y = 0f;
            break;
            case GravityPattern.RIGHT:
                gravity.x = gravityPower;
                gravity.y = 0f;
                break;
            case GravityPattern.TOP:
                gravity.x = 0f;
                gravity.y = gravityPower;
                break;
            case GravityPattern.BOTTOM:
                gravity.x = 0f;
                gravity.y = -gravityPower;
                break;
        }

        noChangeTime += Time.deltaTime;
        if (noChangeTime > changeInterval)
        {
            gravityPower *= 2f;
            noChangeTime = 0f;
        }
    }

    public void GravityInitialize(GravityPattern newPattern)
    {
        gravityPattern = newPattern;
        noChangeTime = 0f;
        gravityPower = 0.2f;
    }
}
