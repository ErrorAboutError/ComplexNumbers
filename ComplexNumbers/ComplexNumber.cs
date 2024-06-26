﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    public class ComplexNumber
    {
        double realPartNumber;
        double imaginaryPartNumber;

        // Конструкторы
        public ComplexNumber()
        {
            realPartNumber = 0;
            imaginaryPartNumber = 0;
        }

        public ComplexNumber( double realPartNumberUser, double imaginaryPartNumberUser) {
            realPartNumber = realPartNumberUser;
            imaginaryPartNumber = imaginaryPartNumberUser;
        }

        // Функция перевода из радиан в градусы
        private static double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
        // Функция перевода из радиан в градусы
        private static double DegreesToRadians(double degree)
        {
            return degree * Math.PI / 180;
        }

        //Вычисление корня комплексного числа
        public static ComplexNumber[] ActionsWithComplexMD(ComplexNumber z1, int n)
        {
            double module;
            if (z1.realPartNumber != 0 && z1.imaginaryPartNumber == 0) module = Math.Abs(z1.realPartNumber);
            if (z1.realPartNumber == 0 && z1.imaginaryPartNumber != 0) module = Math.Abs(z1.imaginaryPartNumber);
            else module = Math.Pow(Math.Sqrt((z1.realPartNumber * z1.realPartNumber) + (z1.imaginaryPartNumber * z1.imaginaryPartNumber)), 1.0/n);

            //Считаем аргумент
            double arg = 0;
            if (z1.realPartNumber > 0 && z1.imaginaryPartNumber >= 0) arg = (Math.Atan(z1.imaginaryPartNumber / z1.realPartNumber));
            else if (z1.realPartNumber < 0 && z1.imaginaryPartNumber >= 0) arg = Math.PI - (Math.Atan(Math.Abs(z1.imaginaryPartNumber / z1.realPartNumber)));
            else if (z1.realPartNumber < 0 && z1.imaginaryPartNumber < 0) arg = Math.PI + (Math.Atan(Math.Abs(z1.imaginaryPartNumber / z1.realPartNumber)));
            else if (z1.realPartNumber > 0 && z1.imaginaryPartNumber < 0) arg = 2 * Math.PI - (Math.Atan(Math.Abs(z1.imaginaryPartNumber / z1.realPartNumber)));
            else if (z1.realPartNumber == 0 && z1.imaginaryPartNumber > 0) arg = Math.PI / 2;
            else  arg = (3*Math.PI) / 2;

            //if (x > 0 && y >= 0) arg = Math.Atan(y / x);
            //else if (x < 0 && y >= 0) arg = Math.PI - Math.Atan(Math.Abs(y / x));
            //else if (x < 0 && y < 0) arg = Math.PI + Math.Atan(Math.Abs(y / x));
            //else if (x > 0 && y < 0) arg = 2 * Math.PI - Math.Atan(Math.Abs(y / x));
            //else if (x == 0 && y > 0) arg = Math.PI / 2;
            //else arg = (3 * Math.PI) / 2;

            double tmp2;
            double tmp3;
            ComplexNumber[] root = new ComplexNumber[n];

            //for (int k = 0; k < grade; k++)
            //    res[k] = new ComplexNumber(Math.Round(module * Math.Cos((arg + 2 * Math.PI * k) / grade), 2),
            //        Math.Round(module * Math.Sin((arg + 2 * Math.PI * k) / grade), 2));

            // Считаем корни
            for (int i = 0; i < n; i++)
            {
                //    tmp2 = Math.Round(Math.Pow(module, 1 / n) * Math.Cos(DegreesToRadians((arg + 2 * Math.PI * i) / n)), 3);// * 1000);
                //    tmp3 = Math.Round(Math.Pow(module, 1 / n) * Math.Sin(DegreesToRadians((arg + 2 * Math.PI * i) / n)), 3); // *1000);
                tmp2 = Math.Round(module * Math.Cos((arg + 2 * Math.PI * i) / n), 3);// * 1000);
                tmp3 = Math.Round(module * Math.Sin((arg + 2 * Math.PI * i) / n), 3); // *1000);
                root[i] = new ComplexNumber(tmp2, tmp3);

                //res[k] = new ComplexNumber(Math.Round(module * Math.Cos((arg + 2 * Math.PI * k) / grade), 2),
                        //Math.Round(module * Math.Sin((arg + 2 * Math.PI * k) / grade), 2));
            }
            return root;
        }
       
        //Вывод корней
        public static string DerivationRoots(ComplexNumber[] root, int n)
        {
            string resultString = "\n";
            for (int i = 0; i < n; i++)
            {
                if (root[i].imaginaryPartNumber >= 0)
                {
                    resultString += "W" + i + "=" + (root[i].realPartNumber)
                        + " + " + (root[i].imaginaryPartNumber) + "i" + "\n";
                }
                else
                {
                    resultString += "W" + i + "=" + (root[i].realPartNumber)
                       + (root[i].imaginaryPartNumber) + "i" + "\n";
                }

            }
            return resultString;
        }

        // Метод вывода комплексного числа
        public static string ComplexNumberOutput(ComplexNumber z)
        {
            string resultComplexString = "\n";
            if (z.imaginaryPartNumber > 0)
            {
                resultComplexString += "z = " +
                z.realPartNumber + " + " +
                z.imaginaryPartNumber + "i";
                resultComplexString += "\nТригонометрическая форма: " + TrigonometricView(z);

            }
            else
            {
                resultComplexString += "z = " +
                z.realPartNumber +
                z.imaginaryPartNumber + "i";
                resultComplexString += "\nТригонометрическая форма: " + TrigonometricView(z);
            }
            return resultComplexString;

        }
        //Сложение комплексных чисел
        public static ComplexNumber ActionsWithComplex(ComplexNumber z1, ComplexNumber z2)
        {
            //
            double newRealPart = z1.realPartNumber + z2.realPartNumber;
            double newImaginaryPart = z1.imaginaryPartNumber + z2.imaginaryPartNumber;
            return new ComplexNumber(newRealPart, newImaginaryPart);// создание нового объекта класса
        }

        //Вычитание комплексных чисел
        public static ComplexNumber ActionsWithComplexSub(ComplexNumber z1, ComplexNumber z2)
        {
            double newRealPart = z1.realPartNumber - z2.realPartNumber;
            double newImaginaryPart = z1.imaginaryPartNumber - z2.imaginaryPartNumber;
            return new ComplexNumber(newRealPart, newImaginaryPart);// создание нового объекта класса
        }

        //Умножение комплексных чисел MD - Multiplication, division - умножение, деление
        public static ComplexNumber ActionsWithComplexMD(ComplexNumber z1, ComplexNumber z2)
        {
            double newRealPart = z1.realPartNumber * z2.realPartNumber - z1.imaginaryPartNumber * z2.imaginaryPartNumber;
            double newImaginaryPart = z1.realPartNumber * z2.imaginaryPartNumber + z2.realPartNumber * z1.imaginaryPartNumber;
            return new ComplexNumber(newRealPart, newImaginaryPart);// создание нового объекта класса
        }
        //Деление комплексных чисел MD - Multiplication, division - умножение, деление
        public static ComplexNumber ActionsWithComplexMDDiv(ComplexNumber z1, ComplexNumber z2)
        {
            double numerator_one = z1.realPartNumber * z2.realPartNumber + z1.imaginaryPartNumber * z2.imaginaryPartNumber;
            double numeratoe_two = z2.realPartNumber * z1.imaginaryPartNumber - z1.realPartNumber * z2.imaginaryPartNumber;
            double denominator = Math.Pow(z2.realPartNumber, 2) + Math.Pow(z2.imaginaryPartNumber, 2);
            return new ComplexNumber(numerator_one / (denominator), numeratoe_two / (denominator));
        }

        // Приведение комплексного числа к тригонометрическому виду
        public static string TrigonometricView(ComplexNumber z1)
        {
            double module = 0;
            if (z1.realPartNumber != 0 && z1.imaginaryPartNumber == 0) module = Math.Abs(z1.realPartNumber);
            if (z1.realPartNumber == 0 && z1.imaginaryPartNumber != 0) module = Math.Abs(z1.imaginaryPartNumber);
            else module = Math.Round(Math.Sqrt((z1.realPartNumber * z1.realPartNumber) + (z1.imaginaryPartNumber * z1.imaginaryPartNumber)), 3);

            //Считаем аргумент
           
            double arg = 0;
            if (z1.realPartNumber > 0 && z1.imaginaryPartNumber >= 0) arg = RadiansToDegrees(Math.Atan(z1.imaginaryPartNumber / z1.realPartNumber));
            else if (z1.realPartNumber < 0 && z1.imaginaryPartNumber >= 0) arg = Math.PI - RadiansToDegrees(Math.Atan(Math.Abs(z1.imaginaryPartNumber / z1.realPartNumber)));
            else if (z1.realPartNumber < 0 && z1.imaginaryPartNumber < 0) arg = Math.PI + RadiansToDegrees(Math.Atan(Math.Abs(z1.imaginaryPartNumber / z1.realPartNumber)));
            else if (z1.realPartNumber > 0 && z1.imaginaryPartNumber < 0) arg = 2 * Math.PI - RadiansToDegrees(Math.Atan(Math.Abs(z1.imaginaryPartNumber / z1.realPartNumber)));
            else if (z1.realPartNumber == 0 && z1.imaginaryPartNumber > 0) arg = Math.PI / 2;
            else arg = (3 * Math.PI) / 2;

            string resultStringTrigonometric;
            resultStringTrigonometric = module + " * " + "(cos(" + Math.Round(arg, 3) + ") - isin(" +Math.Round(arg, 3) +"))";
            return resultStringTrigonometric;    

        }

    }
}
