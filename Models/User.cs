

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bright_Ideas.Models
{
    public class User
    {

        public int UserId {get;set;}
        public string Name {get;set;}
        public string Alias{get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public DateTime created_at {get;set;}
        public List<Like> LikeList {get;set;}
        public List<Post> ListPosts {get;set;}
        public User()
        {
            LikeList = new List<Like>();
            ListPosts = new List<Post>();

        }

    }
}