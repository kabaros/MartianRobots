using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Robots;
using MartianRobots.Parsers;
using MartianRobots.ProblemDescription;
using MartianRobots.Builder;

namespace MarsTest
{
    public class TestDescription
    {
        public string Test {get; set;}
        public string ExpectedResult { get; set; }

        public TestDescription(string test, string result)
        {
            Test = test;
            ExpectedResult = result;
        }
    }

    [TestClass]
    public class RobotTests
    {
        static List<TestDescription> Tests = new List<TestDescription>();

        [ClassInitialize()]
        static public void MyClassInitialize(TestContext testContext) {
            var testDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\RobotTests";
            var resultDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\RobotResults";

            foreach (FileInfo file in new DirectoryInfo(testDirectory).GetFiles())
            {
                using (TextReader testReader = new StreamReader(file.FullName))
                {
                    string test, result;
                    test = testReader.ReadToEnd();

                    using (TextReader resultReader = new StreamReader(resultDirectory + "\\" + file.Name))
                    {
                        result = resultReader.ReadToEnd();
                    }
                    if (test != null && result != null)
                    {
                        TestDescription description = new TestDescription(test, result);
                        Tests.Add(description);
                    }
                }
            }
        }

        [TestMethod]
        public void TestFromFiles()
        {
            foreach (TestDescription description in Tests)
            {
                IParser parser = new InstructionParser();
                PlanetDescription planetDescription = parser.Parse(description.Test);
                Planet planet = new PlanetBuilder().BuildPlanet(planetDescription);

                StringBuilder allResults = new StringBuilder();

                while (planet.Robots.Count > 0)
                {
                    Robot robot = planet.Robots.Dequeue();
                    robot.ExecuteCommands();
                    string result = String.Format("{0} {1} {2}{3}", robot.CurrentPosition.X,
                        robot.CurrentPosition.Y, robot.CurrentOrientation.ToString()[0], ((robot.IsLost) ? " LOST" : ""));

                    allResults.Append(result.Trim()+"\r\n");
                }

                Assert.AreEqual(allResults.ToString().Trim(), description.ExpectedResult.Trim());
            }
        }
    }
}
