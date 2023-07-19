using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private int _minimumNPCsNeededToSolve = 3;
    public int NumberOfNPCsVisited { get; private set; }

    public void SetNumberOfNPCsVisited()
    {
        NumberOfNPCsVisited++;
    }

    public bool NPCVisited()
    {
        if (true)
        {
            return true;
        }
    }
}
