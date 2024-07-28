namespace FriendzyBlog.Api.v1.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}