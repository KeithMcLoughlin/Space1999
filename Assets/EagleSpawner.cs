using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class EagleSpawner : MonoBehaviour {

    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;

    void Awake()
    {
        //instantiaite leader
        GameObject leaderEagleShip = GameObject.Instantiate<GameObject>(prefab);
        leaderEagleShip.transform.position = transform.position;
        Seek leaderSeek = leaderEagleShip.AddComponent<Seek>();
        //seek target position 1000 units ahead of leader
        leaderSeek.target = new Vector3(0, 0, 1000);
        
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
            OffsetPursue leftFollowPursue = leftFollowerEagleShip.AddComponent<OffsetPursue>();
            //pursue leader
            leftFollowPursue.target = new Vector3(0, 0, 1000);
            leftFollowPursue.leader = leaderEagleShip.GetComponent<Boid>();

            //instantiate right follower
            GameObject rightFollowerEagleShip = GameObject.Instantiate<GameObject>(prefab);
            rightFollowerEagleShip.transform.position = rightFollowerPosition;
            OffsetPursue rightFollowPursue = rightFollowerEagleShip.AddComponent<OffsetPursue>();
            //pursue leader
            rightFollowPursue.target = new Vector3(0, 0, 1000);
            rightFollowPursue.leader = leaderEagleShip.GetComponent<Boid>();
        }
        
    }
}
