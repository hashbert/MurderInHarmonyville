using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public static event Action OnDialogueEnd;
    public static event Action OnDialogueStart;
    public static event Action OnContinueClicked;
    public static event Action OnOptionSelected;

    public void DialogueEnd()
    {
        OnDialogueEnd?.Invoke();
    }

    public void DialogueStart()
    {
        OnDialogueStart?.Invoke();
    }
    public void ContinueClicked()
    {
        OnContinueClicked?.Invoke();
    }
    public void OptionSelected()
    {
        OnOptionSelected?.Invoke();
    }
}
