using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; }

        public bool IsLiked { get; set; }
        [BindProperty]
        public Guid BlogPostId { get; set; }
        [BindProperty]
        public string CommentDescription { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository,
            IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository blogPostCommentRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetAsync(urlHandle);
            if (BlogPost != null)
            {
                BlogPostId = BlogPost.Id;
                if (signInManager.IsSignedIn(User))
                {
                    var likes = await blogPostLikeRepository.GetLikesForBlog(BlogPost.Id);

                    var userId = userManager.GetUserId(User);

                    IsLiked = likes.Any(x => x.UserId == Guid.Parse(userId));
                }

                TotalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string urlHandle)
        {
            if (signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentDescription))
            {
                var userId = userManager.GetUserId(User);

                var comment = new BlogPostComment()
                {
                    BlogPostId = BlogPostId,
                    Description = CommentDescription,
                    DateAdded = DateTime.Now,
                    UserId = Guid.Parse(userId)
                };
                await blogPostCommentRepository.AddAsync(comment);
            }

            return RedirectToPage("/Blog/Details", new {urlHandle = urlHandle });


        }
    }
}
