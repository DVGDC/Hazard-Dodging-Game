using UnityEngine;

public class Hammer : Hazard
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        if(Random.Range(0,2) == 0)
        {
            // implement flipped hammer next meeting
        }
    }
}
