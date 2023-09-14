using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp = 9;
    public float minDistance = 1;

    protected override void OnCollect()
    {
        base.OnCollect();
        collider.enabled = false;
        collect = true;
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
