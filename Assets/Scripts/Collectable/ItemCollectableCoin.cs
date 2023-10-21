using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public Collider objCollider;
    public bool collect = false;
    public float lerp = 9;
    public float minDistance = 1;

    private void Start()
    {
        CoinsAnimationManager.instance.RegisterCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        objCollider.enabled = false;
        collect = true;
        PlayerController.instance.Bounce();
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < minDistance)
            {
                HideItens();
                Destroy(gameObject);
            }
        }
    }
}
