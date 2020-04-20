using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InitializeOnPlay : MonoBehaviour
{
    [SerializeField] private TextAsset bytes;

    void Start()
    {
        AstarPath.active.data.DeserializeGraphs(bytes.bytes);
        AstarPath.active.Scan();
    }

}
