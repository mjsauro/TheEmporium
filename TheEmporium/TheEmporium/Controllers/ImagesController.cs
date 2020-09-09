using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
using TheEmporium.Repositories.Interfaces;

namespace TheEmporium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageRepository _imageRepository;

        public ImagesController(ApplicationDbContext context, IImageRepository imageRepository)
        {
            _context = context;
            _imageRepository = imageRepository;
        }

        // GET: api/Images
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Images>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Images>>> GetImages()
        {
            var images = await _imageRepository.GetAll();
            return Ok(images);
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Images>> GetImages(int id)
        {
            var images = await _imageRepository.Get(id);

            if (images == null)
            {
                return NotFound();
            }

            return images;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImages(int id, Images images)
        {
            if (id != images.Id)
            {
                return BadRequest();
            }

            await _imageRepository.Update(images);
            return NoContent();
        }

        // POST: api/Images
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Images>> PostImages(Images images)
        {
            await _imageRepository.Add(images);

            return CreatedAtAction("GetImages", new { id = images.Id }, images);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Images>> DeleteImages(int id)
        {
            var images = await _imageRepository.Get(id);
            if (images == null)
            {
                return NotFound();
            }

            _imageRepository.Remove(images);

            return images;
        }
    }
}
