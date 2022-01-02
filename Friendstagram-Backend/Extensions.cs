using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendstagram_Backend.DTOs;
using Friendstagram_Backend.Model;

namespace Friendstagram_Backend
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto()
            {
                id_user = user.UserId,
                username = user.Username,
                email = user.Email,
                profile_picture = user.ProfilePicture.Path
            };
        }

        public static PostDto AsDto(this Post post)
        {
            return new PostDto()
            {
                id_post = post.PostId,
                heading = post.Heading,
                description = post.Description,
                created_at = post.CreatedAt.ToShortDateString(),
                image_small = post.Resource.PathCompressed,
                image = post.Resource.Path,
                comments = post.Comments.Select(c => c.AsDto()).ToList(),
                posted_by = post.User.AsDto()
            };
        }

        public static ChatMessageDto AsDto(this ChatMessage message)
        {
            return new ChatMessageDto()
            {
                content = message.Content,
                date = message.CreatedAt.ToShortDateString(),
                sender = message.User.AsDto()
            };
        }

        public static CommentDto AsDto(this Comment comment)
        {
            return new CommentDto()
            {
                id_comment = comment.CommentId,
                id_post = comment.PostId,
                id_user = comment.Post.UserId,
                comment = comment.Text,
                created_at = comment.CreatedAt.ToShortDateString(),
                user = comment.Post.User.AsDto()
            };
        }

    }
}
