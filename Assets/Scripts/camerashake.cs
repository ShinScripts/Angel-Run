using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public IEnumerator Shake(float dur, float amp){

        Vector3 orignalPos = transform.localPosition;

        float time = 0;

        while ( time < dur){
            
            //SHAKES THE CAMERA
            transform.localPosition = new Vector3(Random.Range(-1f,1f)* amp + orignalPos.x,Random.Range(-1f,1f)* amp + orignalPos.y,orignalPos.z);

            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = orignalPos;
    }
}
