using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Section FirstSection;
    public Section LastSection;
    public Section[] SectionPrefabs;

    private int maxSections = 5;

    private List<Section> spawnedSection = new List<Section>();
    public List<Section> SpawnedSection
    {
        get
        {
            return spawnedSection;
        }
    }

    private void Start()
    {
        spawnedSection.Add(FirstSection);

        for(int i = 0; i < maxSections; i++)
        {
            Section section = Instantiate(SectionPrefabs[Random.Range(0, SectionPrefabs.Length)]);
            section.transform.rotation = Quaternion.Euler(Quaternion.identity.x, Random.Range(-360, 360), Quaternion.identity.z);
            section.transform.position = spawnedSection[spawnedSection.Count - 1].EndPoint.position - section.StartPoint.localPosition;
            spawnedSection.Add(section);

            if (i == maxSections - 1) SetFinish();
        }
    }
    void SetFinish()
    {
        Section section = Instantiate(LastSection);
        section.transform.position = spawnedSection[spawnedSection.Count - 1].EndPoint.position - section.StartPoint.localPosition;
    }
}
