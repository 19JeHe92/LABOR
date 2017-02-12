using UnityEngine;
using NewtonVR;
using System.Collections;
using UnityEngine.SceneManagement;

public class RobotContoller : MonoBehaviour {

    public NVRHead playerHead;
    public bool run = false;
    public float RunSpeed = 5.0f;
    private Animator anim;

    private bool ft = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
	

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    void Update()
    {
        if (run)
        {
            if (ft)
            {
                Debug.Log("Run");
                anim.SetTrigger("Turn");
                StartCoroutine("Wait");
                transform.Rotate(new Vector3(0,0, 180));
                ft = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerHead.transform.position.x, 0, playerHead.transform.position.z), RunSpeed * Time.deltaTime);
        }
        if(transform.position == playerHead.transform.position)
            SceneManager.LoadScene("StartScene");
    }

	void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.GetComponent<NVRInteractableItem>()!=null)
        {
            Debug.Log("Collision with Interactable Item");
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        run = false;
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(10);
         Destroy(gameObject);
    }
}
