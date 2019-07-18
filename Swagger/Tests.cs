﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TripServices.Swagger.Model;

namespace TripServices.Swagger
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public static void TestUsingCatalogOfferingsRequestAirExtended()
        {
            var req = new CatalogOfferingsQueryRequest
            {
                CatalogOfferingsRequest = new List<CatalogOfferingsRequest> { CatalogOfferingsRequestAir()}
            };

            Assert(req.ToJson());
        }

        [Test]
        public static void TestUsingExtensionPoint_Shared()
        {
            var req = new CatalogOfferingsQueryRequest
            {
                CatalogOfferingsRequest = new List<CatalogOfferingsRequest>
                {
                    new CatalogOfferingsRequest
                    {
                     //   ExtensionPoint_Shared = CatalogOfferingsRequestAir()
                    }
                }
            };

            Assert(req.ToJson());
        }


        private static CatalogOfferingsRequestAir CatalogOfferingsRequestAir()
        {
            var airRequest = new CatalogOfferingsRequestAir
            {
                MaxNumberOfOffersToReturn = 50,
                ContentSourceList = new List<ContentSourceEnum> { ContentSourceEnum.NDC },
                ReturnBrandedFaresInd = true,
                PassengerCriteria =
                    new List<PassengerCriteria>
                    {
                        new PassengerCriteria {Value = "ADT", Number = 1}
                    },
                SearchCriteriaFlight = new List<SearchCriteriaFlight>
                {
                    new SearchCriteriaFlight
                    {
                        DepartureDate = new DateTime(2019, 7, 16),
                        From = new FromTo {Value = "SYD"},
                        To = new FromTo {Value = "MEL"}
                    }
                }
            };
            return airRequest;
        }

        private static void Assert(string json)
        {
            var airSearchRequestResult = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            var airSearchRequestResultString = airSearchRequestResult.ToString();

            NUnit.Framework.Assert.AreEqual(airSearchRequestResultString, AirSearchRequestExampleString);
        }


        private static string AirSearchRequestExampleString
        {
            get
            {
                var path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + "\\AirSearchRequestExample.json";
                var stream = File.OpenText(path);

                var s = stream.ReadToEnd();
                var airSearchRequestExample = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
                var airSearchRequestExampleString = airSearchRequestExample.ToString();
                return airSearchRequestExampleString;
            }
        }
    }
}