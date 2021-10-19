﻿using Dapper;
using Microsoft.Data.SqlClient;
using Models.BaseModels;
using Models.BaseModels.System;
using Models.InternalViewModels;
using Models.ViewModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Services.DapperExtension
{
    public class Dapper_Implementation : IDapper
    {
        private readonly GarageDreamDbContext db;

        public Dapper_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public bool CustomerHasContactDetails(Guid CustomerId, string ConnectionString)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
           
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", CustomerId, DbType.Guid, ParameterDirection.Input);

            int valid = connection.ExecuteScalar<int>("SELECT dbo.fn_CustomerHasContactDetails(@CustomerId)", parameters);
            
            if(valid == 1 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CustomerHasAddress(Guid CustomerId, string ConnectionString)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", CustomerId, DbType.Guid, ParameterDirection.Input);

            int valid = connection.ExecuteScalar<int>("SELECT dbo.fn_CustomerHasAddress(@CustomerId)", parameters);

            if (valid == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CustomerHasVehicles(Guid CustomerId, string ConnectionString)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", CustomerId, DbType.Guid, ParameterDirection.Input);

            int valid = connection.ExecuteScalar<int>("SELECT dbo.fn_CustomerHasVehicles(@CustomerId)", parameters);

            if (valid == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CustomerIndexInternalModel> GenerateCustomerIndexView(string ConnectionString)
        {
            List<CustomerIndexInternalModel> model = new();

            using IDbConnection connection = new SqlConnection(ConnectionString);
            model = connection.Query<CustomerIndexInternalModel>("SELECT * FROM CustomerIndexView").AsList();

            return model;
        }

        public List<DiarySlotViewModel> GenerateDiarySlotsIndexView(string ConnectionString, DiarySlotFilterViewModel Filters)
        {
            string workArea;
            List<DiarySlotViewModel> model = new();

            if (Filters.WorkArea == null)
            {
                workArea = "null";
            }
            else
            {
                string WorkAreaDescription = db.WorkAreas
                .Where(x => x.WorkAreaId == Filters.WorkArea.WorkAreaId)
                .Select(x => x.WorkAreaDescription)
                .FirstOrDefault();

                workArea = "'" + WorkAreaDescription + "'";
            }

            DateTime latestDiarySlot = db.DiarySlots
                .OrderByDescending(x => x.DiaryWorkingDate.WorkingDate)
                .Select(x => x.DiaryWorkingDate.WorkingDate)
                .FirstOrDefault();

            if (Filters.StartDate == DateTime.MinValue) { Filters.StartDate = DateTime.Now; }
            if (Filters.EndDate == DateTime.MinValue) { Filters.EndDate = latestDiarySlot; }

            Filters.StartDate = Filters.StartDate.Date;
            Filters.EndDate = Filters.EndDate.Date;

            using IDbConnection connection = new SqlConnection(ConnectionString);
            string sqlScript = "SELECT * FROM fn_DiarySlotIndexView('" + Filters.StartDate + "' ,'"
                + Filters.EndDate + "' ,"
                + workArea
                + ")"
                + " ORDER BY WorkingDate, WorkAreaDescription";

            model = connection.Query<DiarySlotViewModel>(sqlScript).AsList();
            
            return model;
        }

        public List<SystemJobIndexViewModel> GenerateSystemJobHistory(string ConnectionString)
        {
            List<SystemJobIndexViewModel> model = new();

            using IDbConnection connection = new SqlConnection(ConnectionString);
            model = connection.Query<SystemJobIndexViewModel>("SELECT * FROM SystemJobIndexView").AsList();

            return model;
        }

        public void ManualRunSystemJob(SystemJob SystemJob, string ConnectionString)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            string commandText = "EXEC " + SystemJob.ProcedureName;
            connection.Query(commandText);
        }

        public void RunAllAutoSystemJobs(List<SystemJob> SystemJobs, string ConnectionString)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            foreach (var job in SystemJobs)
            {
                string commandText = string.Concat("EXEC {0}", job.ProcedureName);
                connection.Query(commandText);
            }
        }
    }
}