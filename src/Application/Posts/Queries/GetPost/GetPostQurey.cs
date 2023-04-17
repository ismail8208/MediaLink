using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.TodoLists.Queries.ExportTodos;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Posts.Queries.GetPost;
public record GetPostQurey(int Id) : IRequest<PostDto>;
public class GetPostQureyHandler : IRequestHandler<GetPostQurey, PostDto>
{
    private readonly IApplicationDbContext _context;
    public GetPostQureyHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PostDto> Handle(GetPostQurey request, CancellationToken cancellationToken)
    {
        var post =  await _context.Posts.FindAsync(request.Id);
        if (post == null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }

        var entity = new PostDto
        {
            Id= post.Id,
            Content= post.Content,
            ImageURL= post.ImageURL,
            NumberOfComments= post.NumberOfComments,
            NumberOfLikes = post.NumberOfLikes,
            UserId= post.UserId,
            VideoURL = post.VideoURL
        };

        return entity;
    }
}