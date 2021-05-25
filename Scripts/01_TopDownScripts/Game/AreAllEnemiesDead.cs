using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreAllEnemiesDead : MonoBehaviour
{
    List<GameObject> listOfEnemies = new List<GameObject>();
    List<GameObject> listOfBreakableWalls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        listOfBreakableWalls.AddRange(GameObject.FindGameObjectsWithTag("BreakableWall"));
    }

    public void DestroyedCondition(GameObject condition)
    {
        if (listOfEnemies.Contains(condition))
        {
            listOfEnemies.Remove(condition);
        }
        if (listOfBreakableWalls.Contains(condition))
        {
            listOfBreakableWalls.Remove(condition);
        }
    }

    public bool AreTheyDestroyed()
    {
        if (listOfEnemies.Count <= 0 && listOfBreakableWalls.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
