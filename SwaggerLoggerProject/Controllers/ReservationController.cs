using Microsoft.AspNetCore.Mvc;
using SwaggerLoggerProject.Data;
using SwaggerLoggerProject.Models;
using SwaggerLoggerProject.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerLoggerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly AppDbContext _dbc = new AppDbContext();

        [HttpGet]
        public List<ReservationViewModel> Get()
        {
            List<ReservationViewModel> list = _dbc
                .ReservationMenuItems
                .Select(r => r.Reservation)
                .Distinct()
                .Select(r => new ReservationViewModel
                {
                    Name = r.Name,
                    Date = r.Date,
                    MenuItems = _dbc
                        .ReservationMenuItems
                        .Where(rmi => rmi.ReservationId == r.Id)
                        .Select(rmi => rmi.MenuItem)
                        .ToList()
                })
                .ToList();

            return list;
        }

        [HttpGet("{id}")]
        public ReservationViewModel Get(int id)
        {
            ReservationViewModel reservation = _dbc
                .ReservationMenuItems
                .Where(rmi => rmi.ReservationId == id)
                .Select(r => r.Reservation)
                .Select(r => new ReservationViewModel
                {
                    Name = r.Name,
                    Date = r.Date,
                    MenuItems = _dbc
                        .ReservationMenuItems
                        .Where(rmi => rmi.ReservationId == r.Id)
                        .Select(rmi => rmi.MenuItem)
                        .ToList()
                })
                .FirstOrDefault();

            return reservation;
        }

        [HttpPost]
        public void Post([FromBody] ReservationViewModel value)
        {
            int id = _dbc.Reservations.Last().Id + 1;

            Reservation newReservation = new Reservation { 
                Id = id,
                Name = value.Name,
                Date = value.Date
            };
            _dbc.Reservations.Add(newReservation);

            foreach (MenuItem mi in value.MenuItems)
            {
                ReservationMenuItems rmi = new ReservationMenuItems
                {
                    MenuItemId = mi.Id,
                    ReservationId = newReservation.Id
                };
                _dbc.ReservationMenuItems.Add(rmi);
            }

            _dbc.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReservationViewModel value)
        {
            Reservation reservation = _dbc
                .Reservations
                .Where(r => r.Id == id)
                .FirstOrDefault();

            if (reservation != null)
            {
                reservation.Name = value.Name;
                reservation.Date = value.Date;

                var rangeMI = _dbc.ReservationMenuItems
                    .Where(rmi => rmi.ReservationId == id).ToList();
                _dbc.ReservationMenuItems.RemoveRange(rangeMI);
                
                foreach (MenuItem mi in value.MenuItems)
                {
                    ReservationMenuItems rmi = new ReservationMenuItems
                    {
                        MenuItemId = mi.Id,
                        ReservationId = id
                    };
                    _dbc.ReservationMenuItems.Add(rmi);
                }

                _dbc.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Reservation reservationToDelete = _dbc.Reservations.Find(id);

            if (reservationToDelete != null)
            {
                var rangeMI = _dbc.ReservationMenuItems
                    .Where(rmi => rmi.ReservationId == id).ToList();
                
                _dbc.ReservationMenuItems.RemoveRange(rangeMI);

                _dbc.Reservations.Remove(reservationToDelete);

                _dbc.SaveChanges();
            }
        }
    }
}
