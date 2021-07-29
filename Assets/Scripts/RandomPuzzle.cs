using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPuzzle : MonoBehaviour
{
    [Header ("Fix Attribute")]
    public List<Transform> spawner;
    public List<GameObject> puzzle;

    [Header("Temp Attribute")]
    public List<GameObject> tempPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        RandomPuzzlePieces();
    }

    public void RandomPuzzlePieces()
    {
        for (int i = 0; i < spawner.Count; i++)
        {
            int rand = Random.Range(0, tempPuzzle.Count);

            puzzle.Add(tempPuzzle[rand]);
            puzzle[i].transform.position = spawner[i].position;
            
            puzzle[i].GetComponent<DragDropPuzzle>().tempIndex = int.Parse(puzzle[i].name);
            puzzle[i].GetComponent<DragDropPuzzle>().tempSpawner = i + 1;
            puzzle[i].GetComponent<DragDropPuzzle>().setup = true;

            tempPuzzle.RemoveAt(rand);
        }
    }
}
