using FlightSystemAPI.Models;

namespace Flight_System_API.Repository.CargoManiFestRepository
{
    public interface ICargoManiFestRepository
    {
        List<CargoManiFest> GetAll();

        public CargoManiFest GetById(int id);
        public bool CreateCargoManiFest(CargoManiFest cargoManiFest);
        public bool UpdateCargoManiFest(CargoManiFest cargoManiFest);
        public bool DeleteCargoManiFest(int cargoManiFestId);
    }
}
