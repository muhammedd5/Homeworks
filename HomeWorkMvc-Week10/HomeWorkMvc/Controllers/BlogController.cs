using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            Blog blog1 = new Blog(1,"başlık","açıklama","ahmet", "https://picsum.photos/id/237/200/300");
            Blog blog2 = new Blog(1,"başlık1","açıklama1","ahmet1", "https://picsum.photos/id/237/200/300");
            Blog blog3 = new Blog(1,"başlık2","açıklama2","ahmet2", "https://picsum.photos/id/237/200/300");
            Blog blog4 = new Blog(1,"başlık3","açıklama3","ahmet3", "https://picsum.photos/id/237/200/300");
            Blog blog5 = new Blog(1,"başlık4","açıklama4","ahmet4", "https://picsum.photos/id/237/200/300");

            

        

            List<Blog> list = new List<Blog>();
            list.Add(blog1);
            list.Add(blog2);
            list.Add(blog3);
            list.Add(blog4);
            list.Add(blog5);


            return View(list);
        }
    }
}
