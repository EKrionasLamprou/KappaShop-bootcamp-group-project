using KappaCreations.Database;
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
        readonly OrderRepository _repo;

        public OrderController()
        {
            _db = new ShopContext();
            _repo = new OrderRepository(_db);
        }
        public OrderController(ShopContext db)
        {
            _db = db;
            _repo = new OrderRepository(_db);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            var orders = await _repo.GetAllAsync();
            var response = OrderDTO.MapToCamelCase(orders);

            return Json(new { data = response });
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

        [HttpGet]
        [Route("api/order/count")]
        public async Task<IHttpActionResult> GetCountAsync()
        {
            int count = await _repo.CountAsync();
            return Ok(new { count });
        }

        [HttpPost]
        public IHttpActionResult PostAsync(OrderDTO data)
        {
            Order order;
            object response;

            try
            {
                order = data.Map();
                _repo.Add(order);
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                return BadRequest(FormatDbEntityValidationException(ex));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(FormatDbUpdateException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            response = OrderDTO.MapToCamelCase(order);
            return Ok(response);
        }

        [HttpPatch]
        [Route("api/order/updateStatus")]
        public async Task<IHttpActionResult> PatchUpdateStatusAsync(int orderId, int status)
        {
            const int minStatus = -1;
            const int maxStatus = 3;
            Order order;
            bool result;
            object response;

            try
            {
                if (status < minStatus || status > maxStatus)
                {
                    return BadRequest($"The status must be between values of {minStatus} and {maxStatus}.");
                }

                order = await _repo.GetAsync(orderId);
                if (order is null)
                {
                    return NotFound();
                }

                order.OrderStatus = (OrderStatus)status;
                result = _repo.Update(order);
                await _db.SaveChangesAsync();

                if (!result)
                {
                    return NotFound();
                }
            }
            catch (DbEntityValidationException ex)
            {
                return BadRequest(FormatDbEntityValidationException(ex));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(FormatDbUpdateException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            response = OrderDTO.MapToCamelCase(order);
            return Ok(response);
        }

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