using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes{
        MouseXandY=0,
        MouseX=1,
        MouseY=2,
    }
    public RotationAxes axes = RotationAxes.MouseX;

    public float sensitivityHor =8.0f;
    public float sensitivityVert =8.0f;
    public float maximumVert = 45.0f;
    public float minimumVert = -45.0f;

    private float _rotationX =0;


    void Start(){
        Rigidbody body = GetComponent<Rigidbody>();

        if(body!=null) 
            body.freezeRotation=true;
    }
    void Update()
    {
        if(axes==RotationAxes.MouseX){
            transform.Rotate(0,sensitivityHor*Input.GetAxis("Mouse X"),0);
        }else if(axes==RotationAxes.MouseY){

             _rotationX-=sensitivityVert*Input.GetAxis("Mouse Y");

             _rotationX= Mathf.Clamp(_rotationX,minimumVert,maximumVert);

             float rotationY = transform.localEulerAngles.y;

             transform.localEulerAngles=new Vector3(_rotationX,rotationY,0);


        }else{
             _rotationX-=sensitivityVert*Input.GetAxis("Mouse Y");
             _rotationX= Mathf.Clamp(_rotationX,minimumVert,maximumVert);

             float delta = sensitivityVert*Input.GetAxis("Mouse X");

             float rotationY = transform.localEulerAngles.y+delta;
             transform.localEulerAngles=new Vector3(_rotationX,rotationY,0);


            
        }
        
    }
}
