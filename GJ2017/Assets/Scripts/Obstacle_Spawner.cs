using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour {



    //obstacles

    public GameObject Meteor;
    public GameObject Birds;

    GameObject[] list_of_obstacles;
    //obstacles
    public int amount;
    Vector3 new_position;

    int counter;
    public float range = 40f;
    GameObject[] obstacles;


    //rocket stuff
    public GameObject Rocket;
    float speed;
    float height;

    //rocket stuff
    // Use this for initialization
    void Start () {
        list_of_obstacles = new GameObject[3];
        list_of_obstacles[0] = Birds;
        list_of_obstacles[1] = Meteor;	
	}
	
	// Update is called once per frame
	void Update () {

        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        speed = Rocket.GetComponent<Rigidbody2D>().velocity.y;

        height = this.transform.position.y;
        Debug.Log(height);

        if (speed != 0)
        {
            if (obstacles.Length <= amount)
            {
                new_position = new Vector3(Random.Range(this.transform.position.x - range, this.transform.position.x + range),
                                            Random.Range(this.transform.position.y - range, this.transform.position.y + range), 0);
                if (height <= 40)//hardcode
                {
                    Instantiate(list_of_obstacles[0], new_position, Quaternion.identity);
                }
                else
                {
                    Instantiate(list_of_obstacles[1], new_position, Quaternion.identity);
                }
            }
        }
	}
}
