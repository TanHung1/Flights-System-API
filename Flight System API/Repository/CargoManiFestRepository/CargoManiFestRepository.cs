using FlightSystemAPI.Models;

namespace Flight_System_API.Repository.CargoManiFestRepository
{
    public class CargoManiFestRepository : ICargoManiFestRepository
    {
        private FlightContext _context;
        public CargoManiFestRepository(FlightContext context)
        {
            _context = context;
        }
        public bool CreateCargoManiFest(CargoManiFest cargoManiFest)
        {
            _context.cargoManiFests.Add(cargoManiFest);
            cargoManiFest.Version = 1;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCargoManiFest(int cargoManiFestId)
        {
            CargoManiFest cargoManiFest = _context.cargoManiFests.FirstOrDefault(x => x.Id == cargoManiFestId);
            _context.cargoManiFests.Remove(cargoManiFest);
            _context.SaveChanges();
            return true;
        }

        public List<CargoManiFest> GetAll()
        {
            return _context.cargoManiFests.ToList();
        }

        public CargoManiFest GetById(int id)
        {
            CargoManiFest cargoManiFest = _context.cargoManiFests.FirstOrDefault(x => x.Id == id);
            return cargoManiFest;
        }

        public bool UpdateCargoManiFest(CargoManiFest cargoManiFest)
        {
            CargoManiFest cargoManiFest1 = _context.cargoManiFests.FirstOrDefault(x => x.Id == cargoManiFest.Id);
            if (cargoManiFest1 != null)
            {

                _context.Entry(cargoManiFest1).CurrentValues.SetValues(cargoManiFest);
                cargoManiFest1.Version += 0.1f;
                _context.SaveChanges();
            }
            return true;
        }
    }
}
