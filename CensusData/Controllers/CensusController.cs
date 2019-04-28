using CensusData.Models;
using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// Get the latest census data
        /// </summary>
        // GET: api/products
        [HttpGet]
        public Census Get()
        {
            Person[] data = new Person[100];

            // Return dummy data
            for (int i = 0; i < 100; i++)
            {
                data[i] = new Person();
            }
            return new Census() { People = data, Year = 2011 };
        }

        /// <summary>
        /// Get the people in the census for the specified year
        /// </summary>
        /// <param name="censusYear"></param>
        /// <returns></returns>
        [HttpGet("{censusYear}")]
        public Census Get(int censusYear)
        {
            Person[] data = new Person[100];

            // Return dummy data
            for (int i = 0; i < 100; i++)
            {
                data[i] = new Person();
            }
            return new Census() { People = data, Year=censusYear };
        }
    }
}
