using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField]
    Waypoint startPoint, endPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField]
    bool isRunning = true;

    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    void Start()
    {
        
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        Waypoint prev = endPoint.exploredFrom;
        while (prev != startPoint)
        {
            path.Add(prev);
            prev = prev.exploredFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                Waypoint neighbour = grid[neighbourCoordinates];
                
                QueueNewNeighbour(neighbour);
            }
        }
    }

    private void QueueNewNeighbour(Waypoint neighbour)
    {
        if (neighbour.isExplored || queue.Contains(neighbour)) {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.Log("asdf");
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                //waypoint.SetTopColor(Color.red);
            }
        }
        print(grid.Count);
    }
}
