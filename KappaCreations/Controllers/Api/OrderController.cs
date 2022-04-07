﻿using KappaCreations.Database;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System.Threading.Tasks;
using System.Web.Http;
using KappaCreations.Models;
using System.Data.Entity.Validation;
using static KappaCreations.Utilities;
using System.Data.Entity.Infrastructure;
using System;

namespace KappaCreations.Controllers.Api
{
    public class OrderController : ApiController
    {
        readonly ShopContext _db;
        readonly Repository<Order> _repo;

        public OrderController()
        {
            _db = new ShopContext();
            _repo = new Repository<Order>();
        }
        public OrderController(ShopContext db)
        {
            _db = db;
            _repo = new Repository<Order>();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            var orders = await _repo.GetAllAsync();
            var response = OrderDTO.MapToCamelCase(orders);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var order = await _repo.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var response = OrderDTO.MapToCamelCase(order);

            return Ok(response);
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> PostAsync(OrderDTO data)
        //{
        //    Order order;
        //    object response;

        //    try
        //    {
        //        order = data.Map();
        //        _repo.Add(order);
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        return BadRequest(FormatDbEntityValidationException(ex));
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        return BadRequest(FormatDbUpdateException(ex));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    response = OrderDTO.MapToCamelCase(order);
        //    return Ok(response);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}