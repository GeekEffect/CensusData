using CensusData.Models;

namespace CensusData.Services
{
    public interface IPersonBuilderService
    {
        Person[] Build(int count);
    }
}