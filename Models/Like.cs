

using System;
using System.ComponentModel.DataAnnotations;

namespace Bright_Ideas.Models
{
    public class Like
    {

        public int LikeId {get;set;}
        public int PostId {get;set;}
        public Post Post {get;set;}
        public int UserId {get;set;}
        public User User {get;set;} 
        public DateTime created_at {get;set;}

    }
}