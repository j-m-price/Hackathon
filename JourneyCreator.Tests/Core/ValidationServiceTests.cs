using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using JourneyCreator.Core.Services;
using Xunit;

namespace JourneyCreator.Tests.Core
{
    public class ValidationServiceTests
    {
        [Fact]
        public void Validate_ReturnsAnEmptyList_WhenValid()
        {
            var sut = new ValidationService();

            var journey = new Journey
            {
                Id = "0",
                Publisher = "James Price",
                Product = "Pet",
                Pages = new List<Page>(),
                GTMSettings = new GTMSettings()
            };

            var result = sut.Validate(journey);

            Assert.True(result.Count == 0);
        }

        [Fact]
        public void Validate_ReturnsMultipleError_WhenPublisher_IsEmpty()
        {
            var sut = new ValidationService();

            var journey = new Journey
            {
                Id = "0",
                Publisher = "",
                Product = "Pet",
                Pages = new List<Page>(),
                GTMSettings = new GTMSettings()
            };

            var result = sut.Validate(journey);

            Assert.True(result.Count == 2);
            Assert.True(result.Contains("Publisher must not be empty"));
            Assert.True(result.Contains("Publisher must be greater than 2 characters"));
        }

        [Fact]
        public void Validate_ReturnsAnError_WhenPublisher_IsLessThan2Characters()
        {
            var sut = new ValidationService();

            var journey = new Journey
            {
                Id = "0",
                Publisher = "1",
                Product = "Pet",
                Pages = new List<Page>(),
                GTMSettings = new GTMSettings()
            };

            var result = sut.Validate(journey);

            Assert.True(result.Count == 1);
            Assert.True(result.Contains("Publisher must be greater than 2 characters"));
        }

        public static IEnumerable<object[]> InvalidJourneys
        {
            get
            {
                return new[]
                    {
                    // invalid id
                    // Todo: add more invalid id scenarios. e.g. -1
                    new object[] {
                        new Journey
                        {
                            Id = "0",
                            Publisher = "James Price",
                            Product = "Pet",
                            Pages = new List<Page>(),
                            GTMSettings = new GTMSettings()
                        },
                        true
                    },
                    // invalid publisher - empty string
                    // Todo: add more invalid publisher scenarios. e.g. just whitespace
                    new object[] {
                        new Journey
                        {
                            Id = "1",
                            Publisher = "",
                            Product = "Pet",
                            Pages = new List<Page>(),
                            GTMSettings = new GTMSettings()
                        },
                        true
                    },
                    // invalid product id
                    // Todo: add more invalid productId scenarios. e.g. -1
                    new object[] {
                        new Journey
                        {
                            Id = "1",
                            Publisher = "James Price",
                            Product = "",
                            Pages = new List<Page>(),
                            GTMSettings = new GTMSettings()
                        },
                        true
                    },
                    // invalid GTM settings
                    // Todo: add more invalid GTMSettings scenarios.
                    new object[] {
                        new Journey
                        {
                            Id = "1",
                            Publisher = "James Price",
                            Product = "Pet",
                            Pages = new List<Page>(),
                            GTMSettings = null
                        },
                        true
                    },
                    new object[] {
                        new Journey
                        {
                            Id = "1",
                            Publisher = "James Price",
                            Product = "Pet",
                            Pages = new List<Page>(),
                            GTMSettings = new GTMSettings
                            {
                                Frequency = "",
                                Excluded = new List<string>()
                            }
                        },
                        true
                    }
                };
            }
        }

        public static IEnumerable<object[]> ValidJourney
        {
            get
            {
                return new[]
                    {
                    // Todo: update valid scenarion
                    new object[] {
                        new Journey
                        {
                            Id = "1",
                            Publisher = "James Price",
                            Product = "Pet",
                            Pages = new List<Page>(),
                            GTMSettings = new GTMSettings
                            {
                                Frequency = "onBlur",
                                Excluded = new List<string>()
                            }
                        },
                        false
                    }
                };
            }
        }
    }
}
