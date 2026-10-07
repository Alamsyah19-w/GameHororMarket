using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
   [SerializeField] private float timer=300f;
   
   [Header("Left Door Target")]
   [SerializeField] private GameObject doorLeftPrefabs;

   [Header ("Right Door Target")]
   [SerializeField] private GameObject doorRightPrefabs;
   private bool timeIsfinish=false;
   private bool doorIsOpening= false;
   public bool TimeFinish=>timeIsfinish;

    private void FixedUpdate()
    {
        Timer();
    }
    private void Timer()
    {
        if (timeIsfinish)return;

        timer -=Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            timer=0f;
            

            timeIsfinish=true;

            if (!doorIsOpening)
            {
                openDoor();
            }
        }
        
    }

    private void openDoor()
    {
        doorIsOpening= true;
        Destroy(doorLeftPrefabs);
        Destroy(doorRightPrefabs);
    }
}
