using UnityEngine;
using System.Collections;

public class Position2DMatcher : MonoBehaviour
{
    public Transform matchPositionTransform;

    void Update()
    {
        var matchPos = matchPositionTransform.position;
        transform.position = new Vector3(matchPos.x, matchPos.y, transform.position.z);
    }
}
