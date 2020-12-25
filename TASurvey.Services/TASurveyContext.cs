using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TASurvey.model.Models
{
    public partial class TASurveyContext : DbContext
    {
        public TASurveyContext()
        {
        }

        public TASurveyContext(DbContextOptions<TASurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOrder> QuestionOrders { get; set; }
        public virtual DbSet<Respondent> Respondents { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("text");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("updated");
            });

            modelBuilder.Entity<QuestionOrder>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.SurveyId });

                entity.ToTable("question_order");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionOrders)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question_order_question_1");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.QuestionOrders)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question_order_survey_1");
            });

            modelBuilder.Entity<Respondent>(entity =>
            {
                entity.ToTable("respondent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .HasColumnName("email");

                entity.Property(e => e.Hashedpassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("hashedpassword");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasKey(e => new { e.SurveyResponseId, e.QuestionId, e.RespondentId });

                entity.ToTable("response");

                entity.Property(e => e.SurveyResponseId).HasColumnName("survey_response_id");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.RespondentId).HasColumnName("respondent_id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_response_question_1");

                entity.HasOne(d => d.Respondent)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.RespondentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_response_respondent_1");

                entity.HasOne(d => d.SurveyResponse)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.SurveyResponseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_response_survey_response_1");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("survey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("updated");
            });

            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.ToTable("survey_response");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RespondentId).HasColumnName("respondent_id");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.Property(e => e.Updated)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("updated");

                entity.HasOne(d => d.Respondent)
                    .WithMany(p => p.SurveyResponses)
                    .HasForeignKey(d => d.RespondentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_survey_response_respondent_1");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyResponses)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_survey_response_survey_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
