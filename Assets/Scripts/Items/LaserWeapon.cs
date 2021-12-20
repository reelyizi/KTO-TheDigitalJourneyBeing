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
                muzzle.SetActive(false);
            }
            counter++;
            if (counter == numberOfFire)
                this.gameObject.SetActive(false);
        }
        else if(duration >= .11f)
        {
            foreach (GameObject muzzle in muzzles)
            {
                muzzle.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        counter = 0;
    }

    private void OnDisable()
    {
        foreach (GameObject muzzle in muzzles)
        {
            muzzle.SetActive(false);
        }
    }
}
