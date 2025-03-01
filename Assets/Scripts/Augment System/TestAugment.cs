using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tester for LifeSteal Augment
public class TestAugment : MonoBehaviour
{
    [SerializeField]
    private Augment augment;
    [SerializeField]
    private AugmentManager augmentManager;

    private void Awake()
    {
        this.augmentManager = gameObject.GetComponent<AugmentManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            augment.enableAugment();
            augmentManager.addAugment(augment);
        }
    }
}
