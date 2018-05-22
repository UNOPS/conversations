﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Conversations.Core.Migrations
{
	using Conversations.Core.DataAccess;

	[DbContext(typeof(ConversationsDbContext))]
    [Migration("20180522120101_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cnv")
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Conversations.Core.Domain.CommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnName("AuthorId");

                    b.Property<int>("ConversationId")
                        .HasColumnName("ConversationId")
                        .HasAnnotation("IX_Comment_ConversationId", true);

                    b.Property<Guid>("CorrelationId")
                        .HasColumnName("CorrelationId")
                        .HasAnnotation("UQ_Comment_CorrelationId", true);

                    b.Property<int?>("ParentId")
                        .HasColumnName("ParentId")
                        .HasAnnotation("IX_Comment_ParentId", true);

                    b.Property<DateTime>("PostedOn")
                        .HasColumnName("PostedOn");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnName("Text")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("ParentId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Conversations.Core.Domain.ConversationData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchivedByUserId");

                    b.Property<DateTime?>("ArchivedOn")
                        .HasColumnName("ArchivedOn");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnName("Key")
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("Conversations.Core.Domain.ConversationDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentDataId")
                        .HasColumnName("CommentDataId");

                    b.Property<int>("DocumentId");

                    b.HasKey("Id");

                    b.HasIndex("CommentDataId");

                    b.ToTable("ConversationDocument");
                });

            modelBuilder.Entity("Conversations.Core.Domain.CommentData", b =>
                {
                    b.HasOne("Conversations.Core.Domain.ConversationData", "ConversationData")
                        .WithMany("Comments")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Conversations.Core.Domain.CommentData")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Conversations.Core.Domain.ConversationDocument", b =>
                {
                    b.HasOne("Conversations.Core.Domain.CommentData", "CommentData")
                        .WithMany("ConversationDocuments")
                        .HasForeignKey("CommentDataId");
                });
#pragma warning restore 612, 618
        }
    }
}
