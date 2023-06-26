using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    static public class Helper
    {
        static public float GetRange(float inputValue, float maxValue, float miniValue)
        {
            if (inputValue > maxValue)
            {
                return maxValue;
            }
            else if (inputValue < miniValue)
            {
                return miniValue;
            }
            return inputValue;
        }
    }
}

