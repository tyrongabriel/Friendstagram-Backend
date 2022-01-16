using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Friendstagram_Backend.DTOs;
using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public static ResourceDto AsDto(this Resource resource)
        {
            return new ResourceDto()
            {
                id_resource = resource.ResourceId,
                filename = resource.Filename,
                path = resource.Path,
                path_compressed = resource.PathCompressed,
                fileType = resource.FileType.AsDto()
            };
        }

        public static GroupDto AsDto(this Group group)
        {
            return new GroupDto()
            {
                id_group = group.GroupId,
                name = group.Name,
                code = group.Code,
                users = group.Users.Select(u => u.AsDto()).ToList()
            };
        }

        public static FileTypeDto AsDto(this FileType fileType)
        {
            return new FileTypeDto()
            {
                id_fileType = fileType.TypeId,
                name = fileType.Name
            };
        }

        public static void GetUser(this ClaimsPrincipal user, FriendstagramContext DBContext, out User GottenUser, bool loadProfilePicture = false)
        {
            //User gotUser = new User(){
            //    UserId = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "UserId").Value),
            //    Email = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
            //    GroupId = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "GroupId").Value),
            //    Verified = Convert.ToSByte(Convert.ToUInt32(user.Claims.FirstOrDefault(c => c.Type == "Verified").Value))
            //};
            //gotUser = DBContext.Users.FirstOrDefault(u => u.UserId == gotUser.UserId);
            int id = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            if (loadProfilePicture)
            {
                GottenUser = DBContext.Users.FirstOrDefault(u => u.UserId == id);
            }
            else
            {
                GottenUser = DBContext.Users.Include(u => u.ProfilePicture).FirstOrDefault(u => u.UserId == id);
            }
        }

        public static Resource AsResource(this IFormFile file, FriendstagramContext DBContext)
        {
            string FileName = file.FileName.Substring(0, file.FileName.LastIndexOf('.'));
            string FileTypeName = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
            FileType type = DBContext.FileTypes.FirstOrDefault(f => f.Name == FileTypeName);
            if (type == null)
            {
                type = new FileType()
                {
                    Name = FileTypeName
                };
            }

            Resource newFile = new Resource()
            {
                Filename = FileName,
                Path = $"images/profiles/{FileName}.{type.Name}",
                PathCompressed = $"images/profiles/{FileName}.{type.Name}",
                FileType = type
            };

            return newFile;
        }

    }
}
