using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private static int _minimumNPCsNeededToSolve = 3;
    private static int NumberOfNPCsVisited = 0;
    public static event Action OnNPCVisitedForFirstTime;

    [YarnCommand("addToNPCsVistedCount")]
    public void AddToNPCVisitedCount()
    {
        NumberOfNPCsVisited++;
        OnNPCVisitedForFirstTime?.Invoke();
        print("visited " + NumberOfNPCsVisited + " people so far");
    }

   [YarnFunction("getNPCsVistedCount")]
   public static int GetNPCsVisitedCount()
    {
        return NumberOfNPCsVisited;
    }

    [YarnFunction("getMinNPCsVistedCount")]
    public static int GetMinNPCsVisitedCount()
    {
        return _minimumNPCsNeededToSolve;
    }

}
