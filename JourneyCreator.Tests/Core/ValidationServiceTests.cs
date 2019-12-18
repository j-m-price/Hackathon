using System.Collections.Generic;
using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using JourneyCreator.Core.Services;
using Xunit;

namespace JourneyCreator.Tests.Core
{
    public class ValidationServiceTests
    {
        [Theory]
        [MemberData(nameof(ValidJourney))]
        [MemberData(nameof(InvalidJourneys))]
        public void Validate_ReturnsTrueWhenValid_AndFalseWhenInvalid(Journey journey, bool expected)
        {
            var sut = new ValidationService();

            var result = sut.Validate(journey);

            Assert.Equal(expected, result);
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
                        false
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
                        false
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
                        false
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
                        false
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
                        false
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
                        true
                    }
                };
            }
        }
    }
}
