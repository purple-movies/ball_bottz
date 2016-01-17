using UnityEngine;
using System;

public class CollisionZone2d : MonoBehaviour
{
    [SerializeField] CollisionZone2dListenerBase listener;
    [SerializeField] Tags collidersTag;

    string collidersTagString;

    void Start()
    {
        collidersTagString = collidersTag.ToString();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerInZone(collider))
            listener.onEnter(collider);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (playerInZone(collider))
            listener.onStay(collider);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (playerInZone(collider))
            listener.onExit(collider);
    }

    bool playerInZone(Collider2D collider)
    {
        if (collider.tag == collidersTagString) {
            return true;
        }
        return false;
    }

    public abstract class CollisionZone2dListenerBase : MonoBehaviour
    {
        public virtual void onEnter(Collider2D collision)
        {
            throw new NotImplementedException();
        }

        public virtual void onExit(Collider2D collision)
        {
            throw new NotImplementedException();
        }

        public virtual void onStay(Collider2D collision)
        {
            throw new NotImplementedException();
        }
    }
}
