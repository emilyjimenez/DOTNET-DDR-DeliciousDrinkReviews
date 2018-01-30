using System;
using System.ComponentModel.DataAnnotations;
using DDR.Models;

namespace DDR.ViewModels
{
    public class CommentOnPost
    {
        public int CommentId { get; set; }
        public string UserName { get; set; } = null;
        public string Content { get; set; } = null;
        public int PostId { get; set; }
        public Post Post = new Post();
        public int CurrentPostId { get; set; }

        public CommentOnPost(int PostId)
        {
            CurrentPostId = PostId;
        }


        public CommentOnPost()
        {
        }
    }
}
