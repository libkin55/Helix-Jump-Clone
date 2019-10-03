using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject targetSection;
    private BallSettings ballSettings;
    private void Start()
    {
        ballSettings = FindObjectOfType<BallSettings>();
        targetSection = ballSettings.ThisSection;
    }

    private void Update()
    {
        targetSection = ballSettings.ThisSection;

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetSection.transform.position.y + 1f, transform.position.z), Time.deltaTime * 10f);
    }
}
