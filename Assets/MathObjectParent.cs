using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MathObject;

public class MathObjectParent : MonoBehaviour
{
    [SerializeField] private MathObject mathObject0;
    [SerializeField] private MathObject mathObject1;
    private MathOperator parentMathOperator;
    private void Awake()
    {
        parentMathOperator = (MathOperator)UnityEngine.Random.Range(0, (int)MathOperator.count);
        mathObject0.mathOperator = parentMathOperator;
        mathObject1.mathOperator = parentMathOperator;
    }
}
