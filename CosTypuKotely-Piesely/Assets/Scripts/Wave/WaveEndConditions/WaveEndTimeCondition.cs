// using System.Collections;
// using UnityEngine;

// [System.Serializable]
// public class WaveEndTimeCondition : WaveEndConditionBase
// {
//     [SerializeField]
//     private float waveDuration;
//     float endWaveTime;//moze nie potrzebne ale do testu na razie
//     // System.Timers.Timer timer;


//     private IEnumerator OnElapsed()
//     {
//         // Debug.Log("elapsed");
//         yield return new WaitForSeconds(waveDuration);
//         EndWave();
//         // timer.Close();
//     }

//     public override bool CheckEndWave()
//     {
//         // if (Time.unscaledTime >= endWaveTime)
//             return true;
//         // return false;
//     }

//     public override void Attach()
//     {
//         // endWaveTime = Time.unscaledTime + waveDuration;
// var x = StartCoroutine(OnElapsed());
//         // timer = new System.Timers.Timer();
//         // timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsed);
//         // timer.Interval = waveDuration;
//         // timer.Start();
//     }

//     public override void Detach()
//     {
//        timer.Close();
//     }
// }
