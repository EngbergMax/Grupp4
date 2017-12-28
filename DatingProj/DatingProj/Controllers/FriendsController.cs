﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    
    public class FriendsController : BaseController
    {
        [HttpPost]
        public void  SendFriendRequest(string id)
        {

            var you = db.Users.Single(x => x.Id == id);
            var me = db.Users.Single(z => z.Id == User.Identity.GetUserId());
        }

        public ActionResult SendRequest(string id)
        {
           var Request = new Friend{ FriendFrom = User.Identity.GetUserId(), FriendTo = id, IsConfirmed = false};
            db.Friends.Add(Request);
            db.SaveChanges();
            return new EmptyResult();
        }

        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var friends = db.Friends.Where(z => z.FriendTo == id && z.IsConfirmed == true).ToList();
            return View(friends);

        }
    }
}