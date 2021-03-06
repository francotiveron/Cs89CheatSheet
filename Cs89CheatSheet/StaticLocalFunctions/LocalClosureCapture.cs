﻿using System;
using Xunit;

namespace Cs9CheatSheet.StaticLocalFunctions.LocalClosureCapture
{
    public class Tests
    {
        [Fact]
        public void Local_function()
        {
            int x = 1;

            int AddWithCapture(int a, int b)
            {
                x = 5;
                return a + b;
            }

            //static: trying to use x will cause a compiler error
            static int AddWithoutCapture(int a, int b)
            {
                //x = 5; // Error
                return a + b;
            }


            //static local functions CANNOT change external in-scope locals (x here)
            Assert.Equal(2, AddWithoutCapture(x, 1));
            //No side effects
            Assert.Equal(2, x + 1);

            //Non static local functions CAN change external in-scope locals (x here)
            Assert.Equal(2, AddWithCapture(x, 1));
            //Here the side effect is to change the result of a test with the same inputs
            Assert.NotEqual(2, x + 1);
        }

        [Fact]
        public void Lambda()
        {
            int x = 1;

            Func<int, int, int> addWithCapture = (a, b) => { x = 5; return a + b; };
            Func<int, int, int> addWithoutCapture = static (a, b) => { /*x = 9; //error */ return a + b; };

            //static lambdas CANNOT change external in-scope locals (x here)
            Assert.Equal(2, addWithoutCapture(x, 1));
            //No side effects
            Assert.Equal(2, x + 1);

            //Non static lambdas CAN change external in-scope locals (x here)
            Assert.Equal(2, addWithCapture(x, 1));
            //Here the side effect is to change the result of a test with the same inputs
            Assert.NotEqual(2, x + 1);

            //Same with lambdas

        }
    }
}
