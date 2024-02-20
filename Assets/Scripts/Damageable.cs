using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    #region Collision
    public virtual void OnCollisionExit(Collision collision)
    {
       
    }

    public virtual void OnCollisionStay(Collision collision)
    {

    }

    public virtual void OnCollisionEnter(Collision collision)
    {

    }
    #endregion
    
    #region Trigger
    public virtual void OnTriggerEnter(Collider other)
    {

    }
    
    public virtual void OnTriggerExit(Collider other)
    {

    }

    public virtual void OnTriggerStay(Collider other)
    {

    }
    #endregion
    #region Preset
    //public virtual void OnCollisionExit(Collision collision)
    //{
    //    base.OnCollisionExit(collision);
    //}

    //public virtual void OnCollisionStay(Collision collision)
    //{
    //    base.OnCollisionStay(collision);
    //}

    //public virtual void OnCollisionEnter(Collision collision)
    //{
    //    base.OnCollisionEnter(collision);
    //}

    //public virtual void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //}

    //public virtual void OnTriggerExit(Collider other)
    //{
    //    base.OnTriggerExit(other);
    //}

    //public virtual void OnTriggerStay(Collider other)
    //{
    //    base.OnTriggerStay(other);
    //}
    #endregion
}
