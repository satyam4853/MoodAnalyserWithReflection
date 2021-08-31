using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalysesWithCore;
using MoodAnalysesWithReflectionConcept;
using System;

namespace MoodAnalyzerCheck
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// UC1 for Testcase1
        /// </summary>
        MoodAnalyser moodAnalyser;
        [DataRow("I am in sad mood")]
        [TestMethod]
        public void Testfunction(string message)
        {
            //Arrange
            moodAnalyser = new MoodAnalyser(message);
            //Act
            var actual = moodAnalyser.AnalyserMethod();
            //Assert
            Assert.AreEqual("SAD", actual);
        }
        /// <summary>
        /// UC1 for TC1.1
        /// </summary>
        /// <param name="message"></param>
        [DataRow("I am in any mood")]
        [TestMethod]
        public void Testfunctin(string message)
        {
            //Arrange
            moodAnalyser = new MoodAnalyser(message);
            //Act
            var actual = moodAnalyser.AnalyserMethod();
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        /// <summary>
        /// TC 3.1 for NullExceptions
        /// </summary>
        /// <param name="message"></param>
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingEmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("mood should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingNullMood()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.AnalyserMethod();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("mood should not be null", e.Message);
            }
        }
        [TestMethod] //UC4
        public void GivenMoodAnalysesClassName_ShouldRecureMoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalysesWithCore.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
            //Assert.AreEqual(expected, obj);



        }

        [TestMethod] //UC5
        public void GivenMoodAnalysesClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            //object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalysesWithCore.MoodAnalyser", "MoodAnalyser", "HAPPY");
            object obj = null;
            expected.Equals(obj);
        }
        [TestMethod] // UC5.2
        public void  GIveImproperClasssNameShouldThrownMoodAnalyserCustomExceptionUsingParametrerizedConstructor()
        {
            string expected = "Class Not Found";
                try
            {
                object moodAnalyserobject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserApp.DemoClass", "MoodAnalyser", "HAPPy");

            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        
        
        //UC6.1
        [TestMethod]
        ///[TestCategory("InvokeMethodReflection")]
        public void GiveInvokeMethod()
        {

            string actual;
            string message = "I am in a Happy mood";
            string methodName = "AnalyserMethod";
            string expected = "HAPPY";


            try
            {
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                actual = moodAnalyserFactory.InvokeMethod(methodName, message);
            }
            catch (MoodAnalyserCustomException e)
            {
                throw new Exception(e.Message);
            }
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Given Happy Message with improper method name UC6.2
        /// </summary>
        public void GiveInvokeMethodThrowException()
        {

            string actual;
            string message = "I am in a Happy mood";
            string methodName = "Analyse";
            string expected = "Happy";


            try
            {
                MoodAnalyserFactory moodanalyserfactory = new MoodAnalyserFactory();
                actual = moodanalyserfactory.InvokeMethod(methodName, message);
            }
            catch (MoodAnalyserCustomException e)
            {
                throw new Exception(e.Message);
            }
            Assert.AreEqual(expected, actual);
            }
    }
}
