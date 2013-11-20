﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using nl.fhict.IntelliCloud.Data.Model;

namespace nl.fhict.IntelliCloud.Data.Context
{
    /// <summary>
    /// A data context providing access to the IntelliCloud database.
    /// </summary>
    public class IntelliCloudContext : DbContext, IDisposable
    {
        public IntelliCloudContext()
            : base(GetConnectionString())
        {
            this.Answers = this.Set<AnswerEntity>();
            this.AnswerKeys = this.Set<AnswerKeyEntity>();
            this.Feedbacks = this.Set<FeedbackEntity>();
            this.Keywords = this.Set<KeywordEntity>();
            this.Questions = this.Set<QuestionEntity>();
            this.QuestionKeys = this.Set<QuestionKeyEntity>();
            this.Reviews = this.Set<ReviewEntity>();
            this.SourceDefinitions = this.Set<SourceDefinitionEntity>();
            this.Sources = this.Set<SourceEntity>();
            this.Users = this.Set<UserEntity>();
        }

        /// <summary>
        /// Gets a database set for the <see cref="AnswerEntity"/> entities.
        /// </summary>
        public DbSet<AnswerEntity> Answers { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="AnswerKeyEntity"/> entities.
        /// </summary>
        public DbSet<AnswerKeyEntity> AnswerKeys { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="FeedbackEntity"/> entities.
        /// </summary>
        public DbSet<FeedbackEntity> Feedbacks { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="KeywordEntity"/> entities.
        /// </summary>
        public DbSet<KeywordEntity> Keywords { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="QuestionEntity"/> entities.
        /// </summary>
        public DbSet<QuestionEntity> Questions { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="QuestionKeyEntity"/> entities.
        /// </summary>
        public DbSet<QuestionKeyEntity> QuestionKeys { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="ReviewEntity"/> entities.
        /// </summary>
        public DbSet<ReviewEntity> Reviews { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="SourceDefinitionEntity"/> entities.
        /// </summary>
        public DbSet<SourceDefinitionEntity> SourceDefinitions { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="SourceEntity"/> entities.
        /// </summary>
        public DbSet<SourceEntity> Sources { get; private set; }

        /// <summary>
        /// Gets a database set for the <see cref="UserEntity"/> entities.
        /// </summary>
        public DbSet<UserEntity> Users { get; private set; }

        /// <summary>
        /// Creates a connection string to the IntelliCloud database by using the data from the settings file.
        /// </summary>
        /// <returns>Returns the connection string.</returns>
        private static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = ConfigurationManager.AppSettings["IntelliCloud.Database.Catalog"],
                DataSource = ConfigurationManager.AppSettings["IntelliCloud.Database.DataSource"],
                IntegratedSecurity = false,
                MultipleActiveResultSets = true,
                Password = ConfigurationManager.AppSettings["IntelliCloud.Database.Password"],
                PersistSecurityInfo = true,
                UserID = ConfigurationManager.AppSettings["IntelliCloud.Database.Username"]
            };

            return sqlConnectionString.ConnectionString;
        }
    }
}