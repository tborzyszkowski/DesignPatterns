using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestSingleton{
    [TestClass]
    public class UnitTestSingleton{

        [TestMethod]
        public void SameInstanceCheck(){
            var one = SingletonSecured.getInstance();
            var two = SingletonSecured.getInstance();

            Assert.AreSame(one, two);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void OnlyOneInstanceCheck(){
                Parallel.For(0, 5000, task => {
                SingletonSecured.getInstance();
            });
            Assert.AreEqual(1, SingletonSecured.counter);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void SameInstanceCheck1(){
            var one = Child.Instance;
            var two = Child.Instance;

            Assert.AreSame(one, two);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void SameInstanceCheck2()
        {
            var one = ChildOfChild.Instance;
            var two = Child.Instance;

            Assert.AreSame(one, two);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void OnlyOneInstanceCheck1(){
            Parallel.For(0, 5000, task => {
                var x = ChildOfChild.Instance;
            });
            Assert.AreEqual(1, ChildOfChild.counter);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void SameInstanceCheckParallel()
        {
            Child one = null;
            Child two = null;
            Parallel.Invoke(
                () => { one = Child.Instance; },
                () => { two = Child.Instance; }
            );

            Assert.AreSame(one, two);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void SameInstanceCheckParallel1()
        {
            Child one = null;
            Child two = null;
            Parallel.Invoke(
                () => { one = Child.Instance; },
                () => { two = ChildOfChild.Instance; }
            );

            Assert.AreSame(one, two);
        }
        //-----------------------------------------------------
        [TestMethod]
        public void ChildCheck()
        {
            var one = Second_Child.Instance;
            var two = Child.Instance;
            Assert.AreNotSame(one, two);
        }

        
    }
}