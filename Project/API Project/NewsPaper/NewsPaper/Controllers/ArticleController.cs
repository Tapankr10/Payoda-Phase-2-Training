using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Model;
using NewsPaper.Repository;
using NewsPaper.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsPaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {

        private readonly ArticleService _articleService;

        public ArticleController(Service.ArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
      public async Task<IActionResult> GetAllArticle()
{
    try
    {
        var articles = await _articleService.GetAllArticleAsync();

        // Check if articles is null or empty
        if (articles == null || !articles.Any())
        {
            return NotFound("No articles found.");
        }

        return Ok(articles);
    }
    catch (Exception ex)
    {
        // Log the exception details (if you have a logging framework)
        // _logger.LogError(ex, "An error occurred while fetching articles.");

        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
    }
}


        // GET api/<ArticleController>/5
        //[HttpGet("{id}")]
        //public async Task<Article> Get(int id)
        //{
        //    return await _articleService.GetArticle(id);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await _articleService.GetArticle(id);
            if (article == null) return NotFound();

            // Increment view count
            article.Views += 1;
            await _articleService.UpdateArticlesync(article);

            return Ok(article);
        }



        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] Article article)
        {
            if (article == null) return BadRequest("Course cannot be null");

            await _articleService.AddArticleAsync(article);
            return CreatedAtAction(nameof(GetAllArticle), new { id = article.ArticleID }, article);
        }

        // PUT api/<ArticleController>/5
        //[HttpPut("{id}")]
        //[Authorize( Roles ="admin")]
        //public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article article)
        //{
        //    if (id != article.ArticleID) return BadRequest("Author ID mismatch");

        //    await _articleService.UpdateArticlesync(article);
        //    return NoContent();
        //}

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article article)
        {
            // Check if the user is in the 'admin' role
            if (!User.IsInRole("admin"))
            {
                // Return 403 Forbidden with a custom message in the response body
                return StatusCode(403, new { message = "Not Authorized: You must be an admin to update the article." });
            }

            // Check if the article ID matches
            if (id != article.ArticleID)
            {
                return BadRequest(new { message = "Article ID mismatch" });
            }

            try
            {
                await _articleService.UpdateArticlesync(article);
                return Ok(new { message = "Article updated successfully." });
            }
            catch (Exception ex)
            {
                // Optionally log the exception and return an error message
                return BadRequest(new { message = "Could not update the article.", error = ex.Message });
            }
        }


        // DELETE api/<ArticleController>/5

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            // Check if the user is in the 'admin' role
            if (!User.IsInRole("admin"))
            {
                // Return 403 Forbidden with a custom message in the response body
                return StatusCode(403, new { message = "Not Authorized: You must be an admin to delete the course." });
            }

            try
            {
                await _articleService.DeleteAsync(id);
                return Ok(new { message = "Deleted." });
            }
            catch (Exception ex)
            {
                // Optionally log the exception and return a meaningful message
                return BadRequest(new { message = "Could not delete the article.", error = ex.Message });
            }
        }

        [HttpGet("most-viewed")]
        public async Task<IActionResult> GetMostViewedArticles()
        {
            var articles = await _articleService.GetAllArticleAsync();
            var mostViewedArticles = articles.OrderByDescending(a => a.Views).Take(5);

            return Ok(mostViewedArticles);
        }
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularArticles(int minViews)
        {
            var articles = await _articleService.GetAllArticleAsync();
            var popularArticles = articles.Where(a => a.Views > minViews);

            return Ok(popularArticles);
        }
       


    }
}
