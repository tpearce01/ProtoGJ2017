using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    Vector3 target;
    public GameObject bullet;

    public GameObject Rocket;

    
    //laser
  //  Ray2D laser;
   // public LineRenderer line;


    //
    public float speed = 3f;
    
	// Use this for initialization
	void Start () {
       // line = gameObject.GetComponent<LineRenderer>();
        //line.enabled = false;
        target = transform.position;

        
    }
	
	// Update is called once per frame
	void Update () {
        speed = Rocket.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (Input.GetMouseButtonDown(0) && Rocket.GetComponent<Rocket>().currentAmmo > 0)
        {
            //...setting shoot direction
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;

            //...instantiating the bullet
            Rigidbody2D bulletInstance = Instantiate(bullet.GetComponent<Rigidbody2D>(), new Vector3(transform.position.x,transform.position.y, 1), Quaternion.Euler(new Vector3(0, 0, shootDirection.z))) as Rigidbody2D;

            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);

            Rocket.GetComponent<Rocket>().currentAmmo--;
            //...making laser


            //line.enabled = true;


            //line.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
            //line.SetPosition(1, new Vector3(shootDirection.x + transform.position.x, shootDirection.y + transform.position.y, 0));
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, shootDirection, 100);
            ////AddColliderToLine(line, line.GetPosition(0), line.GetPosition(1));
        }

        //if (Input.GetMouseButtonUp(0))
        //line.enabled = false;

    }

    //private void AddColliderToLine(LineRenderer line, Vector3 startPoint, Vector3 endPoint)
    //{
    //    //create the collider for the line
    //    BoxCollider lineCollider = new GameObject("LineCollider").AddComponent<BoxCollider>();
    //    //set the collider as a child of your line
    //    lineCollider.transform.parent = line.transform;
    //    // get width of collider from line 
    //    float lineWidth = line.endWidth;
    //    // get the length of the line using the Distance method
    //    float lineLength = Vector3.Distance(startPoint, endPoint);
    //    // size of collider is set where X is length of line, Y is width of line
    //    //z will be how far the collider reaches to the sky
    //    lineCollider.size = new Vector3(lineLength, lineWidth, 1f);
    //    // get the midPoint
    //    Vector3 midPoint = (startPoint + endPoint) / 2;
    //    // move the created collider to the midPoint
    //    lineCollider.transform.position = midPoint;


    //    //heres the beef of the function, Mathf.Atan2 wants the slope, be careful however because it wants it in a weird form
    //    //it will divide for you so just plug in your (y2-y1),(x2,x1)
    //    float angle = Mathf.Atan2((endPoint.z - startPoint.z), (endPoint.x - startPoint.x));

    //    // angle now holds our answer but it's in radians, we want degrees
    //    // Mathf.Rad2Deg is just a constant equal to 57.2958 that we multiply by to change radians to degrees
    //    angle *= Mathf.Rad2Deg;

    //    //were interested in the inverse so multiply by -1
    //    angle *= -1;
    //    // now apply the rotation to the collider's transform, carful where you put the angle variable
    //    // in 3d space you don't wan't to rotate on your y axis
    //    lineCollider.transform.Rotate(0, angle, 0);
    //}
}
