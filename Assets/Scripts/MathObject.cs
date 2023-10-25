using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mathCalculationText;
    [SerializeField] private float value;
    private MathExpression mathExpression;
    public MathOperator mathOperator;


    private void Awake()
    {
        mathExpression = MathExpression.GenerateRandom(1, 10, mathOperator);
        value = mathExpression.value;
        mathCalculationText.text = mathExpression.ToString();
    }

    public float GetValue() { return value; }

    public void SetValue(float value) { this.value = value; }

    public enum MathOperator { addition, substraction, product, division, count }

    public static char OperatorToChar(MathOperator mathOperator)
    {
        switch (mathOperator)
        {
            case MathOperator.addition:
                return '+';
            case MathOperator.substraction:
                return '-';
            case MathOperator.product:
                return 'x';
            case MathOperator.division:
                return '÷';
            default:
                return ')';
        }
    }

    public class MathExpression
    {
        public MathOperator mathOperator;
        public float a;
        public float b;
        public float value;

        override public string ToString()
        {
            return this.a.ToString() + OperatorToChar(this.mathOperator) + this.b.ToString();
        }
        public MathExpression(MathOperator mathOperator, float a, float b)
        {
            this.a = a;
            this.b = b;
            this.mathOperator = mathOperator;
            Calculate();
        }
        public MathExpression(string expression)
        {
            int pos;
            string aStr, bStr;

            if ((pos = expression.IndexOf("+")) != -1)
            {
                this.mathOperator = MathOperator.addition;
                aStr = expression.Substring(0, pos);
                bStr = expression.Substring(pos + 1);
            }
            else if ((pos = expression.IndexOf("-")) != -1)
            {
                this.mathOperator = MathOperator.substraction;
                aStr = expression.Substring(0, pos);
                bStr = expression.Substring(pos + 1);
            }
            else if ((pos = expression.IndexOf("*")) != -1)
            {
                this.mathOperator = MathOperator.product;
                aStr = expression.Substring(0, pos);
                bStr = expression.Substring(pos + 1);
            }
            else if ((pos = expression.IndexOf("/")) != -1)
            {
                this.mathOperator = MathOperator.division;
                aStr = expression.Substring(0, pos);
                bStr = expression.Substring(pos + 1);
            }
            else
            {
                // not any of above + - * /
                Debug.LogWarning("not any of above + - * /");
                aStr = "-1";
                bStr = "-1";
            }

            this.a = float.Parse(aStr);
            this.b = float.Parse(bStr);
            value = CalculateOperation(this.a, this.b, this.mathOperator);
        }
        public static MathExpression GenerateRandomOperator(int minValue, int maxValue)
        {
            System.Random random = new System.Random();
            return new MathExpression((MathOperator)random.Next(0, (int)MathOperator.count), random.Next(minValue, maxValue), random.Next(minValue, maxValue));
        }
        public static MathExpression GenerateRandom(int minValue, int maxValue, MathOperator mathOperator)
        {
            System.Random random = new System.Random();
            return new MathExpression(mathOperator, random.Next(minValue, maxValue), random.Next(minValue, maxValue));
        }

        public void Calculate()
        {
            this.value = CalculateOperation(this.a, this.b, this.mathOperator);
        }
        public float CalculateOperation(float num1, float num2, MathOperator mathOperator)
        {
            // Calculate num1 and num2 based on given operation
            switch (mathOperator)
            {
                case MathOperator.addition:
                    return num1 + num2;
                case MathOperator.substraction:
                    return num1 - num2;
                case MathOperator.product:
                    return num1 * num2;
                case MathOperator.division:
                    if (num2 != 0)
                        return num1 / num2;
                    else
                        throw new Exception("Cant devide by zero!");

                default: return -1;
            }
        }

    }

}
