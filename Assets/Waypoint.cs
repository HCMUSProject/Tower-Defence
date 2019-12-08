using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    Color exploredColor;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField]
    Tower towerPrefab;

    const int gridSize = 10;

    void Start()
    {
        Physics.queriesHitTriggers = true;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                print(gameObject.name);
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
        }
    }
}
