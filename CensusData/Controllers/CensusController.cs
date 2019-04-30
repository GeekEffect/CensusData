using CensusData.Models;
using CensusData.Services;
using Microsoft.AspNetCore.Mvc;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace CensusData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CensusController : ControllerBase
    {
        IPersonBuilderService builderService = new PersonBuilderService(new OccupationGeneratorService(), new PersonNameGenerator());
        int numberOfPeopleInCensus = 100;
        int defaultYear = 2011;

        /// <summary>
        /// Get the latest census data
        /// </summary>
        // GET: api/products
        [HttpGet(Name = "GetLatestCensus")]
        public Census Get()
        {
            return new Census() { People = builderService.Build(numberOfPeopleInCensus), Year = defaultYear };
        }

        /// <summary>
        /// Get the people in the census for the specified year
        /// </summary>
        /// <param name="censusYear"></param>
        /// <returns></returns>
        [HttpGet("{censusYear}", Name = "GetCensusDetails")]
        public Census Get(int censusYear)
        {
            return new Census() { People = builderService.Build(numberOfPeopleInCensus), Year = censusYear };
        }
    }
}
