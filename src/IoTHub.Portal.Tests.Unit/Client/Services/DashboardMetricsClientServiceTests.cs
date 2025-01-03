// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Tests.Unit.Client.Services
{
    using static MediaTypeNames;

    [TestFixture]
    public class DashboardMetricsClientServiceTests
    {
        [Test]
        public async Task GetPortalMetricsMustReturnLogsWhenNoError()
        {
            // Arrange
            var expectedPortalMetric = new PortalMetric
            {
                DeviceCount = 1,
                ConnectedDeviceCount = 2,
                EdgeDeviceCount = 3,
                ConnectedEdgeDeviceCount = 4,
                FailedDeploymentCount = 5,
                ConcentratorCount = 6
            };

            using var mockHttp = new MockHttpMessageHandler();

            _ = mockHttp.When(HttpMethod.Get, "http://localhost/api/dashboard/metrics")
                .Respond(Application.Json, JsonSerializer.Serialize(expectedPortalMetric));

            using var client = new HttpClient(mockHttp)
            {
                BaseAddress = new Uri("http://localhost")
            };

            var dashboardMetricsClientService = new DashboardMetricsClientService(client);

            // Act
            var result = await dashboardMetricsClientService.GetPortalMetrics();

            // Assert
            _ = result.Should().NotBeNull();

            _ = result.Should().BeEquivalentTo(expectedPortalMetric);
        }

        [Test]
        public async Task GetPortalMetricsMustThrowProblemDetailsExceptionWhenErrorOccurs()
        {
            // Arrange
            using var mockHttp = new MockHttpMessageHandler();

            _ = mockHttp.When(HttpMethod.Get, "http://localhost/api/dashboard/metrics")
                .Throw(new ProblemDetailsException(new ProblemDetailsWithExceptionDetails()));

            using var client = new HttpClient(mockHttp)
            {
                BaseAddress = new Uri("http://localhost")
            };

            var dashboardMetricsClientService = new DashboardMetricsClientService(client);

            // Act
            var act = () => dashboardMetricsClientService.GetPortalMetrics();

            // Assert
            _ = await act.Should().ThrowAsync<ProblemDetailsException>();
        }
    }
}
