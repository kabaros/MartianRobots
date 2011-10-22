using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Robots;
using MartianRobots.Parsers;
using MartianRobots.ProblemDescription;
using MartianRobots.Builder;
using MartianRobots.Exceptions;

namespace TestClient
{
    public partial class TestClient : Form
    {
        public TestClient()
        {
            InitializeComponent();
        }

        private void btnSendCommands_Click(object sender, EventArgs e)
        {
            StringBuilder allResults = new StringBuilder();

            try
            {
                var builder = new PlanetBuilder();
                IParser parser = new InstructionParser();
                PlanetDescription planetDescription = parser.Parse(tbCommands.Text);
                Planet planet = builder.BuildPlanet(planetDescription);
                
                while (planet.Robots.Count > 0)
                {
                    Robot robot = planet.Robots.Dequeue();
                    robot.ExecuteCommands();
                    string result = String.Format("{0} {1} {2}{3}", robot.CurrentPosition.X,
                    robot.CurrentPosition.Y, robot.CurrentOrientation.ToString()[0], ((robot.IsLost) ? " LOST" : ""));

                    allResults.Append(result.Trim() + "\r\n");
                }

                
            }
            catch (MartianException ex)
            {
                allResults.Append(ex.Message + "\r\n");
            }
            catch (Exception ex)
            {
                allResults.Append("Unhandled Exception: " + ex.Message + "\r\n");
            }
            tbResult.Text = allResults.ToString();
        }
    }
}
