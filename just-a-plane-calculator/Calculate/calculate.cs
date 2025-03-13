﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace just_a_plane_calculator
{
    public class Calculate
    {
        public static string CalculateString(string input)
        {
            if (input.Length == 0) 
            { 
                return ""; 
            }
            
            string[] splitInput = input.Split(' ');

            float output = 0;
            float leftInput = float.Parse(splitInput[0]);
            float rightInput = float.Parse(splitInput[2]);

            switch (splitInput[1])
            {
                case "+":
                    output = leftInput + rightInput;
                    break;
                case "-":
                    output = leftInput - rightInput;
                    break;
                case "*":
                    output = leftInput * rightInput;
                    break;
                case "/":
                    output = leftInput / rightInput;
                    break;
            }

            return output.ToString();
        }

        public static string Square(string input)
        {
            float temp = float.Parse(input);
            return (temp * temp).ToString();
        }
    }
}