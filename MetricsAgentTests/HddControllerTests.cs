using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetricsAgentTests
{
    public class HddControllerUnitTests
    {
        private HddMetricsController controller;

        public HddControllerUnitTests()
        {
            controller = new HddMetricsController();
        }

        [Fact]
        public void GetHddMetrics_ReturnsOk()
        {
            //Arrange
            var left = 1024;

            //Act
            var result = controller.GetHddMetrics(left);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}