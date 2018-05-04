using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraHamilton.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public override bool Equals(System.Object otherPost)
        {
            if (!(otherPost is Post))
            {
                return false;
            }
            else
            {
                Post newPost = (Post)otherPost;
                return this.PostId.Equals(newPost.PostId);
            }
        }

        public override int GetHashCode()
        {
            return this.PostId.GetHashCode();
        }

        public Post(string title, string content, int id = 0)
        {
            Title = title;
            Content = content;
            PostId = id;
        }

        public Post() { }
    }
}
