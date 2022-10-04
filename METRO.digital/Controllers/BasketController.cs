using System.Net;
using AutoMapper;
using METRO.digital.Contracts;
using METRO.digital.Dtos;
using METRO.digital.Models;
using Microsoft.AspNetCore.Mvc;

namespace METRO.digital.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : Controller
{
    private readonly IBasketServices _basketServices;
    private readonly IArtIcleServices _articleServices;
    private readonly IMapper _mapper;

    public BasketsController(IBasketServices basketServices,
        IArtIcleServices articleServices,
        IMapper mapper)
    {
        _basketServices = basketServices;
        _articleServices = articleServices;
        _mapper = mapper;
    }

    // GET api/baskets/1
    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        try
        {
            var basket = _basketServices.GetBasket(id);
            return Ok(basket);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = exception.Message });
        }
    }

    // POST api/baskets
    [HttpPost]
    public IActionResult Post([FromBody] BasketWriteDto basketWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = _basketServices.CreateBasket(basketWriteDto);
        return Created($"/baskets/{id}", null);
    }

    // POST api/baskets/1/article-line
    [HttpPost("{id}/article-line")]
    public IActionResult Post(long id, [FromBody] ArticleWriteDto articleWriteDto)
    {
        try
        {
            var result = _articleServices.CreateArtIcle(id, articleWriteDto) > 0;
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(exception.Message);
        }
    }

    // PUT api/baskets/1
    [HttpPut("{id}")] 
    public IActionResult Put(long id, [FromBody] BasketWriteDto basketWriteDto)
    {
        try
        {
            _basketServices.UpdateBasket(id, basketWriteDto.Status);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(exception.Message);
        }
    }
}