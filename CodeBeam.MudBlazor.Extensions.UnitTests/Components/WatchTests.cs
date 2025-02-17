﻿using Bunit;
using FluentAssertions;
using MudExtensions.UnitTests.TestComponents;

namespace MudExtensions.UnitTests.Components
{
    [TestFixture]
    public class WatchTests : BunitTest
    {
        [Test]
        public void WatchInitialValueTest()
        {
            var comp = Context.RenderComponent<WatchTest>();
            var watch = comp.FindComponent<MudWatch>();
            watch.Instance.Value.Should().Be(new TimeSpan(1, 0, 0));
        }

    }
}
