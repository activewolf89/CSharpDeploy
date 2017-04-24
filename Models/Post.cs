

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bright_Ideas.Models
{
    public class Post
    {

        public int PostId {get;set;}
        public string Idea{get;set;}
        public int UserId{get;set;}
        public User User{get;set;}
        public DateTime created_at {get;set;}
        public List<Like> LikeList {get;set;}

    public Post()
    {
        LikeList = new List<Like>();
    }

    }
}