using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriangleBlink : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private float _fadeTime = .5f;
    void Start()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0f, _fadeTime).setLoopPingPong().setDelay(_delayTime);
    }
}
