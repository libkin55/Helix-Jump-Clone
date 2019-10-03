using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IDragHandler
{
    [SerializeField] private int speedRotation = 5;

    private BallSettings ballSettings;
    private LevelGeneration levelGeneration;

    public void OnDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0 && !ballSettings.isDie && !ballSettings.isWin)
            {
                RotateSections(-speedRotation);
            }
                
            if (eventData.delta.x < 0 && !ballSettings.isDie && !ballSettings.isWin)
            {
                RotateSections(speedRotation);
            }
        }
    }

    private void RotateSections(int speedRotate)
    {
        levelGeneration = FindObjectOfType<LevelGeneration>();

        for (int i = 0; i < levelGeneration.SpawnedSection.Count; i++)
        {
            levelGeneration.SpawnedSection[i].transform.Rotate(0, speedRotate, 0);
        }
    }

    private void Start()
    {
        ballSettings = FindObjectOfType<BallSettings>();
    }
}
