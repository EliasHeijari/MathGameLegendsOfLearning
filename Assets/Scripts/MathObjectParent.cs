using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static MathObject;

public class MathObjectParent : MonoBehaviour
{
    [SerializeField] private MathObject mathObject0;
    [SerializeField] private MathObject mathObject1;
    private bool firstOneWin;
    private bool bothWin = false;

    private void Awake()
    {
        MathOperator parentMathOperator = (MathOperator)Random.Range(0, (int)MathOperator.count);
        mathObject0.mathOperator = parentMathOperator;
        mathObject1.mathOperator = parentMathOperator;
        StartCoroutine(MathOperatorsBValue());
    }

    private IEnumerator MathOperatorsBValue()
    {
        yield return new WaitForNextFrameUnit();
        if (mathObject0.GetValue() > mathObject1.GetValue()) { firstOneWin = true; }
        if (mathObject0.GetValue() == mathObject1.GetValue()) { bothWin = true; }
    }

    public bool FirstOneWin()
    {
        return firstOneWin;
    }

    public bool BothWin()
    {
        return bothWin;
    }

    public MathObject GetFirstMathObject() 
    {
        return mathObject0;
    }
}
