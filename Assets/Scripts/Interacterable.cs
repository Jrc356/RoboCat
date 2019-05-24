using UnityEngine;

public class Interacterable : MonoBehaviour
{

    public int pointValue = 5;
    private bool isHit = false;
    public Scoring scoring;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Hit(Scoring score) {
        scoring = score;
        if (!isHit) {
            isHit = true;
            return (pointValue * 2);
        } else {
            return pointValue;
        }
    }


    void OnCollisionEnter(Collision collision) {
        if (scoring != null) {
            scoring.addScore((int)(pointValue / 2));
        }
    }
}
