using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static MathObject;

public class MathObjectParent : MonoBehaviour
{
    [SerializeField] private MathObject[] mathObjects;
    private List<float> mathObjectsValues = new List<float>();
    private List<MathObject> winnerMathObjects = new List<MathObject>();

    private void Awake()
    {
        MathOperator parentMathOperator = (MathOperator)UnityEngine.Random.Range(0, (int)MathOperator.count);
        foreach(MathObject obj in mathObjects)
        {
            obj.mathOperator = parentMathOperator;
        }
        StartCoroutine(MathOperatorsBValue());
    }

    private IEnumerator MathOperatorsBValue()
    {
        yield return new WaitForNextFrameUnit();

        foreach(MathObject obj in mathObjects)
        {
            mathObjectsValues.Add(obj.GetValue());
        }
        float highestValue = 0;
        foreach (float mathObjValue in mathObjectsValues)
        {
            if (mathObjValue >= highestValue)
            {
                highestValue = mathObjValue;
            }
        }
        foreach (MathObject mathObject in mathObjects)
        {
            if (mathObject.GetValue() >= highestValue)
            {
                winnerMathObjects.Add(mathObject);
            }
        }

    }

    public List<MathObject> WinnerMathObjects()
    {
        return winnerMathObjects;
    }
}
