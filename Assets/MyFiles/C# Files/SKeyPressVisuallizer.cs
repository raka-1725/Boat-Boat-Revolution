using UnityEngine;

public class SKeyPressVisuallizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] SRs;
    
    [SerializeField] private Color SRColor_Pressed;
    [SerializeField] private Color SRColor_Released;
    

    void Start()
    {
        SRs = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer SR in SRs)
        {
            SR.color = SRColor_Released;
        }
    }

    public void OnPressed(int laneIndex)
    {
        int index = laneIndex - 1;
        SRs[index].color = SRColor_Pressed;
    }

    public void OnReleased(int laneIndex)
    {
        int index = laneIndex - 1;
        SRs[index].color = SRColor_Released;
    }


}
