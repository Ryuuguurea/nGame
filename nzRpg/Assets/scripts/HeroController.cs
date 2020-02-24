using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

	public float mKeyStrokeMoveStep = 2f;	//metre
    public Transform cameraLook=null;
    private CharacterController controller;
    private Animator animator;
    private Camera mCamera;
    private bool run=false;
    float rotateX;
    float rotateY;
    float rotateZ=-4;
    void Awake(){
        controller=GetComponent<CharacterController>();
        animator=GetComponentInChildren<Animator>();
        mCamera=Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("state",0);
		Vector3 vDir = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
		{
            animator.SetInteger("state",1);
			vDir.z += run?mKeyStrokeMoveStep*3:mKeyStrokeMoveStep;
            transform.forward=new Vector3(Camera.main.transform.forward.x,0,Camera.main.transform.forward.z);
		}else{
            run=false;
        }
        CameraLook();
        
		if(Input.GetKey(KeyCode.S))
		{
			vDir.z -= run?mKeyStrokeMoveStep*3:mKeyStrokeMoveStep;
		}

		if(Input.GetKey(KeyCode.A))
		{
            animator.SetInteger("state",2);
            transform.Rotate(Vector3.up,-Time.deltaTime*150,Space.Self);
		}
		if(Input.GetKey(KeyCode.D))
		{
            animator.SetInteger("state",3);
            transform.Rotate(Vector3.up,Time.deltaTime*150,Space.Self);
		}
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            run=true;
        }
        animator.SetBool("run",run);

        // var v3=transform.forward*vDir.z*Time.deltaTime;
        // v3.y=0;

		controller.Move(transform.forward*vDir.z*Time.deltaTime);

    }
    void CameraLook(){
        float x = Input.GetAxis("Mouse X");
        rotateX += x * 5;

        float y = -Input.GetAxis("Mouse Y");
        rotateY += y * 5;

        //防止出现翻转现象
        rotateY = Mathf.Clamp(rotateY,-80,80);
        rotateZ += Input.GetAxis("Mouse ScrollWheel") * 5;
        rotateZ = Mathf.Clamp(rotateZ,-8,-2);
        Camera.main.transform.position = transform.position+ Quaternion.Euler(rotateY, rotateX, 0) * new Vector3(0,2, rotateZ);
        Camera.main.transform.LookAt(transform);
    }
}
