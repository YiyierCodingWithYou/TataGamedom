using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Games;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data.Entity;
using System.Data;
using System.IO;

namespace TataGamedom.Models.Infra
{
	public class NPOIHelper
	{
		string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		AppDbContext db = new AppDbContext();

		public void InsertGames(Game game, string currentUserAccount)
		{
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

			SqlConnection sqlConnection = new SqlConnection(_connStr);

			SqlCommand sqlCommand = new SqlCommand(@" INSERT INTO Games(ChiName,EngName,Description,IsRestrict
  ,GameCoverImg,CreatedTime,CreatedBackendMemberId) VALUES(@ChiName,@EngName,@Description,@IsRestrict
  ,@GameCoverImg,@CreatedTime,@CreatedBackendMemberId)");
			sqlCommand.Parameters.Add(new SqlParameter("@ChiName", game.ChiName));
			sqlCommand.Parameters.Add(new SqlParameter("@EngName", game.EngName));
			sqlCommand.Parameters.Add(new SqlParameter("@Description", game.Description));
			sqlCommand.Parameters.Add(new SqlParameter("@IsRestrict", game.IsRestrict));
			sqlCommand.Parameters.Add(new SqlParameter("@GameCoverImg", game.GameCoverImg));
			sqlCommand.Parameters.Add(new SqlParameter("@CreatedTime",DateTime.Now));
			sqlCommand.Parameters.Add(new SqlParameter("@CreatedBackendMemberId", memberInDb.Id));

			sqlCommand.Connection = sqlConnection;

			sqlConnection.Open(); //開啟資料庫的連結
			sqlCommand.ExecuteNonQuery(); //使用SqlCommand的ExecuteReader()方法，
			sqlConnection.Close(); //關閉資料庫的連結
		}

		public void InsertBoards(Board board, string currentUserAccount)
		{
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

			SqlConnection sqlConnection = new SqlConnection(_connStr);

			SqlCommand sqlCommand = new SqlCommand(@" INSERT INTO boards (Name, GameId, BoardAbout, BoardHeaderCoverImg,CreatedTime,CreatedBackendMemberId)
VALUES
(@Name, @GameId, @BoardAbout, @BoardHeaderCoverImg, @CreatedTime, @CreatedBackendMemberId)");
			sqlCommand.Parameters.Add(new SqlParameter("@Name", board.Name));
			sqlCommand.Parameters.Add(new SqlParameter("@GameId", board.GameId));
			sqlCommand.Parameters.Add(new SqlParameter("@BoardAbout", board.BoardAbout));
			sqlCommand.Parameters.Add(new SqlParameter("@BoardHeaderCoverImg", board.BoardHeaderCoverImg));
			sqlCommand.Parameters.Add(new SqlParameter("@CreatedTime", DateTime.Now));
			sqlCommand.Parameters.Add(new SqlParameter("@CreatedBackendMemberId", memberInDb.Id));

			sqlCommand.Connection = sqlConnection;

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		public void InsertProducts(Product product, string currentUserAccount)
		{
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

			SqlConnection sqlConnection = new SqlConnection(_connStr);

			SqlCommand sqlCommand = new SqlCommand(@" INSERT INTO Products ([Index], GameId, IsVirtual, Price, GamePlatformId, SystemRequire, ProductStatusId, SaleDate, CreatedBackendMemberId, CreatedTime)
VALUES

(@Index, @GameId, @IsVirtual, @Price, @GamePlatformId, @SystemRequire, @ProductStatusId, @SaleDate, @CreatedBackendMemberId, @CreatedTime)");
			sqlCommand.Parameters.Add(new SqlParameter("@Index", product.Index));
			sqlCommand.Parameters.Add(new SqlParameter("@GameId", product.GameId));
			sqlCommand.Parameters.Add(new SqlParameter("@IsVirtual", product.IsVirtual));
			sqlCommand.Parameters.Add(new SqlParameter("@Price", product.Price));
			sqlCommand.Parameters.Add(new SqlParameter("@GamePlatformId", product.GamePlatformId));
			sqlCommand.Parameters.Add(new SqlParameter("@SystemRequire", product.SystemRequire));
			sqlCommand.Parameters.Add(new SqlParameter("@ProductStatusId", product.ProductStatusId));
			sqlCommand.Parameters.Add(new SqlParameter("@SaleDate", product.SaleDate));
			sqlCommand.Parameters.Add(new SqlParameter("@CreatedTime", DateTime.Now));
			sqlCommand.Parameters.Add(new SqlParameter("@CreatedBackendMemberId", memberInDb.Id));

			sqlCommand.Connection = sqlConnection;

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
	}
}