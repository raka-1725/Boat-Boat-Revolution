using System;
using UnityEngine;

public class SAccuracyDetect : MonoBehaviour
{
    //[lane, zone]
    private SNote[,] activeNotes = new SNote[4,3];

    [Header("Score Add settings")] 
    [SerializeField] private int normalAddGood = 3;
    [SerializeField] private int normalAddPerfect = 10;
    [SerializeField] private int highAdd = 20;
    
    private void Awake()
    {
    }

    public void HitNote(int laneIndex)
    {
        //need UI here
        Debug.Log($"Note hit active on lane : {laneIndex}");
        
        bool z1 = activeNotes[laneIndex - 1, 0] != null;
        bool z2 = activeNotes[laneIndex - 1, 1] != null;
        bool z3 = activeNotes[laneIndex - 1, 2] != null;
        
        int scoreToAdd = 0;
        int scoreToAddHigh = 0;
        bool bHigh = false;
        
        for (int lane = 0; lane < activeNotes.GetLength(0); lane++)
        {
            for (int accZone = 0; accZone < activeNotes.GetLength(1); accZone++)
            {
                if (activeNotes[lane, accZone] != null)
                {
                    if (activeNotes[lane, accZone].NoteType == SNote.ENoteType.High)
                    {
                        bHigh = true;
                        scoreToAddHigh = highAdd;
                    }
                }
            }
        }

        if ((z1 && z2))
        {
            scoreToAdd = normalAddPerfect - normalAddGood;
            Debug.LogWarning($"Note hit EXCELLENT");
            SScoreManager.ScoreInstance.AddScore(scoreToAdd);
            SScoreManager.ScoreInstance.AddCombo(1);
        }
        else if ((z2 && z3))
        {
            scoreToAdd = normalAddPerfect - normalAddGood;
            Debug.LogWarning($"Note hit EXCELLENT");
            SScoreManager.ScoreInstance.AddScore(scoreToAdd);
            SScoreManager.ScoreInstance.AddCombo(1);
        }
        else if(z1 || z3)
        {
            scoreToAdd = normalAddGood;
            Debug.LogWarning($"Note hit GOOD");
            SScoreManager.ScoreInstance.AddScore(scoreToAdd);
            SScoreManager.ScoreInstance.AddCombo(1);
        }
        else if(z2)
        {
            if(bHigh) scoreToAdd = scoreToAddHigh;
            scoreToAdd = normalAddPerfect;
            Debug.LogWarning($"Note hit PERFECT");
            SScoreManager.ScoreInstance.AddScore(scoreToAdd);
            SScoreManager.ScoreInstance.AddCombo(1);
        }
        else
        {
            Debug.Log($"Note Missed");
        }
    }

    public void NoteEntered(int laneIndex, int zoneIndex, SNote note)
    {
        //Debug.Log($"Note entered : Lane {laneIndex} Zone {zoneIndex}");
        
        activeNotes[laneIndex, zoneIndex] = note;
    }

    public void NoteExited(int laneIndex, int zoneIndex, SNote note)
    {
        activeNotes[laneIndex, zoneIndex] = null;
        //Debug.Log($"Note Delete : Lane {laneIndex} Zone {zoneIndex}");
    }
    
    
    
}
