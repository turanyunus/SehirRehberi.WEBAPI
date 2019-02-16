using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(c => c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = _context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == cityId);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photos = _context.Photos.FirstOrDefault(p => p.Id == id);
            return photos;
        }

        public List<Photo> GetPhotosByCity(int Id)
        {
            var photo = _context.Photos.Where(p => p.CityId == Id).ToList();
            return photo;  
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
