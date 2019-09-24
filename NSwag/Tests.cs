//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using NUnit.Framework;
//using NUnit.Framework.Constraints;

//namespace TripServices.NSwag
//{
//    [TestFixture]
//    public class Tests
//    {

//        [Test]
//        public static void TestUsingCatalogOfferingsQueryBuildOptionsFromProducts()
//        {
//            var jsonSerializerSettings = new JsonSerializerSettings()
//            {
//                Formatting = Formatting.Indented
//            };

//            var rootWrapper = new
//            {
//                OfferQueryBuildFromProducts = new CatalogOfferingsQueryBuildOptionsFromProducts()
//                {
//                    ReturnBrandedFaresInd = true,
//                    BuildFromProductsRequest = BuildFromProductsRequestAir(),
//                }
//            };

//            Assert(JsonConvert.SerializeObject(rootWrapper, jsonSerializerSettings),AddOfferExampleString);
//        }

//        [Test]
//        public static void TestUsingCatalogOfferingsRequestAirExtended()
//        {
//            var jsonSerializerSettings = new JsonSerializerSettings()
//            {
//                Formatting = Formatting.Indented
//            };

//            var rootWrapper = new
//            {
//                CatalogOfferingsQueryRequest = new CatalogOfferingsQueryRequest
//                {
//                    CatalogOfferingsRequest = new[] { CatalogOfferingsRequestAir() }
//                }

//            };

//            Assert(JsonConvert.SerializeObject(rootWrapper, jsonSerializerSettings), AirSearchRequestExampleString);
//        }

       
//        private static BuildFromProductsRequestAir BuildFromProductsRequestAir()
//        {
//            return new BuildFromProductsRequestAir
//            {
//                PassengerCriteria = new List<PassengerCriteria>
//                {
//                    new PassengerCriteria
//                    {
//                        Age = 25,
//                        Number = 1, Value = "ADT"
//                    }
//                },
//                PricingModifiersAir = new PricingModifiersAirDetail
//                {
//                    CurrencyCode = "USD",
//                    FareSelection = new FareSelection {FareType = FaresFilterEnum.PublicAndPrivateFares},
//                },
//                ProductCriteriaAir = new List<ProductCriteriaAir>
//                {
//                    new ProductCriteriaAir
//                    {
//                        SpecificFlightCriteria = new List<SpecificFlightCriteria>
//                        {
//                            new SpecificFlightCriteria
//                            {
//                                FlightNumber = "2",
//                                Carrier = "QF",
//                                DepartureDate = new DateTime(2019, 10, 23),
//                                DepartureTime = "19:30:00",
//                                ArrivalDate = "2019-10-24",
//                                ArrivalTime = "06:10:00",
//                                From = "SIN",
//                                To = "SYD",
//                                ClassOfService = "S",
//                                Cabin = CabinAirEnum.Economy,
//                                SegmentSequence = 1
//                            }
//                        }
//                    }
//                }
//            };
//        }

//        private static CatalogOfferingsRequestAir CatalogOfferingsRequestAir()
//        {
//            var airRequest = new CatalogOfferingsRequestAir
//            {
//                MaxNumberOfOffersToReturn = 50,
//                ContentSourceList = new List<ContentSourceEnum> { ContentSourceEnum.NDC },
//                ReturnBrandedFaresInd = true,
//                PassengerCriteria =
//                    new List<PassengerCriteria>
//                    {
//                        new PassengerCriteria {Value = "ADT", Number = 1}
//                    },
//                SearchCriteriaFlight = new List<SearchCriteriaFlight>
//                {
//                    new SearchCriteriaFlight
//                    {
//                        DepartureDate = new DateTime(2019, 7, 16),
//                        From = new FromTo {Value = "SYD"},
//                        To = new FromTo {Value = "MEL"}
//                    }
//                }
//            };
//            return airRequest;
//        }

//        private static void Assert(string json, string actual)
//        {
//            var airSearchRequestResult = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

//            var airSearchRequestResultString = airSearchRequestResult.ToString();

//            NUnit.Framework.Assert.AreEqual(airSearchRequestResultString, actual);
//        }

//        private static string AddOfferExampleString
//        {
//            get
//            {
//                var path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + "\\AddOfferExample.json";
//                var stream = File.OpenText(path);

//                var s = stream.ReadToEnd();
//                var airSearchRequestExample = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
//                var airSearchRequestExampleString = airSearchRequestExample.ToString();
//                return airSearchRequestExampleString;
//            }
//        }
//        private static string AirSearchRequestExampleString
//        {
//            get
//            {
//                var path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + "\\AirSearchRequestExample.json";
//                var stream = File.OpenText(path);

//                var s = stream.ReadToEnd();
//                var airSearchRequestExample = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
//                var airSearchRequestExampleString = airSearchRequestExample.ToString();
//                return airSearchRequestExampleString;
//            }
//        }
//    }
//}