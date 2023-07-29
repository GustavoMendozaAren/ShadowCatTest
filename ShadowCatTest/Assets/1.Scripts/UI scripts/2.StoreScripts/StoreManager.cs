using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Animator carpetsOut;
    public Animator storeIn;

    public void CarpetsOut()
    {
        carpetsOut.SetBool("CarpetsOut", true);
        storeIn.SetBool("StoreIn", true);
    }

    public void CarpetsIn()
    {
        carpetsOut.SetBool("CarpetsOut", false);
        storeIn.SetBool("StoreIn", false);
    }

    
}
