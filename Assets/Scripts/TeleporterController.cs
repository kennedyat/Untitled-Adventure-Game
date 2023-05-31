using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
   
    
    PortalEffect portalEffect;
    public bool isTeleport;
    [SerializeField]
    GameObject player;
    public GameObject initializer;

    [Header("Portal Objects")]
    public GameObject visual;
    public GameObject portal1;
    public GameObject portal2;
    // public GameObject initializer;

    public bool aim = false;
    Ray ray;
    public LayerMask layer;
    public float maxDistance=500;

    private void Awake()
    {
        portal1.SetActive(false);
        portal2.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        portalEffect = GetComponent<PortalEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aim)
        {
            
            VisualTeleport();
        }
    }
    //Creates visual for aiming
    public void VisualTeleport()
    {
        ray = new Ray(initializer.transform.position, player.transform.forward);
       
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer))
        {
            visual.SetActive(true);
            visual.transform.position = new Vector3(hit.point.x, visual.transform.position.y, hit.point.z);
            float distance = (Vector3.Distance(player.transform.position, hit.point));
          
        }
        else
        {
            visual.SetActive(false);
        }
        
    }
    //Move the portals to correct positions when teleporting
    public void TeleporterPosition(){
        visual.SetActive(false);
        ray = new Ray(initializer.transform.position, player.transform.forward);
        portal1.transform.localRotation = player.transform.localRotation;
        portal2.transform.localRotation = player.transform.localRotation;
        Vector3 playerDirection = player.transform.position;
        playerDirection.Normalize();
     
        Debug.Log(playerDirection);

        portal1.transform.position = player.transform.position;
        portal2.transform.position = visual.transform.position;
        portal1.SetActive(true);
        portal2.SetActive(true);
        portalEffect.grow = true;
       
        
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer)){

            
           
        }
       StartCoroutine(Transition());

    }
   //Transition from one portal to the next
    IEnumerator Transition(){
        //Aniamtion
        transform.position =portal2.transform.position;
        yield return new WaitForSeconds(4f);
      
        portal1.SetActive(false);
        portal2.SetActive(false);
        portalEffect.portal1.transform.localScale = new Vector3(0, 0, 0);
       
    }

  
    private void OnTriggerStay(Collider other)
    {
        //Find top of surface
        //Or find a stay on faces method
        if (other.gameObject.tag == "Collide")
        {
            transform.position += new Vector3(0, .05f, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }
   
}
