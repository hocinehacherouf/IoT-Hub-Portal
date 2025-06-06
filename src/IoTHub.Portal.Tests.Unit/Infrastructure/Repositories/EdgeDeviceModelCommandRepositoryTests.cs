// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Tests.Unit.Infrastructure.Repositories
{
    public class EdgeDeviceModelCommandRepositoryTests : BackendUnitTest
    {
        private EdgeDeviceModelCommandRepository edgeDeviceModelCommandRepository;

        public override void Setup()
        {
            base.Setup();

            this.edgeDeviceModelCommandRepository = new EdgeDeviceModelCommandRepository(DbContext);
        }

        [Test]
        public async Task GetAll_ExitingEdgeDeviceModelCommands_EdgeDeviceModelCommandsReturned()
        {
            // Arrange
            var expectedEdgeDeviceModelCommands = Fixture.CreateMany<EdgeDeviceModelCommand>(5).ToList();

            await DbContext.AddRangeAsync(expectedEdgeDeviceModelCommands);

            _ = await DbContext.SaveChangesAsync();

            // Act
            var result = this.edgeDeviceModelCommandRepository.GetAll().ToList();

            // Assert
            _ = result.Should().BeEquivalentTo(expectedEdgeDeviceModelCommands);
        }
    }
}
