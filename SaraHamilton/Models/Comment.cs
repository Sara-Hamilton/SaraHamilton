using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraHamilton.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int CommentId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public string Body { get; set; }

        public virtual ApplicationUser User { get; set; }

        public override bool Equals(System.Object otherComment)
        {
            if (!(otherComment is Comment))
            {
                return false;
            }
            else
            {
                Comment newComment = (Comment)otherComment;
                return this.CommentId.Equals(newComment.CommentId);
            }
        }

        public override int GetHashCode()
        {
            return this.CommentId.GetHashCode();
        }
    }
}
