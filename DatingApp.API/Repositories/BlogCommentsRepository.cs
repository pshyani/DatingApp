﻿using DatingApp.API.Contracts;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Repositories
{
    public class BlogCommentsRepository: IBlogCommentsRepository
    {
        private DatingContext _context;

        public BlogCommentsRepository(DatingContext context)
        {
            _context = context;
        }
        public async Task<BlogComments> Add(BlogComments blogComment)
        {
            await _context.BlogComments.AddAsync(blogComment);
            await _context.SaveChangesAsync();
            return blogComment;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.BlogComments.AnyAsync(P => P.BlogCommentsId == id);
        }

        public async Task<BlogComments> Find(int id)
        {
            var dbblogComment = await _context.BlogComments.SingleOrDefaultAsync(q => q.BlogCommentsId == id);
            return dbblogComment;

        }

        public IEnumerable<BlogComments> GetAll(int blogId)
        {
            return _context.BlogComments.OrderByDescending(o => o.Datecreated).Where(P => P.BlogId == blogId).ToList();
        }

        public async Task<BlogComments> Remove(int id)
        {
            var blogComment = await _context.BlogComments.SingleAsync(P => P.BlogCommentsId == id);
            _context.BlogComments.Remove(blogComment);
            await _context.SaveChangesAsync();
            return blogComment;
        }

        public async Task<BlogComments> Update(BlogComments blogComment)
        {
            _context.BlogComments.Update(blogComment);
            await _context.SaveChangesAsync();
            return blogComment;
        }
    }
}
