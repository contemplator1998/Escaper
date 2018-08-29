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
    private int counter = 0;

    void Start()
    {
        Provider.Initialize();
        enemyAudio = GetComponentsInChildren<AudioSource>();
        timing = Time.time;
    }

    void Update()
    {
        bool obstacle = Physics.Raycast(transform.position,
            (Provider.GetPlayer().transform.position - transform.position).normalized,
            Vector3.Distance(transform.position, Provider.GetPlayer().transform.position), 
            1 << 8);
        Debug.Log(obstacle);

        Debug.DrawRay(transform.position,
            (Provider.GetPlayer().transform.position - transform.position).normalized *
                Vector3.Distance(transform.position, Provider.GetPlayer().transform.position), Color.yellow);
        if (Vector3.Distance(Provider.GetPlayer().transform.position, transform.position) <= TriggerDistance
            && !insideTriggerZone && timing < Time.time && !obstacle)
        {
            enemyAudio[counter++ % enemyAudio.Length].Play();
            insideTriggerZone = true;
            timing = Time.time + MinTimeIntervalBetweenTriggering;
        }

        if (Vector3.Distance(Provider.GetPlayer().transform.position, transform.position) > TriggerDistance)
        {
            insideTriggerZone = false;
        }
    }
}
