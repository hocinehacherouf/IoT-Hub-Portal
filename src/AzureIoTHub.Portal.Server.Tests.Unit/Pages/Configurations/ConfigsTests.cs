// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Tests.Unit.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using AzureIoTHub.Portal.Client.Pages.Configurations;
    using Models.v10;
    using Helpers;
    using Bunit;
    using Client.Exceptions;
    using Client.Models;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using MudBlazor.Services;
    using NUnit.Framework;
    using RichardSzalay.MockHttp;

    [TestFixture]
    public class ConfigsTests : TestContextWrapper, IDisposable
    {
        private MockHttpMessageHandler mockHttpClient;

        [SetUp]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
            _ = TestContext.Services.AddMudServices();
            this.mockHttpClient = TestContext.Services.AddMockHttpClient();
            _ = TestContext.Services.AddSingleton(new PortalSettings { IsLoRaSupported = false });

            this.mockHttpClient.AutoFlush = true;

            _ = TestContext.JSInterop.SetupVoid("mudPopover.connect", _ => true);
            _ = TestContext.JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
        }

        [TearDown]
        public void TearDown() => TestContext?.Dispose();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        [TestCase]
        public void ConfigsPageMustLoadConfigurations()
        {
            // Arrange
            var configurations = new List<ConfigListItem>
            {
                new(),
                new()
            };

            _ = this.mockHttpClient
                .When(HttpMethod.Get, "/api/edge/configurations")
                .RespondJson(configurations);

            // Act
            var cut = RenderComponent<Configs>();
            var grid = cut.WaitForElement("div.mud-grid", TimeSpan.FromSeconds(5));

            // Assert
            _ = cut.Markup.Should().NotBeEmpty();
            _ = grid.InnerHtml.Should().NotBeEmpty();
            _ = cut.FindAll("tr").Count.Should().Be(3);
        }

        [TestCase]
        public void ConfigsPageShouldProcessProblemDetailsExceptionWhenIssueOccursOnGettingConfigurations()
        {
            // Arrange
            _ = this.mockHttpClient
                .When(HttpMethod.Get, "/api/edge/configurations")
                .Throw(new ProblemDetailsException(new ProblemDetailsWithExceptionDetails()));

            // Act
            var cut = RenderComponent<Configs>();
            var grid = cut.WaitForElement("div.mud-grid", TimeSpan.FromSeconds(5));

            // Assert
            _ = grid.InnerHtml.Should().NotBeEmpty();
            _ = cut.FindAll("tr").Count.Should().Be(2);
        }
    }
}