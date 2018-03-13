using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;

    void Awake()
    {
        //instantiaite leader
        GameObject leaderEagleShip = GameObject.Instantiate<GameObject>(prefab);
        leaderEagleShip.transform.position = transform.position;
        
        for (int i = 1; i < followers + 1; i++)
        {
            Vector3 row = leaderEagleShip.transform.position;
            //adjust for row relative to leader position
            row.z -= gap * i;

            //left follower position
            Vector3 leftFollowerPosition = row;
            //adjust x for column position
            leftFollowerPosition.x -= gap * i;

            //right follower position
            Vector3 rightFollowerPosition = row;
            //adjsut x for column position
            rightFollowerPosition.x += gap * i;

            //instantiate left follower
            GameObject leftFollowerEagleShip = GameObject.Instantiate<GameObject>(prefab);
            leftFollowerEagleShip.transform.position = leftFollowerPosition;
            //instantiate right follower
            GameObject rightFollowerEagleShip = GameObject.Instantiate<GameObject>(prefab);
            rightFollowerEagleShip.transform.position = rightFollowerPosition;
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
