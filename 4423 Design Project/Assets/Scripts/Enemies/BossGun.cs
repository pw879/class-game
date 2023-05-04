using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{


    public GameObject bullet;

    [SerializeField] private Transform fire45;
    [SerializeField] private Transform fire90;
    [SerializeField] private Transform fire135;
    [SerializeField] private Transform fire180;
    [SerializeField] private Transform fire225;
    [SerializeField] private Transform fire270;
    [SerializeField] private Transform fire315;
    [SerializeField] private Transform fire360;

    // Start is called before the first frame update
    void Start()
    {

    }

	public void SpawnProjectiles()
	{
        GameObject fire1 = Instantiate (bullet, fire45.position, fire45.rotation);
        GameObject fire2 = Instantiate (bullet, fire90.position, fire90.rotation);
        GameObject fire3 = Instantiate (bullet, fire135.position, fire135.rotation);
        GameObject fire4 = Instantiate (bullet, fire180.position, fire180.rotation);
        GameObject fire5 = Instantiate (bullet, fire225.position, fire225.rotation);
        GameObject fire6 = Instantiate (bullet, fire270.position, fire270.rotation);
        GameObject fire7 = Instantiate (bullet, fire315.position, fire315.rotation);
        GameObject fire8 = Instantiate (bullet, fire360.position, fire360.rotation);
	}
}


