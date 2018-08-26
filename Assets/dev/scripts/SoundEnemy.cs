using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    public float TriggerDistance = 2;
    public float MinTimeIntervalBetweenTriggering = 10;

    private AudioSource[] enemyAudio;
    private bool insideTriggerZone = false;
    private float timing = 0;

    void Start()
    {
        Provider.Initialize();
        enemyAudio = GetComponentsInChildren<AudioSource>();
        timing = Time.time;
    }

    void Update()
    {
        if (Vector3.Distance(Provider.GetPlayer().transform.position, transform.position) <= TriggerDistance
            && !insideTriggerZone && timing < Time.time)
        {
            enemyAudio[Random.Range(0, enemyAudio.Length)].Play();
            insideTriggerZone = true;
            timing = Time.time + MinTimeIntervalBetweenTriggering;
        }

        if (Vector3.Distance(Provider.GetPlayer().transform.position, transform.position) > TriggerDistance)
        {
            insideTriggerZone = false;
        }
    }
}
