using UnityEngine;
using System.Collections.Generic;
using LSL;
using Assets.LSL4Unity.Scripts.AbstractInlets;

/// <summary>
/// An reusable example of an inlet which maps the orientation and world position from a LSL Output to an entity of an Unity Scene
/// </summary>
public class LSLTransformInlet : AFloatInlet
{
    public Transform targetTransform;

    // These labels where set from the LSLTransformerOutlet
    bool containsStreamRotationAsQuaternion = false;

    bool containsStreamRotationAsEuler = false;

    bool containsStreamPosition = false;


    // Local variables to speed up memory allocation when reading LSL values
    int offset = -1;

    Quaternion targetRotation = Quaternion.identity;
    float x,y,z; // Euler degrees
    Vector3 targetPosition = Vector3.zero;


    protected override void AdditionalOnInletFound(liblsl.StreamInfo info)
    {
        // ExpectedChannels
        switch(info.channel_count())
        {
            case 0:
                // No streaming is coming
                break;
            case 3:
                // Could be orientation Euler, or position. Assume it is position
                containsStreamPosition = true;
                break;
            case 4:
                containsStreamRotationAsQuaternion = true;
                break;
            case 6:
                containsStreamRotationAsEuler = true;
                containsStreamPosition = true;
                break;
            case 7:
                // Could be Quaternion + Euler, or Quaternion + Position. Assume it is position
                containsStreamRotationAsQuaternion = true;
                containsStreamPosition = true;
                break;
            case 10:
                containsStreamRotationAsQuaternion = true;
                containsStreamRotationAsEuler = true;
                containsStreamPosition = true;
                break;
        }

        Debug.Log("In total " + info.channel_count().ToString() + " for inlet " + StreamName + "," + StreamType);
    }

    protected override void Process(float[] newSample, double timeStamp)
    {
        offset = -1;

        Quaternion targetRotation = Quaternion.identity;
        x = y = z = 0.0f; // Euler degrees
        targetPosition = Vector3.zero;

        if(containsStreamRotationAsQuaternion)
        {
            targetRotation = new Quaternion(newSample[++offset],
                                            newSample[++offset],
                                            newSample[++offset],
                                            newSample[++offset]);
        }
        
        if(containsStreamRotationAsEuler)
        {
            // Skip the reading of Euler degrees, rotation was already calculated
            x = newSample[++offset];
            y = newSample[++offset];
            z = newSample[++offset];

            if(!containsStreamRotationAsQuaternion)
            {
                // If quaternion is not provided, use Euler degrees
                targetRotation = Quaternion.Euler(x,y,z);
            }
        }
        
        if(containsStreamPosition)
        {
            targetPosition.x = newSample[++offset];
            targetPosition.y = newSample[++offset];
            targetPosition.z = newSample[++offset];
        }

        // apply the rotation to the target transform
        targetTransform.rotation = targetRotation;

        // apply target position
        targetTransform.position = targetPosition;
    }
}