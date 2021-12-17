using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private List<GameObject> muzzles;
    [SerializeField] private float rateOfFire;
    private float duration = 0;
    [SerializeField] private int numberOfFire;
    private int counter = 0;

    void Update()
    {
        duration += Time.deltaTime;
        if(duration >= rateOfFire)
        {
            duration = 0;
            foreach (GameObject muzzle in muzzles)
            {
                Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation, null);
            }
            counter++;
            if (counter == numberOfFire)
                this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        counter = 0;
    }
}
