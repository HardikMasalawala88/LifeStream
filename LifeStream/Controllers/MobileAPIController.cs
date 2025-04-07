using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LifeStream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileAPIController : ControllerBase
    {
        // Sample data (in-memory list for demonstration)
        private static List<string> data = new List<string>
        {
            "Item1", "Item2", "Item3"
        };

        // GET: api/MobileAPI
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetItems()
        {
            return Ok(data);
        }

        // GET: api/MobileAPI/1
        [HttpGet("{id}")]
        public ActionResult<string> GetItem(int id)
        {
            if (id < 0 || id >= data.Count)
            {
                return NotFound("Item not found");
            }
            return Ok(data[id]);
        }

        // POST: api/MobileAPI
        [HttpPost]
        public ActionResult AddItem([FromBody] string newItem)
        {
            if (string.IsNullOrEmpty(newItem))
            {
                return BadRequest("Item cannot be empty");
            }

            data.Add(newItem);
            return CreatedAtAction(nameof(GetItem), new { id = data.Count - 1 }, newItem);
        }

        // PUT: api/MobileAPI/1
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] string updatedItem)
        {
            if (id < 0 || id >= data.Count)
            {
                return NotFound("Item not found");
            }

            data[id] = updatedItem;
            return NoContent();
        }

        // DELETE: api/MobileAPI/1
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            if (id < 0 || id >= data.Count)
            {
                return NotFound("Item not found");
            }

            data.RemoveAt(id);
            return NoContent();
        }
    }
}
