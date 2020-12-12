using NUnit.Framework;
using System;
using LimaVector.Fabrics;
using LimaVector.Shape;

using System.Drawing;
using System.Collections.Generic;
using System.Collections;

namespace NUnitTestProject1
{
    public class ShapeTest
    {
        [Test]
        public void SSCreateTest() // тест на фабрику
        {
            SquareFabric squareFabric = new SquareFabric();
            AShape actual = squareFabric.CreateShape();

            //actual.GetType();           // метод объекта возвращает тип данных
            //typeof(SquareShape);                   // сюда передается конкретный тип данных ,возвращает тип данных,  и можно сравнивать с гет тайп
            
            Assert.AreEqual(typeof(SquareShape), actual.GetType());
            
        }


        public class SSTests
        {
            SquareShape squareShape;
            [SetUp] // выполняется перед каждым тестом 
            //[TearDown] // выполняется после каждого теста 
            //[OneTimeSetUp][OneTimeTearDown] срабатывают один раз после всех тестов
            public void SetUp() // позволяет сделать специальные настройки , например пересоздание объекта
            {
                squareShape = new SquareShape();
            }

            [Test, TestCaseSource(typeof(UpdateVerticesTestSource))]  // тест на правильность построения фигуры
            public void UpdateVerticesTest(PointF startPoint, PointF endPoint, List<PointF> expected)
            {
                squareShape.UpdateVertices(startPoint, endPoint);
                List<PointF> actual = squareShape.Vertices;

                CollectionAssert.AreEqual(expected, actual);
            }

            [Test, TestCaseSource(typeof(UpdateVerticesTestSource))] // тест на определение фигуры
            public void SelectTest(PointF startPoint, PointF endPoint, PointF point, bool expected)
            {
                squareShape.UpdateVertices(startPoint, endPoint);
                bool actual = squareShape.Select(point);

                Assert.AreEqual(expected, actual);
            }
        }
        public class UpdateVerticesTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new PointF(0, 0), new PointF(0, 10), new PointF(10, 10), new PointF(10, 0) };
            List<PointF> points2 = new List<PointF>() { new PointF(0, 0), new PointF(0, 20), new PointF(20, 20), new PointF(20, 0) };
            List<PointF> points3 = new List<PointF>() { new PointF(5, 5), new PointF(5, 10), new PointF(10, 10), new PointF(10, 5) };

            public IEnumerator GetEnumerator()
            {
                yield return new object[] {new PointF(0,0), new PointF (10,10), points1 }; 
                yield return new object[] {new PointF(0,0), new PointF (20,20), points2 }; 
                yield return new object[] {new PointF(5,5), new PointF (10,10), points3 }; 
            }
        }

        public class SelectTestSource : IEnumerable // сорс для проверки попадания в грань
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new PointF(0, 0), new PointF(10, 10), new PointF(5, 8), true};
                yield return new object[] { new PointF(0, 0), new PointF(20, 20), new PointF(10, 0), true};
                yield return new object[] { new PointF(5, 5), new PointF(10, 10), new PointF(50, 100), false};
            }
        }
    }
}