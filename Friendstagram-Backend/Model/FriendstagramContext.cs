using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class FriendstagramContext : DbContext
    {
        public FriendstagramContext()
        {
        }

        public FriendstagramContext(DbContextOptions<FriendstagramContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FileType> FileTypes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseMySql(ConfigurationManager.ConnectionStrings["default"].ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => new { e.ChatMessageId, e.UserId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("chatMessage");

                entity.HasIndex(e => e.ChatMessageId, "chatMessageId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "fk_chatMessage_user1_idx");

                entity.Property(e => e.ChatMessageId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("chatMessageId");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userId");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChatMessages)
                    .HasPrincipalKey(p => p.UserId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chatMessage_user1");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => new { e.CommentId, e.PostId, e.UserId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("comment");

                entity.HasIndex(e => e.PostId, "fk_comment_post1_idx");

                entity.HasIndex(e => e.UserId, "fk_comment_user1_idx");

                entity.HasIndex(e => e.CommentId, "id_comment_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CommentId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("commentId");

                entity.Property(e => e.PostId)
                    .HasColumnType("int(11)")
                    .HasColumnName("postId");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("text");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.PostId)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comment_post1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasPrincipalKey(p => p.UserId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comment_user1");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PRIMARY");

                entity.ToTable("fileType");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TypeId, "typeId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("typeId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.HasIndex(e => e.GroupId, "groupId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Code, "group_code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("groupId");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.ResourceId, e.UserId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("post");

                entity.HasIndex(e => e.ResourceId, "fk_post_resource1_idx");

                entity.HasIndex(e => e.UserId, "fk_post_user1_idx");

                entity.HasIndex(e => e.PostId, "id_post_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PostId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("postId");

                entity.Property(e => e.ResourceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("resourceId");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Heading)
                    .HasMaxLength(100)
                    .HasColumnName("heading");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Posts)
                    .HasPrincipalKey(p => p.ResourceId)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post_resource1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasPrincipalKey(p => p.UserId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post_user1");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => new { e.ResourceId, e.FileTypeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("resource");

                entity.HasIndex(e => e.FileTypeId, "fk_resource_fileType1_idx");

                entity.HasIndex(e => e.ResourceId, "resourceId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ResourceId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("resourceId");

                entity.Property(e => e.FileTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fileTypeId")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("filename");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("path");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_resource_fileType1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId, e.ProfilePictureId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.GroupId, "fk_user_group1_idx");

                entity.HasIndex(e => e.ProfilePictureId, "fk_user_resource1_idx");

                entity.HasIndex(e => e.UserId, "userId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "username_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.VerificationCode, "verification_code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userId");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("groupId");

                entity.Property(e => e.ProfilePictureId)
                    .HasColumnType("int(11)")
                    .HasColumnName("profilePictureId")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("salt");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");

                entity.Property(e => e.VerificationCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("verification_code");

                entity.Property(e => e.Verified)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("verified");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_group1");

                entity.HasOne(d => d.ProfilePicture)
                    .WithMany(p => p.Users)
                    .HasPrincipalKey(p => p.ResourceId)
                    .HasForeignKey(d => d.ProfilePictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_resource1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
