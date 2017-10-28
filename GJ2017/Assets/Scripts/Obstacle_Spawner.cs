using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour {

    public GameObject Meteor;
    public int amount;
    Vector3 new_position;

    int counter;
    public float range = 40f;

    GameObject[] obstacles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            
        if (obstacles.Length <= amount)
        {
            new_position = new Vector3(Random.Range(this.transform.position.x - range, this.transform.position.x + range),
                                        Random.Range(this.transform.position.y - range, this.transform.position.y + range), 0);

            Instantiate(Meteor, new_position, Quaternion.identity);
        }  
	}
}
