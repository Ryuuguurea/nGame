using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class main : MonoBehaviour
{
    public RawImage image;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        float x=Input.GetAxis("Mouse X");
        Debug.Log(x);
    }
    public void EnterGame(){
  
    }


}
