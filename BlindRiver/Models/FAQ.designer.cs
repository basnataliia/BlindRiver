﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlindRiver.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_9B4CDA_webdevelopment")]
	public partial class FAQDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertFAQ(FAQ instance);
    partial void UpdateFAQ(FAQ instance);
    partial void DeleteFAQ(FAQ instance);
    #endregion
		
		public FAQDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_9B4CDA_webdevelopmentConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FAQDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FAQDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FAQDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FAQDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<FAQ> FAQs
		{
			get
			{
				return this.GetTable<FAQ>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FAQ")]
	public partial class FAQ : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _questions;
		
		private string _answers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnquestionsChanging(string value);
    partial void OnquestionsChanged();
    partial void OnanswersChanging(string value);
    partial void OnanswersChanged();
    #endregion
		
		public FAQ()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_questions", DbType="VarChar(300)")]
		public string questions
		{
			get
			{
				return this._questions;
			}
			set
			{
				if ((this._questions != value))
				{
					this.OnquestionsChanging(value);
					this.SendPropertyChanging();
					this._questions = value;
					this.SendPropertyChanged("questions");
					this.OnquestionsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_answers", DbType="VarChar(300)")]
		public string answers
		{
			get
			{
				return this._answers;
			}
			set
			{
				if ((this._answers != value))
				{
					this.OnanswersChanging(value);
					this.SendPropertyChanging();
					this._answers = value;
					this.SendPropertyChanged("answers");
					this.OnanswersChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
