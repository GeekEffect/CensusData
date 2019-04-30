using CensusData.Models;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CensusData.Services
{
    public class PersonBuilderService : IPersonBuilderService
    {
        private IOccupationGeneratorService occupationGeneratorService;
        private IPersonNameGenerator personNameGenerator;

        public PersonBuilderService(IOccupationGeneratorService occupationGeneratorService, IPersonNameGenerator personNameGenerator)
        {
            this.occupationGeneratorService = occupationGeneratorService;
            this.personNameGenerator = personNameGenerator;
        }

        public Person[] Build(int count)
        {
            Person[] people = new Person[count];

            for(int i=0;i<count;i++)
            {
                people[i] = new Person() { Age = new Random().Next(18, 100), Name = personNameGenerator.GenerateRandomFirstAndLastName(), Occupation = occupationGeneratorService.GetRandomOccupation() };
            }

            return people;
        }
    }
}
