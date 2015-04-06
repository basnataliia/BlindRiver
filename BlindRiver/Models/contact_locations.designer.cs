﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
	public partial class contact_locationsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertcontact_location(contact_location instance);
    partial void Updatecontact_location(contact_location instance);
    partial void Deletecontact_location(contact_location instance);
    #endregion
		
		public contact_locationsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_9B4CDA_webdevelopmentConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public contact_locationsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public contact_locationsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public contact_locationsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public contact_locationsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<contact_location> contact_locations
		{
			get
			{
				return this.GetTable<contact_location>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.contact_locations")]
	public partial class contact_location : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _title;
		
		private string _address;
		
		private string _phone;
		
		private string _fax;
		
		private System.Nullable<double> _latitude;
		
		private System.Nullable<double> _longitude;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnfaxChanging(string value);
    partial void OnfaxChanged();
    partial void OnlatitudeChanging(System.Nullable<double> value);
    partial void OnlatitudeChanged();
    partial void OnlongitudeChanging(System.Nullable<double> value);
    partial void OnlongitudeChanged();
    #endregion
		
		public contact_location()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(50)")]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="VarChar(250)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="VarChar(50)")]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fax", DbType="VarChar(50)")]
		public string fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				if ((this._fax != value))
				{
					this.OnfaxChanging(value);
					this.SendPropertyChanging();
					this._fax = value;
					this.SendPropertyChanged("fax");
					this.OnfaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_latitude", DbType="Float")]
		public System.Nullable<double> latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				if ((this._latitude != value))
				{
					this.OnlatitudeChanging(value);
					this.SendPropertyChanging();
					this._latitude = value;
					this.SendPropertyChanged("latitude");
					this.OnlatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_longitude", DbType="Float")]
		public System.Nullable<double> longitude
		{
			get
			{
				return this._longitude;
			}
			set
			{
				if ((this._longitude != value))
				{
					this.OnlongitudeChanging(value);
					this.SendPropertyChanging();
					this._longitude = value;
					this.SendPropertyChanged("longitude");
					this.OnlongitudeChanged();
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